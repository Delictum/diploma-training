from hashlib import md5
from time import time

import jwt

from flask_login import UserMixin
from werkzeug.security import generate_password_hash, check_password_hash

from config import *


class User(UserMixin, db.Model):
    """ User Model for storing user related details """
    __tablename__ = "user"

    id = db.Column(db.INTEGER, primary_key=True)
    email = db.Column(db.String(255), unique=True, nullable=False)
    registered_on = db.Column(db.DateTime, nullable=False)
    is_admin = db.Column(db.Boolean, nullable=False, default=False)
    public_id = db.Column(db.String(100), unique=True)
    username = db.Column(db.String(50), unique=True)
    password_hash = db.Column(db.String(100))
    confirmed = db.Column(db.Boolean, nullable=False, default=False)
    confirmed_on = db.Column(db.DateTime, nullable=True)
    wage = db.Column(db.NUMERIC(15, 2), unique=False, nullable=True)

    @property
    def password(self):
        raise AttributeError('password: write-only field')

    @password.setter
    def password(self, password):
        self.password_hash = generate_password_hash(password)

    def check_password(self, password):
        return check_password_hash(self.password_hash, password)

    def get_id(self):
        return str(self.id)

    @staticmethod
    def get_user_by_public_id(public_id):
        return User.query.filter(User.public_id == public_id).first()

    def avatar(self, size):
        digest = md5(self.email.lower().encode('utf-8')).hexdigest()
        return 'https://www.gravatar.com/avatar/{}?d=identicon&s={}'.format(digest, size)

    def link_avatar(self):
        return md5(self.email.lower().encode('utf-8'))

    def get_reset_password_token(self, expires_in=600):
        return jwt.encode(
            {'reset_password': self.id, 'exp': time() + expires_in},
            app.config['SECRET_KEY'], algorithm='HS256').decode('utf-8')

    @staticmethod
    def verify_reset_password_token(token):
        try:
            id_ = jwt.decode(token, app.config['SECRET_KEY'], algorithms=['HS256'])['reset_password']
        except:
            return
        return User.query.get(id_)

    def get_confirm_email_token(self, expires_in=3600):
        return jwt.encode(
            {'confirm_email': self.id, 'exp': time() + expires_in},
            app.config['SECRET_KEY'], algorithm='HS256').decode('utf-8')

    @staticmethod
    def verify_confirm_email_token(token):
        try:
            id_ = jwt.decode(token, app.config['SECRET_KEY'], algorithms=['HS256'])['confirm_email']
        except:
            return
        return User.query.get(id_)

    def __repr__(self):
        return "<User '{}'>".format(self.username)


@login.user_loader
def load_user(id_):
    return User.query.get(int(id_))
