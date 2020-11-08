from config import *


class AbstractProduct(db.Model):
    __tablename__ = 'abstract_product'
    id = db.Column(db.Integer, primary_key=True)
    product_name = db.Column(db.String(80), nullable=False)
    product_category_id = db.Column(db.Integer, db.ForeignKey('product_category.id'))

    def __repr__(self):
        return '<AbstractProduct %r>' % self.product_name

    @staticmethod
    def get_all():
        return AbstractProduct.query.all()

    @staticmethod
    def get_product(name):
        return AbstractProduct.query.filter(AbstractProduct.product_name.contains(name)).first()

    @staticmethod
    def get_by_id(abstract_product_id):
        return AbstractProduct.query.filter(AbstractProduct.id == abstract_product_id).first()
