from config import *


class Organization(db.Model):
    __tablename__ = 'organization'
    id = db.Column(db.Integer, primary_key=True)
    legal_name = db.Column(db.String(50), unique=False, nullable=True)
    legal_address = db.Column(db.String(50), unique=False, nullable=True)
    taxpayer_identification_number = db.Column(db.INTEGER, unique=False, nullable=True)

    def __repr__(self):
        return '<Organization %r>' % self.legal_name

    @staticmethod
    def get_all():
        return Organization.query.all()

    @staticmethod
    def get_organization(name, address):
        return Organization.query.filter(Organization.legal_name.contains(name),
                                         Organization.legal_address.contains(address)).first()
