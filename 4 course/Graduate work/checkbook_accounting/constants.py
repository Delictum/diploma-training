DB_STRING = 'postgresql://admin:admin@localhost/check_accounting'
AUTH_TYPE = 1  # Database Authentication
AUTH_USER_REGISTRATION = True
AUTH_USER_REGISTRATION_ROLE = 'Public'
# Config for Flask-WTF Recaptcha necessary for user registration
RECAPTCHA_PUBLIC_KEY = 'GOOGLE PUBLIC KEY FOR RECAPTCHA'
RECAPTCHA_PRIVATE_KEY = 'GOOGLE PRIVATE KEY FOR RECAPTCHA'
# Config for Flask-Mail necessary for user registration
MAIL_SERVER = 'smtp.gmail.com'
MAIL_USE_TLS = False
MAIL_PORT = 465
MAIL_USE_SSL = True
MAIL_USERNAME = 'checkbook2019@gmail.com'
MAIL_PASSWORD = 'ca_DE_19'

SECRET_KEY = 'powerful secretkey'
WTF_CSRF_SECRET_KEY = "a csrf secret key"

LANGUAGES = ['en', 'ru']

GOOGLE_CLIENT_ID = '1028369424918-r5sno8lgshm1vanvojvhpfje1kejhca5.apps.googleusercontent.com'
GOOGLE_CLIENT_SECRET = '3e0nS0DgQ0NVCHJDVjmhuiDz'
REDIRECT_URI = '/oauth2callback'

DIRECTORY_TEMP_FILES = '/home/delictumest/Downloads/checks/'

CHECKS_PER_PAGE = 10
