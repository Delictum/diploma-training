import os

from flask import Flask, Blueprint
from flask_babel import Babel
from flask_bootstrap import Bootstrap
from flask_login import LoginManager
from flask_mail import Mail
from flask_sqlalchemy import SQLAlchemy
from flask_wtf import CSRFProtect
from flask_restful import Api

from constants import *

app = Flask(__name__)
api = Api(app)

app.config['SQLALCHEMY_DATABASE_URI'] = DB_STRING
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
db = SQLAlchemy(app)

app.config.update(dict(
        SECRET_KEY=SECRET_KEY,
        WTF_CSRF_SECRET_KEY=WTF_CSRF_SECRET_KEY
    ))
WTF_CSRF_ENABLED = True
csrf = CSRFProtect(app)
api.WTF_CSRF_ENABLED = False

api = Api(app, decorators=[csrf.exempt])
api_blueprint = Blueprint('api', __name__)
csrf.exempt(api_blueprint)

app.register_blueprint(api_blueprint)

ALLOWED_EXTENSIONS = set(['txt', 'pdf', 'png', 'jpg', 'jpeg', 'gif'])
UPLOAD_FOLDER = '/home/delictumest/Downloads'
app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

mail_settings = {
    "MAIL_SERVER": MAIL_SERVER,
    "MAIL_PORT": MAIL_PORT,
    "MAIL_USE_TLS": MAIL_USE_TLS,
    "MAIL_USE_SSL": MAIL_USE_SSL,
    "MAIL_USERNAME": MAIL_USERNAME,
    "MAIL_PASSWORD": MAIL_PASSWORD
}
app.config.update(mail_settings)
mail = Mail(app)

bootstrap = Bootstrap(app)

app.config['LANGUAGES'] = LANGUAGES

# app.config.from_pyfile('babel.cfg')
babel = Babel(app)

app.config['OAUTH_CREDENTIALS'] = {
    'facebook': {
        'id': '307880843191110',
        'secret': 'b9241e42ccde9e6f5cbc777d9d1dee83'
    },
    'twitter': {
        'id': '3RzWQclolxWZIMq5LJqzRZPTl',
        'secret': 'm9TEd58DSEtRrZHpz2EjrV9AhsBRxKMo8m3kuIZj3zLwzwIimt'
    }
}

login = LoginManager(app)
login.login_view = 'login'

basedir = os.path.abspath(os.path.dirname(__file__))


class Config:
    SECRET_KEY = os.getenv('SECRET_KEY', 'my_precious_secret_key')
    DEBUG = False


class DevelopmentConfig(Config):
    # uncomment the line below to use postgres
    # SQLALCHEMY_DATABASE_URI = postgres_local_base
    DEBUG = True
    SQLALCHEMY_DATABASE_URI = DB_STRING
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    ASSETS_DEBUG = True


class TestingConfig(Config):
    DEBUG = True
    TESTING = True
    PRESERVE_CONTEXT_ON_EXCEPTION = False
    SQLALCHEMY_TRACK_MODIFICATIONS = False


class ProductionConfig(Config):
    DEBUG = False


config_by_name = dict(
    dev=DevelopmentConfig,
    test=TestingConfig,
    prod=ProductionConfig
)

key = Config.SECRET_KEY
