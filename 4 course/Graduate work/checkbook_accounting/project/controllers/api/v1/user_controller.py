import base64
import datetime
import uuid

from flask import jsonify, request

from project.models import user
from project.models.abstract_product import AbstractProduct
from project.models.check import Check
from project.models.organization import Organization
from project.models.product import Product
from project.models.user import User
from project.util.check_process.check_parser import highlight_abstract_product, DataCheck, check_parser, product_parser
from project.util.check_process.check_processing import start_check_process
from project.util.email import send_confirm_email
from project.util.image_process.image_processing import start_abbyy
from session import *

BASE_URL = '/api/v1/user/'


@app.route(BASE_URL + 'get_user', methods=["POST"])
@csrf.exempt
def get_user():
    dict_body = request.get_json()
    user_ = User.query.filter_by(public_id=dict_body['public_id']).first()
    return jsonify({
                "public_id": user_.public_id,
                "email": user_.email,
                "password": user_.password_hash,
                "username": user_.username,
                "registered_on": str(user_.registered_on),
                "confirmed": user_.confirmed,
                "wage": str(user_.wage),
                "confirmed_on": str(user_.confirmed_on)
            })


@app.route(BASE_URL + 'create_user', methods=["POST"])
@csrf.exempt
def create_user():
    dict_body = request.get_json()

    user_ = user.User.query.filter_by(username=dict_body['username']).first()
    if user_:
        return jsonify({'status': 'fail', 'message': 'Username already exists.'}), 409

    user_ = user.User.query.filter_by(email=dict_body['email']).first()
    if not user_:
        data = user.User(
                         public_id=str(uuid.uuid4()),
                         email=dict_body['email'],
                         username=dict_body['username'],
                         password=dict_body['password'],
                         registered_on=datetime.datetime.utcnow(),
                         confirmed=False,
                         wage=dict_body['wage'],
                         )
        manual_session.add(data)
        manual_session.commit()

        send_confirm_email(data)
        return jsonify({'status': 'success', 'message': 'New user successfully created.'}), 200
    else:
        return jsonify({'status': 'fail', 'message': 'User already exists. Please Log in.'}), 409


@app.route(BASE_URL + 'check_user', methods=["POST"])
@csrf.exempt
def check_user():
    dict_body = request.get_json()

    user_ = user.User.query.filter_by(email=dict_body['email']).first()
    if user_ is None or not user_.check_password(dict_body['password']) or not user_.confirmed:
        pass
    else:
        return jsonify({'public_id': user_.public_id, 'email': user_.email}), 200
    return jsonify({'status': 'fail', 'message': 'Invalid username or password. Or not confirmed e-mail.'}), 409


@app.route(BASE_URL + '/upload_image', methods=["POST"])
@csrf.exempt
def upload_image():
    dict_body = request.get_json()  # convert body to dictionary
    user_public_id = dict_body['public_id']
    img_data = base64.b64decode(dict_body['b64_jpg'])

    # I assume you have a way of picking unique filenames
    dynamic_name = str(uuid.uuid4())
    file_name = DIRECTORY_TEMP_FILES + dynamic_name
    source_file = file_name + '.jpg'
    target_file = file_name + '.xml'

    with open(source_file, 'wb') as f:
        f.write(img_data)

    start_abbyy(target_file, source_file)
    start_check_process(target_file, user_public_id)
    os.remove(source_file)
    os.remove(target_file)
    return jsonify({'message': 'Someone get pack.'}), 200
