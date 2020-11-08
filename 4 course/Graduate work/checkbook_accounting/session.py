from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker

from config import *


def create_session(config):
    engine = create_engine(config['SQLALCHEMY_DATABASE_URI'])
    Session = sessionmaker(bind=engine)
    session = Session()
    session._model_changes = {}
    return session


manual_session = create_session(app.config)
