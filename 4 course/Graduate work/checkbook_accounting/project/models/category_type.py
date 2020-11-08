from config import *


class CategoryType(db.Model):
    __tablename__ = 'category_type'
    id = db.Column(db.Integer, primary_key=True)
    category_type_name = db.Column(db.String(80), unique=True, nullable=False)

    def __repr__(self):
        return '<CategoryType %r>' % self.category_type_name

    @staticmethod
    def get_all():
        return CategoryType.query.all()

    @staticmethod
    def get_by_id(id):
        return CategoryType.query.filter(CategoryType.id == id).first()

    @staticmethod
    def get_by_name(name):
        return CategoryType.query.filter(CategoryType.category_type_name.contains(name)).first()
