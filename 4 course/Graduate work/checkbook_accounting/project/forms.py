import decimal

from flask_babel import _, lazy_gettext as _l
from flask_wtf import FlaskForm
from wtforms import StringField, PasswordField, BooleanField, SubmitField, DecimalField
from wtforms.validators import DataRequired, Email, EqualTo


# ...


class BetterDecimalField(DecimalField):
    def __init__(self, label=None, validators=None, places=2, rounding=None,
                 round_always=False, **kwargs):
        super(BetterDecimalField, self).__init__(
            label=label, validators=validators, places=places, rounding=
            rounding, **kwargs)
        self.round_always = round_always

    def process_formdata(self, valuelist):
        if valuelist:
            try:
                self.data = decimal.Decimal(valuelist[0])
                if self.round_always and hasattr(self.data, 'quantize'):
                    exp = decimal.Decimal('.1') ** self.places
                    if self.rounding is None:
                        quantized = self.data.quantize(exp)
                    else:
                        quantized = self.data.quantize(exp, rounding=
                                                       self.rounding)
                    self.data = quantized
            except (decimal.InvalidOperation, ValueError):
                self.data = None
                raise ValueError(self.gettext(_('Значение не корректно')))


class LoginForm(FlaskForm):
    username = StringField(_('Логин'), validators=[DataRequired()])
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    remember_me = BooleanField('Запомнить меня')
    submit = SubmitField(_l('Войти'))


class RegistrationForm(FlaskForm):
    username = StringField(_('Логин'), validators=[DataRequired()])
    email = StringField('Email', validators=[DataRequired(), Email()])
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    password2 = PasswordField(_('Повторите пароль'), validators=[DataRequired(), EqualTo('password')])
    submit = SubmitField('Зарегистрироваться')


class EditProfileForm(FlaskForm):
    username = StringField(_('Логин'), validators=[DataRequired()])
    wage = BetterDecimalField(label='Заработная плата', round_always=True)
    submit = SubmitField(_l('Отправить'))


class ResetPasswordRequestForm(FlaskForm):
    email = StringField('Email', validators=[DataRequired(), Email()])
    submit = SubmitField(_('Сбросить пароль'))


class ResetPasswordForm(FlaskForm):
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    password2 = PasswordField(_('Повторите пароль'), validators=[DataRequired(), EqualTo('password')])
    submit = SubmitField(_('Сбросить пароль'))


class AddCheckForm(FlaskForm):
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    submit = SubmitField(_('Обработать'))


class AddManualCheckForm(FlaskForm):
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    submit = SubmitField(_('Внести'))


class CheckExcel(FlaskForm):
    password = PasswordField(_('Пароль'), validators=[DataRequired()])
    submit = SubmitField(_('Внести'))
