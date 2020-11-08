from flask import jsonify, request

from session import *
from project.models import organization


BASE_URL = '/api/v1/organization'


@app.route(BASE_URL + '/organizations', methods=['GET'])
def get_organizations():
    organizations = organization.Organization.get_all()
    results = []

    for organization_ in organizations:
        obj = {
            'id': organization_.id,
            'legal_name': organization_.legal_name,
            'legal_address': organization_.legal_address,
            'taxpayer_identification_number': organization_.taxpayer_identification_number,

        }
        results.append(obj)
    response = jsonify(results)
    response.status_code = 200
    return response


@app.route(BASE_URL + '/create_organization', methods=["POST"])
@csrf.exempt
def create_organization():
    dict_body = request.get_json()  # convert body to dictionary
    organize = organization.Organization(legal_name=dict_body['legal_name'],
                                         legal_address=dict_body['legal_address'],
                                         taxpayer_identification_number=dict_body['taxpayer_identification_number'],
                                         )
    manual_session.add(organize)
    manual_session.commit()
    return jsonify({'message': 'New organization successfully created.'}), 200
