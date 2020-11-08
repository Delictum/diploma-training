from flask import send_from_directory

from session import *
from flask_bootstrap import Bootstrap
from project.controllers import user_controller, authorization_controller, home_controller, support_controller
from project.controllers.api.v1 import user_controller, organization_controller, product_controller, check_controller
from project.util import errors

data_check = None


@app.route('/favicon.ico')
def favicon():
    return send_from_directory(os.path.join(app.root_path, 'static'),
                               'favicon.ico', mimetype='image/vnd.microsoft.icon')


if __name__ == '__main__':
    app.config.from_object('config.DevelopmentConfig')
    app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
    app.config.from_object('config')

    csrf.init_app(app)
    api.WTF_CSRF_ENABLED = False

    bootstrap = Bootstrap(app)
    Bootstrap(app)

    app.run(host='0.0.0.0', port='5000')
