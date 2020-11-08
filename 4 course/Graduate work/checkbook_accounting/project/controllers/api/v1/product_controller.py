from flask import jsonify, request

from project.models.abstract_product import AbstractProduct
from project.models.category_type import CategoryType
from project.models.product import Product
from project.models.product_category import ProductCategory
from session import *
from project.models import organization


BASE_URL = '/api/v1/product'


@app.route(BASE_URL + '/get_all_product_fields_info_by_id/<product_id>', methods=['GET'])
def get_all_product_fields_info_by_id(product_id):
    if int(product_id) < 0:
        return jsonify({'message': 'Fail.'}), 404

    db_product = Product.get_product_by_id(int(product_id))

    db_abstract_product = AbstractProduct.get_by_id(db_product.abstract_product_id)

    product_category = ProductCategory.get_by_id(db_abstract_product.product_category_id)
    category_type = CategoryType.get_by_id(product_category.category_type_id)

    results = [db_product.product_name, str(db_product.product_price), db_abstract_product.product_name,
               product_category.product_category_name, category_type.category_type_name]
    response = jsonify(results)
    response.status_code = 200
    return response


@app.route(BASE_URL + '/get_all_product_info/<product_name>', methods=['GET'])
def get_all_product_info(product_name):
    if len(product_name) < 2:
        return jsonify({'message': 'Fail.'}), 404

    abstract_product = product_name.capitalize()
    db_abstract_product = AbstractProduct.get_product(abstract_product)

    if db_abstract_product is None:
        temp_str = abstract_product[0]
        i = 1
        while len(abstract_product) > i and abstract_product[i].islower():
            abstract_product = abstract_product[i]
            i += 1
        db_abstract_product = AbstractProduct.get_product(temp_str)

    if db_abstract_product is None:
        temp_ap = abstract_product[1:abstract_product.find(' ')]
        abstract_product = abstract_product[0:abstract_product.find(' ')]
        db_abstract_product = AbstractProduct.get_product(abstract_product)

    if db_abstract_product is None:
        part_len = int(len(abstract_product) / 2)
        db_abstract_product = AbstractProduct.get_product(abstract_product[:part_len])

        if db_abstract_product is None:
            db_abstract_product = AbstractProduct.get_product('Неопределено')

    product_category = ProductCategory.get_by_id(db_abstract_product.product_category_id)
    category_type = CategoryType.get_by_id(product_category.category_type_id)

    results = [db_abstract_product.product_name, product_category.product_category_name, category_type.category_type_name]
    response = jsonify(results)
    response.status_code = 200
    return response


@app.route(BASE_URL + '/get_category_type/<product_category>', methods=['GET'])
def get_category_type(product_category):
    if len(product_category) < 3:
        return jsonify({'message': 'Fail.'}), 404

    product_category = product_category.capitalize()
    db_product_category = ProductCategory.get_by_name(product_category)

    if db_product_category is None:
        temp_str = product_category[0]
        i = 1
        while len(product_category) > i and product_category[i].islower():
            temp_str += product_category[i]
            i += 1
        db_product_category = ProductCategory.get_by_name(temp_str)

    if db_product_category is None:
        abstract_product = product_category[0:product_category.find(' ')]
        db_product_category = ProductCategory.get_by_name(abstract_product)

    if db_product_category is None:
        part_len = int(len(product_category) / 2)
        db_product_category = ProductCategory.get_by_name(product_category[:part_len])

        if db_product_category is None:
            db_product_category = ProductCategory.get_by_name('Неопределено')

    category_type = CategoryType.get_by_id(db_product_category.category_type_id)

    results = [db_product_category.product_category_name, category_type.category_type_name]
    response = jsonify(results)
    response.status_code = 200
    return response


@app.route(BASE_URL + '/get_all_product_info_by_id/<id>', methods=['GET'])
def get_all_product_info_by_id(id):
    id = int(id)
    if id < 0:
        return jsonify({'message': 'Fail.'}), 404

    db_product = Product.query.filter(Product.id == id).first()
    db_abstract_product = AbstractProduct.query.filter(AbstractProduct.id == db_product.abstract_product_id).first()

    product_category = ProductCategory.get_by_id(db_abstract_product.product_category_id)
    category_type = CategoryType.get_by_id(product_category.category_type_id)

    results = [db_abstract_product.product_name, product_category.product_category_name, category_type.category_type_name]
    response = jsonify(results)
    response.status_code = 200
    return response


