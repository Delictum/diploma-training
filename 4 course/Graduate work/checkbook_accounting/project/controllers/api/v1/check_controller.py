from datetime import datetime
from flask import jsonify, request

from project.models.check import Check
from project.models.product import Product
from session import *
from config import db


BASE_URL = '/api/v1/check'


@app.route(BASE_URL + '/change_date', methods=['POST'])
@csrf.exempt
def change_date():
    check = Check.get_by_id(request.json['check_id'])
    check.date_time_of_purchase = datetime.strptime(request.json['date_time'], '%Y-%m-%d')
    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/remove_check', methods=['POST'])
@csrf.exempt
def remove_check():
    check = Check.get_by_id(request.json['check_id'])

    products = Product.get_all_check_products(check.id)
    for product in products:
        db.session.delete(product)
        db.session.commit()

    db.session.delete(check)
    db.session.commit()
    return jsonify({'message': 'Successfully changed.'}), 200


@app.route(BASE_URL + '/total_cost/<id>', methods=['GET'])
def total_cost(id):
    id = int(id)
    if id < 0:
        return jsonify({'message': 'Fail.'}), 404

    products = Product.query.filter_by(check_id=id).all()

    total_cost = 0
    for product in products:
        total_cost += product.product_price

    results = [str(total_cost)]
    response = jsonify(results)
    response.status_code = 200
    return response
