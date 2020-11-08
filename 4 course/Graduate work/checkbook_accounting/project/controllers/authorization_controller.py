import datetime
import uuid

from flask import redirect, url_for
from flask_login import login_user, logout_user
from werkzeug.urls import url_parse

from project.controllers.user_controller import *
from project.forms import RegistrationForm, LoginForm, ResetPasswordRequestForm, ResetPasswordForm
from project.util.email import send_password_reset_email, send_confirm_email


BASE_URL = '/authorization/'


@app.route(BASE_URL + 'login', methods=['GET', 'POST'])
def login():
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    form = LoginForm()
    if form.validate_on_submit():
        user_ = User.query.filter_by(username=form.username.data).first()
        if user_ is None or not user_.check_password(form.password.data) or not user_.confirmed:
            flash('Неверный логин или пароль. Или учетная запись не потверждена.')
            return redirect(url_for('login'))
        login_user(user_, remember=form.remember_me.data)
        next_page = request.args.get('next')
        if not next_page or url_parse(next_page).netloc != '':
            next_page = url_for('index')
        return redirect(next_page)
    return render_template('authorization/login.html', title='Вход', form=form)


@app.route(BASE_URL + 'register', methods=['GET', 'POST'])
def register():
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    form = RegistrationForm()
    if User.query.filter_by(email=form.email.data).first():
        flash('E-mail уже используется')
        return render_template('authorization/register.html', title='Регистрация', form=form)

    if User.query.filter_by(username=form.username.data).first():
        flash('Логин уже используется')
        return render_template('authorization/register.html', title='Регистрация', form=form)

    if form.validate_on_submit():
        user_ = User(username=form.username.data,
                     email=form.email.data,
                     confirmed=False,
                     public_id=str(uuid.uuid4()),
                     registered_on=datetime.utcnow(),
                     password=form.password.data)
        db.session.add(user_)
        db.session.commit()

        send_confirm_email(user_)
        flash('Вам было отправлено письмо с потверждением создания аккаунта.', 'success')
        return redirect(url_for('login'))
    return render_template('authorization/register.html', title='Регистрация', form=form)


@app.route(BASE_URL + 'logout')
def logout():
    logout_user()
    return redirect(url_for('index'))


@app.route(BASE_URL + 'reset_password_request', methods=['GET', 'POST'])
def reset_password_request():
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    form = ResetPasswordRequestForm()
    if form.validate_on_submit():
        user_ = User.query.filter_by(email=form.email.data).first()
        if user_:
            send_password_reset_email(user_)
        flash('Check your email for the instructions to reset your password')
        return redirect(url_for('login'))
    return render_template('authorization/reset_password_request.html', title='Сброс пароля', form=form)


@app.route(BASE_URL + 'reset_password/<token>', methods=['GET', 'POST'])
def reset_password(token):
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    user_ = User.verify_reset_password_token(token)
    if not user_:
        return redirect(url_for('index'))
    form = ResetPasswordForm()
    if form.validate_on_submit():
        user_.password = form.password.data
        db.session.commit()
        flash('Ваш пароль был сброшен.')
        return redirect(url_for('login'))
    return render_template('authorization/reset_password.html', form=form)


@app.route(BASE_URL + 'confirm_email/<token>', methods=['GET', 'POST'])
def confirm_email(token):
    if current_user.is_authenticated:
        return redirect(url_for('index'))
    user_ = User.verify_confirm_email_token(token)
    if not user_:
        return redirect(url_for('index'))

    user_.confirmed = True
    user_.confirmed_on = datetime.utcnow()
    db.session.commit()
    return render_template('authorization/confirm_email.html')
