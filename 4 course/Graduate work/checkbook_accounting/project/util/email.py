import datetime
from threading import Thread

from flask import render_template, flash, url_for, redirect
from flask_babel import _
from flask_mail import Message

from config import db, app, mail
from project.models.user import User


def send_async_email(app, msg):
    with app.app_context():
        mail.send(msg)


def send_email(subject, sender, recipients, text_body, html_body):
    msg = Message(
        subject,
        sender=sender,
        recipients=recipients,
        body=text_body,
        html=html_body
    )
    Thread(target=send_async_email, args=(app, msg)).start()


def send_password_reset_email(user):
    token = user.get_reset_password_token()
    send_email(_('[Check Accounting] Сброс пароля'),
               sender=app.config.get("MAIL_USERNAME"),
               recipients=[user.email],
               text_body=render_template('authorization/email/reset_password.txt',
                                         user=user, token=token),
               html_body=render_template('authorization/email/reset_password.html',
                                         user=user, token=token))


def send_confirm_email(user):
    token = user.get_confirm_email_token()
    send_email(_('[Checkbook Accounting] Confirm e-mail'),
               sender=app.config.get("MAIL_USERNAME"),
               recipients=[user.email],
               text_body=render_template('authorization/email/activate.txt',
                                         user=user, token=token),
               html_body=render_template('authorization/email/activate.html',
                                         user=user, token=token))
