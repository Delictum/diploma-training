from config import *


class ProductCategory(db.Model):
    __tablename__ = 'product_category'
    id = db.Column(db.Integer, primary_key=True)
    product_category_name = db.Column(db.String(80), unique=True, nullable=False)
    category_type_id = db.Column(db.Integer, db.ForeignKey('category_type.id'))

    def __repr__(self):
        return '<ProductCategory %r>' % self.product_category_name

    @staticmethod
    def get_all():
        return ProductCategory.query.all()

    @staticmethod
    def get_by_id(id):
        return ProductCategory.query.filter(ProductCategory.id == id).first()

    @staticmethod
    def get_by_name(name):
        return ProductCategory.query.filter(ProductCategory.product_category_name.contains(name)).first()