@app.route(BASE_URL + '/change_product', methods=['POST'])
@csrf.exempt
def change_product():
    db_category_type = CategoryType.get_by_name(request.json['category_type_name'])
    db_product_category = ProductCategory.get_by_name(request.json['product_category_name'])

    if db_product_category is None or db_product_category.category_type_id != db_category_type.id:
        db_product_category = ProductCategory(
            product_category_name=request.json['product_category_name'],
            category_type_id=db_category_type.id
        )
        manual_session.add(db_product_category)
        manual_session.commit()

    db_abstract_product = AbstractProduct.query.filter(
        AbstractProduct.product_name == request.json['abstract_product_name']).first()

    if db_abstract_product is None or db_abstract_product.product_category_id != db_product_category.id:
        db_abstract_product = AbstractProduct(
            product_name=request.json['abstract_product_name'],
            product_category_id=db_product_category.id
        )
        manual_session.add(db_abstract_product)
        manual_session.commit()

    product = Product.query.filter(Product.id == request.json['id']).first()
    product.product_name = request.json['product_name']
    product.product_price = request.json['product_price']
    product.abstract_product_id = db_abstract_product.id

    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/change_abstract_product', methods=['POST'])
@csrf.exempt
def change_abstract_product():
    db_category_type = CategoryType.get_by_name(request.json['category_type_name'])
    db_product_category = ProductCategory.get_by_name(request.json['product_category_name'])

    if db_product_category is None or db_product_category.category_type_id != db_category_type.id:
        db_product_category = ProductCategory(
            product_category_name=request.json['product_category_name'],
            category_type_id=db_category_type.id
        )
        manual_session.add(db_product_category)
        manual_session.commit()

    db_abstract_product = AbstractProduct.query.filter(
        AbstractProduct.product_name == request.json['abstract_product_name']).first()

    if db_abstract_product is None or db_abstract_product.product_category_id != db_product_category.id:
        db_abstract_product = AbstractProduct(
            product_name=request.json['abstract_product_name'],
            product_category_id=db_product_category.id
        )
        manual_session.add(db_abstract_product)
        manual_session.commit()

    product = Product.query.filter(Product.id == request.json['id']).first()
    product.abstract_product_id = db_abstract_product.id

    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/change_category_product', methods=['POST'])
@csrf.exempt
def change_category_product():
    db_category_type = CategoryType.get_by_name(request.json['category_type_name'])
    db_product_category = ProductCategory.get_by_name(request.json['product_category_name'])

    if db_product_category is None or db_product_category.category_type_id != db_category_type.id:
        db_product_category = ProductCategory(
            product_category_name=request.json['product_category_name'],
            category_type_id=db_category_type.id
        )
        manual_session.add(db_product_category)
        manual_session.commit()

    db_abstract_product = AbstractProduct.query.filter(
        AbstractProduct.product_name == request.json['abstract_product_name']).first()

    if db_abstract_product is None or db_abstract_product.product_category_id != db_product_category.id:
        db_abstract_product = None
        db_abstract_product = AbstractProduct(
            product_name=request.json['abstract_product_name'],
            product_category_id=db_product_category.id
        )
        manual_session.add(db_abstract_product)
        manual_session.commit()

    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/change_category_type', methods=['POST'])
@csrf.exempt
def change_category_type():
    db_category_type = CategoryType.get_by_name(request.json['category_type_name'])
    db_product_category = ProductCategory.get_by_name(request.json['product_category_name'])

    if db_product_category is None or db_product_category.category_type_id != db_category_type.id:
        db_product_category = ProductCategory(
            product_category_name=request.json['product_category_name'],
            category_type_id=db_category_type.id
        )
        manual_session.add(db_product_category)
        manual_session.commit()

    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/change_price', methods=['POST'])
@csrf.exempt
def change_price():
    product = Product.query.filter(Product.id == request.json['id']).first()
    product.product_price = request.json['product_price']

    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/remove_product', methods=['POST'])
@csrf.exempt
def remove_product():
    product = Product.query.filter(Product.id == request.json['id']).first()

    db.session.delete(product)
    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/add_product', methods=['POST'])
@csrf.exempt
def add_product():
    product = Product(
        product_name='N',
        product_price=1,
        abstract_product_id=70,
        check_id=request.json['check_id']
    )

    db.session.add(product)
    db.session.commit()
    results = [product.id]
    response = jsonify(results)
    response.status_code = 200
    return response
