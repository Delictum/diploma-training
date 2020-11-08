from config import *


class Product(db.Model):
    __tablename__ = 'product'
    id = db.Column(db.Integer, primary_key=True)
    product_name = db.Column(db.String(50), unique=False, nullable=True)
    product_price = db.Column(db.NUMERIC(15, 2), unique=False, nullable=True)
    check_id = db.Column(db.Integer, db.ForeignKey('check.id'))
    abstract_product_id = db.Column(db.Integer, db.ForeignKey('abstract_product.id'))

    def __repr__(self):
        return '<Product %r>' % self

    @staticmethod
    def get_all():
        return Product.query.all()

    @staticmethod
    def get_all_check_products(check_id):
        return Product.query.filter(Product.check_id == check_id).all()

    @staticmethod
    def get_product_by_id(product_id):
        return Product.query.filter(Product.id == product_id).first()
