from datetime import datetime

from project.models.abstract_product import AbstractProduct
from project.models.check import Check
from project.models.organization import Organization
from project.models.product import Product
from project.models.user import User
from project.util.check_process.check_parser import DataCheck, check_parser, product_parser, highlight_abstract_product

from session import manual_session


# Direct check processing
def start_check_process(target_file, user_public_id):
    global data_check
    data_check = DataCheck()

    file_process(target_file, data_check)
    data_base_process(user_public_id)


def file_process(target_file, data_check):
    previous_line = ''
    text = ''
    f = open(target_file, 'rt')
    data_check.Products = {}
    data_check.AbstractProducts = []
    for line in f:
        line = ' '.join(line.split())
        line = check_parser(line, data_check)

        upper_text = line.upper()
        if upper_text.find('МАРШРУТ') != -1 or upper_text.find('ЭКСПРЕСС') != -1:
            data_check.Products['Маршрут'] = 0

        if data_check.Products.get('Маршрут'):
            if data_check.ResultPrice != 0:
                data_check.Products['Маршрут'] = data_check.ResultPrice
        else:
            line = product_parser(line, previous_line, data_check)

        text += line
        previous_line = line
    f.close()


def data_base_process(user_public_id):
    if data_check.Date == '':
        data_check.Date = datetime.now().strftime('%Y-%m-%d %H:%M:%S')

    try:
        if int(str(data_check.Date)[0:4]) > datetime.now().year:
            data_check.Date = datetime.now().strftime('%Y-%m-%d %H:%M:%S')
    except ValueError as err:
        print(err)

    db_organization = Organization.get_organization(data_check.LegalName, data_check.LegalAddress)
    if db_organization is None:
        if data_check.LegalName is None or data_check.LegalName == '':
            db_organization = Organization.query.filter(Organization.legal_name == 'Неопределено').first()
        else:
            if data_check.Unp == '':
                data_check.Unp = 111111111

            if len(data_check.LegalAddress) > 49:
                data_check.LegalAddress = data_check.LegalAddress[0:49]

            db_organization = Organization(
                legal_name=data_check.LegalName,
                legal_address=data_check.LegalAddress,
                taxpayer_identification_number=data_check.Unp)
            manual_session.add(db_organization)
            manual_session.commit()

    db_user = User.get_user_by_public_id(user_public_id)

    db_check = Check(
        date_time_of_purchase=data_check.Date,
        organization_id=db_organization.id,
        user_id=db_user.id
    )
    manual_session.add(db_check)
    manual_session.commit()

    if data_check.Products.get('Маршрут'):
        db_abstract_product = AbstractProduct.get_product('Маршрут')
        db_product = Product(
            product_name='Маршрут',
            product_price=data_check.ResultPrice,
            check_id=db_check.id,
            abstract_product_id=db_abstract_product.id
        )
        manual_session.add(db_product)
        manual_session.commit()
    else:
        for product_name in data_check.Products:
            if len(product_name) < 2:
                continue
            abstract_product = highlight_abstract_product(product_name)
            abstract_product = abstract_product.capitalize()

            db_abstract_product = AbstractProduct.get_product(abstract_product)

            if db_abstract_product is None:
                temp_str = abstract_product[0]
                i = 1
                while len(abstract_product) > i and abstract_product[i].islower():
                    abstract_product = abstract_product[i]
                    i += 1
                db_abstract_product = AbstractProduct.get_product(temp_str)

            if db_abstract_product is None:
                part_len = int(len(abstract_product) / 2)
                db_abstract_product = AbstractProduct.get_product(abstract_product[:part_len])

                if db_abstract_product is None:
                    db_abstract_product = AbstractProduct.get_product('Неопределено')

            current_price = float(data_check.Products[product_name])

            db_product = Product(
                product_name=product_name,
                product_price=current_price,
                check_id=db_check.id,
                abstract_product_id=db_abstract_product.id
            )
            manual_session.add(db_product)
            manual_session.commit()
