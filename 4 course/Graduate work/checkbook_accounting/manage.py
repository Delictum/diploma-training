from flask_migrate import Migrate, MigrateCommand
from flask_script import Manager

from config import *


migrate = Migrate(app, db)
manager = Manager(app)

manager.add_command('db', MigrateCommand)


@manager.command
def run():
    app.run()


if __name__ == '__main__':
    app.app_context().push()
    app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False
    manager.run()
