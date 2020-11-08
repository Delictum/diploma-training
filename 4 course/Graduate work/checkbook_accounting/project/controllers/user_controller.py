from __future__ import print_function

import calendar
import random
import uuid

import pytils as pytils
from dateutil.rrule import rrule, MONTHLY

from datetime import date, datetime, timedelta
from flask import render_template, flash, request, url_for, send_file, redirect
from flask_login import login_required, current_user

from config import *
from project.forms import EditProfileForm, AddCheckForm, AddManualCheckForm
from project.models.abstract_product import AbstractProduct
from project.models.category_type import CategoryType
from project.models.check import Check
from project.models.organization import Organization
from project.models.product import Product
from project.models.product_category import ProductCategory
from project.models.user import User
from sightengine.client import SightengineClient

from project.util.check_process.check_processing import start_check_process
from project.util.date_process import get_label_week_day_by_date, get_label_week_day_by_double_date
from project.util.export_data import detail_information_excel, detail_information_word
from project.util.image_process.image_processing import start_abbyy
from session import manual_session

BASE_URL = '/user/'
client = SightengineClient('{api_user}', '{api_secret}')


@app.route(BASE_URL + '<public_id>')
@login_required
def user(public_id):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()

    if current_user.is_anonymous or current_user.public_id == user_.public_id:
        page = request.args.get('page', 1, type=int)
        checks = Check.query. \
            filter(Check.user_id == user_.id). \
            order_by(Check.date_time_of_purchase.desc()). \
            paginate(
            page, CHECKS_PER_PAGE, False
        )

        current_month = datetime.today().month
        current_year = datetime.today().year
        month_date = str(current_year) + '-' + str(current_month)

        month_day = str(calendar.monthrange(current_year, current_month)[1])
        checks_by_month_date = Check.get_all_by_month_date(user_.id, month_date, month_day)

        spent = 0
        for check in checks_by_month_date:
            products_by_month_date = Product.get_all_check_products(check.id)
            for product in products_by_month_date:
                spent += product.product_price

        if user_.wage is not None:
            left = user_.wage - spent
            wage = user_.wage
        else:
            left = 0
            wage = 0

        spent_today = 0
        for check in Check.get_all_today(user_.id):
            products_by_today = Product.get_all_check_products(check.id)
            for product in products_by_today:
                spent_today += product.product_price

        next_url = url_for('user', public_id=user_.public_id, page=checks.next_num) \
            if checks.has_next else None
        prev_url = url_for('user', public_id=user_.public_id, page=checks.prev_num) \
            if checks.has_prev else None

        return render_template('user/profile.html',
                               user=user_,
                               wage=wage,
                               checks=checks.items,
                               next_url=next_url,
                               prev_url=prev_url,
                               spent=spent,
                               left=left,
                               spent_today=spent_today
                               )
    return render_template('errors/404.html'), 404


@app.route(BASE_URL + '<public_id>/' + '<check_id>')
@login_required
def check_details(public_id, check_id):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if not current_user.is_anonymous and current_user.public_id == user_.public_id:
        db_organizations = Organization.get_all()
        organizations = []

        db_abstract_products = AbstractProduct.get_all()
        abstract_products = []

        db_product_categories = ProductCategory.get_all()
        product_categories = []

        db_category_types = CategoryType.get_all()
        category_types = []

        for organization in db_organizations:
            organizations.append(organization.legal_name)

        for abstract_product in db_abstract_products:
            abstract_products.append(abstract_product.product_name)

        for category_type in db_category_types:
            product_categories.append(category_type.category_type_name)

        for product_category in db_product_categories:
            category_types.append(product_category.product_category_name)

        products = Product.query.filter_by(check_id=check_id).all()
        check = Check.query.filter_by(id=check_id).first_or_404()
        organization = Organization.query.filter_by(id=check.organization_id).first_or_404()

        total_cost = 0
        for product in products:
            total_cost += product.product_price

        form = AddCheckForm()

        return render_template('user/check_details.html',
                               check=check,
                               products=products,
                               organization=organization,
                               total_cost=total_cost,
                               abstract_products=abstract_products,
                               product_categories=product_categories,
                               category_types=category_types,
                               user=user_,
                               form=form,
                               )
    return render_template('errors/404.html'), 404


@app.route(BASE_URL + 'edit_profile', methods=['GET', 'POST'])
@login_required
def edit_profile():
    form = EditProfileForm()
    if form.validate_on_submit():
        current_user.username = form.username.data
        current_user.wage = form.wage.data
        db.session.commit()
        flash('Your changes have been saved.')
        return user(current_user.public_id)
    elif request.method == 'GET':
        form.username.data = current_user.username
        form.wage.data = current_user.wage
    return render_template('user/edit_profile.html', title='Редактирование профиля', form=form)


@app.route(BASE_URL + '<public_id>/detail_information_all_time')
def detail_information_all_time(public_id):
    return detail_information(public_id, 'all_time')


@app.route(BASE_URL + '<public_id>/detail_information_week')
def detail_information_week(public_id):
    return detail_information(public_id, 'week')


@app.route(BASE_URL + '<public_id>/detail_information_month')
def detail_information_month(public_id):
    return detail_information(public_id, 'month')


@app.route(BASE_URL + '<public_id>/detail_information_year')
def detail_information_year(public_id):
    return detail_information(public_id, 'year')


@app.route(BASE_URL + '<public_id>/<start_date>_<final_date>', methods=['GET', 'POST'])
@csrf.exempt
def detail_information_range(public_id, start_date, final_date):
    return detail_information(public_id, 'range', start_date, final_date)


def detail_information(public_id, sample_type, start_date=None, final_date=None):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    if sample_type == 'all_time':
        legend = 'За все время'
        checks = Check.query.filter(Check.user_id == current_user.id).order_by(Check.date_time_of_purchase.asc()).all()
    elif sample_type == 'week':
        legend = 'За неделю'
        checks = Check.get_all_by_week(user_.id)
    elif sample_type == 'month':
        legend = 'За месяц'
        checks = Check.get_all_by_month(user_.id)
    elif sample_type == 'year':
        legend = 'За год'
        checks = Check.get_all_by_year(user_.id)
    elif sample_type == 'range':
        start_date = datetime.strptime(start_date, '%Y-%m-%d %H:%M:%S')
        final_date = datetime.strptime(final_date, '%Y-%m-%d %H:%M:%S')

        if final_date < start_date:
            start_date, final_date = final_date, start_date

        if start_date.year == final_date.year:
            sample_type = 'month' if start_date.month == final_date.month else 'year'

        legend = 'За ' + str(datetime.date(start_date)) + ' по ' + str(datetime.date(final_date))
        checks = Check.get_all_by_range(user_.id,
                                        start_date,
                                        final_date)

    checks_amount = []
    dates = []

    current_sample_type_date = 0
    total_cost = 0
    product_amount = 0

    dict_category_types = {}
    dict_product_categories = {}
    dict_abstract_products = {}

    max_cost_product = ''
    max_cost_price = -1
    min_cost_product = ''
    min_cost_price = -1
    first_month = 1

    for check in checks:
        if current_sample_type_date == 0:
            if sample_type == 'all_time':
                current_sample_type_date = check.date_time_of_purchase.year

            elif sample_type == 'week' or sample_type == 'month':
                current_sample_type_date = check.date_time_of_purchase

            elif sample_type == 'year':
                current_sample_type_date = check.date_time_of_purchase.month

            first_month = check.date_time_of_purchase.month

        if sample_type == 'all_time':
            if current_sample_type_date != check.date_time_of_purchase.year:
                checks_amount.append(product_amount)
                dates.append(current_sample_type_date)

                current_sample_type_date = check.date_time_of_purchase.year
                product_amount = 0

        elif sample_type == 'week' or sample_type == 'month':
            if current_sample_type_date != check.date_time_of_purchase:
                checks_amount.append(product_amount)
                dates.append(current_sample_type_date)

                current_sample_type_date = check.date_time_of_purchase
                product_amount = 0

        if sample_type == 'year':
            if current_sample_type_date != check.date_time_of_purchase.month:
                checks_amount.append(product_amount)
                dates.append(current_sample_type_date)

                current_sample_type_date = check.date_time_of_purchase.month
                product_amount = 0

        products = Product.get_all_check_products(check.id)
        for product in products:
            if max_cost_price and min_cost_price == -1:
                max_cost_price = min_cost_price = float(product.product_price)
                min_cost_product = max_cost_product = product.product_name

            if max_cost_price < float(product.product_price):
                max_cost_product = product.product_name
                max_cost_price = product.product_price

            if min_cost_price > float(product.product_price):
                min_cost_product = product.product_name
                min_cost_price = product.product_price

            product_amount += product.product_price
            total_cost += product.product_price

            abstract_product = AbstractProduct.get_by_id(product.abstract_product_id)
            product_category = ProductCategory.get_by_id(abstract_product.product_category_id)
            category_type = CategoryType.get_by_id(product_category.category_type_id)

            if dict_category_types.get(category_type.category_type_name) is None:
                dict_category_types[category_type.category_type_name] = [{
                    product_category.product_category_name: [{
                        abstract_product.product_name: product.product_price
                    }]}]
            else:
                for item in dict_category_types[category_type.category_type_name]:
                    for type_product in item.keys():
                        if product_category.product_category_name == type_product:
                            list_product_category = dict_category_types[category_type.category_type_name].copy()
                            for i in list_product_category:
                                if i.get(type_product):
                                    list_abstract_product = i[type_product].copy()
                                    list_abstract_product.append({
                                        abstract_product.product_name: product.product_price
                                    })
                                    list_product_category.remove(i)

                                    for j in i.get(type_product):
                                        if j.get(abstract_product.product_name):
                                            dict_abstract_product = {
                                                abstract_product.product_name: j[abstract_product.product_name] +
                                                                               product.product_price
                                            }

                                            for ij in range(len(list_abstract_product)):
                                                if list_abstract_product[ij].get(abstract_product.product_name):
                                                    list_abstract_product[ij] = dict_abstract_product
                                            list_abstract_product = [
                                                dict(t) for t in set([tuple(d.items()) for d in list_abstract_product])
                                            ]

                                    list_product_category_copy = list_product_category.copy()
                                    list_product_category_copy.append({type_product: list_abstract_product})
                                    dict_category_types[category_type.category_type_name] = list_product_category_copy

                if any(product_category.product_category_name in s.keys()
                       for s in dict_category_types[category_type.category_type_name]):
                    list_product_category = dict_category_types[category_type.category_type_name].copy()
                    list_product_category.append({
                        product_category.product_category_name: [{
                            abstract_product.product_name: product.product_price
                        }]})
                else:
                    list_category_type = dict_category_types[category_type.category_type_name].copy()
                    list_category_type.append({
                        product_category.product_category_name: [{
                            abstract_product.product_name: product.product_price
                        }]})
                    if list_category_type is not None:
                        dict_category_types[category_type.category_type_name] = list_category_type

            if dict_abstract_products.get(abstract_product.product_name) is None:
                dict_abstract_products[abstract_product.product_name] = product.product_price
            else:
                dict_abstract_products[abstract_product.product_name] = \
                    dict_abstract_products[abstract_product.product_name] + product.product_price

    values_pie = []
    labels_pie = []
    category_type_cost = 0

    values_radar = []
    type_product_cost = 0

    last_category_type = ''
    last_product_category = ''

    total_costs_category_type = {}
    total_costs_product_category = {}

    for category_type in dict_category_types.keys():
        labels_pie.append(category_type)
        if category_type_cost != 0:
            total_costs_category_type[last_category_type] = category_type_cost
            values_pie.append(category_type_cost)
            category_type_cost = 0

        print(category_type)
        last_category_type = category_type

        for product_categories in dict_category_types.values():
            if dict_category_types[category_type] == product_categories:
                for list_product_category in product_categories:
                    for product_category in list_product_category:
                        if type_product_cost != 0:
                            total_costs_product_category[last_product_category] = type_product_cost
                            values_radar.append(tuple((last_category_type, last_product_category, type_product_cost)))
                            type_product_cost = 0

                        print(product_category)
                        last_product_category = product_category

                        for abstract_products in list_product_category.values():
                            if abstract_products == list_product_category[product_category]:
                                for dict_abstract_product in abstract_products:
                                    for abstract_product in dict_abstract_product:
                                        print(abstract_product)
                                        print(dict_abstract_product[abstract_product])
                                        category_type_cost += float(dict_abstract_product[abstract_product])
                                        type_product_cost += float(dict_abstract_product[abstract_product])

    if current_sample_type_date != 0:
        checks_amount.append(product_amount)
        dates.append(current_sample_type_date)

    if sample_type == 'week':
        counter = 0
        new_dates = []
        new_amounts = []

        for i in range(7):
            new_dates.append(date.today() + timedelta(days=-date.today().weekday() + i))

        if len(dates) != 7:
            for i in range(7):

                if (len(dates) == counter or datetime.date(dates[counter]) != date.today() +
                    timedelta(days=-date.today().weekday() + i)) and date.today() >= \
                        date.today() + timedelta(days=-date.today().weekday() + i):
                    new_amounts.append(0)
                elif date.today() < date.today() + timedelta(days=-date.today().weekday() + i):
                    pass
                else:
                    new_amounts.append(checks_amount[counter])
                    counter += 1

            checks_amount = new_amounts
            dates = new_dates

        for i in range(len(dates)):
            dates[i] = get_label_week_day_by_date(dates[i])

    elif sample_type == 'month':
        counter = 0
        new_dates = []
        new_amounts = []

        if len(dates) == 0:
            if start_date is not None:
                dates.append(start_date)
            else:
                dates.append(datetime.today())
            checks_amount.append(0)

        days_in_month = calendar.monthrange(datetime.today().year, datetime.today().month)[1]
        if start_date is not None:
            days_in_month = final_date.day - start_date.day + 1

        for i in range(days_in_month):
            if start_date is not None:
                new_dates.append(i + start_date.day)
            else:
                new_dates.append(i + 1)

        if len(dates) != days_in_month:
            for i in range(days_in_month):

                if start_date is not None and (len(dates) == counter or dates[counter].day != i + start_date.day) \
                        and date.today().day > i + start_date.day:
                    new_amounts.append(0)
                elif start_date is not None and date.today().day < i + start_date.day:
                    pass
                elif start_date is not None:
                    new_amounts.append(checks_amount[counter])
                    counter += 1

                elif (len(dates) == counter or dates[counter].day != i + 1) and date.today().day > i:
                    new_amounts.append(0)
                elif date.today().day <= i:
                    pass
                else:
                    new_amounts.append(checks_amount[counter])
                    counter += 1

            checks_amount = new_amounts
            dates = new_dates

    elif sample_type == 'year':
        counter = 0
        new_amounts = []

        month_in_year = 12
        if start_date is not None:
            month_in_year = final_date.month - start_date.month + 1

        if len(dates) != month_in_year:
            for i in range(month_in_year):
                if start_date is not None and (len(dates) == counter or dates[counter] != i + start_date.month) \
                        and date.today().month > i + start_date.month:
                    new_amounts.append(0)
                elif start_date is not None and date.today().month < i + start_date.month:
                    pass
                elif start_date is not None and len(dates) != counter:
                    new_amounts.append(checks_amount[counter])
                    counter += 1

                elif (len(dates) == counter or dates[counter] != i + 1) and date.today().month > i:
                    new_amounts.append(0)
                elif date.today().month <= i:
                    pass
                else:
                    new_amounts.append(checks_amount[counter])
                    counter += 1

            checks_amount = new_amounts
            dates = []

        for i in range(month_in_year):
            if start_date is not None:
                dates.append(pytils.dt.ru_strftime(u"%b", inflected=True,
                                                   date=date(datetime.today().year, i + start_date.month, 1))
                             + ' (' + str(i + start_date.month) + ')')
            else:
                dates.append(pytils.dt.ru_strftime(u"%b", inflected=True,
                                                   date=date(datetime.today().year, i + 1, 1))
                             + ' (' + str(i + 1) + ')')

    values_pie.append(category_type_cost)
    values_radar.append(tuple((last_category_type, last_product_category, type_product_cost)))

    total_costs_category_type[last_category_type] = category_type_cost
    total_costs_product_category[last_product_category] = type_product_cost

    result_wage = 0
    if user_.wage is None:
        result_wage = 'Укажите Вашу заработную плату'
        result_month = 1
    elif len(dates) > 0 and sample_type == 'all_time':
        result_month = len([dt for dt in rrule(MONTHLY,
                                               dtstart=datetime(dates[0], first_month, 1),
                                               until=datetime(datetime.now().year, datetime.now().month, 1))]) - 2
        print(result_month)
        result_wage = user_.wage * result_month
    else:
        result_wage = user_.wage
        result_month = 1

    max_cost_category_type = -1
    max_cost_category_type_name = ''
    min_cost_category_type = -1
    min_cost_category_type_name = ''

    for item in total_costs_category_type:
        if max_cost_category_type == -1:
            max_cost_category_type = min_cost_category_type = total_costs_category_type[item]
            min_cost_category_type_name = max_cost_category_type_name = item

        if max_cost_category_type < total_costs_category_type[item]:
            max_cost_category_type_name = item
            max_cost_category_type = total_costs_category_type[item]

        if min_cost_category_type > total_costs_category_type[item]:
            min_cost_category_type_name = item
            min_cost_category_type = total_costs_category_type[item]

    print(total_costs_category_type)

    max_cost_product_category = -1
    max_cost_product_category_name = ''
    min_cost_product_category = -1
    min_cost_product_category_name = ''

    for item in total_costs_product_category:
        if max_cost_product_category == -1:
            max_cost_product_category = min_cost_product_category = total_costs_product_category[item]
            min_cost_product_category_name = max_cost_product_category_name = item

        if max_cost_product_category < total_costs_product_category[item]:
            max_cost_product_category_name = item
            max_cost_product_category = total_costs_product_category[item]

        if min_cost_category_type > total_costs_product_category[item]:
            min_cost_product_category_name = item
            min_cost_product_category = total_costs_product_category[item]

    interested_facts = [max_cost_product, max_cost_price, min_cost_product, min_cost_price, result_wage, result_month,
                        max_cost_category_type_name, max_cost_category_type, min_cost_category_type_name,
                        min_cost_category_type, max_cost_product_category_name, max_cost_product_category,
                        min_cost_product_category_name, min_cost_product_category, ]

    return render_template('user/detail_information.html',
                           user=user_,
                           total_cost=total_cost,
                           values=checks_amount,
                           labels=dates,
                           legend=legend,
                           dict_abstract_products=dict_abstract_products,
                           dict_category_types=dict_category_types,
                           interested_facts=interested_facts,
                           labels_pie=labels_pie,
                           values_pie=values_pie,
                           values_radar=values_radar,
                           total_costs_category_type=total_costs_category_type,
                           total_costs_product_category=total_costs_product_category,
                           sample_type=sample_type,
                           )


@app.route(BASE_URL + '<public_id>/' + 'add-check', methods=['GET', 'POST'])
@csrf.exempt
def add_check(public_id):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    form = AddCheckForm()

    db_organizations = Organization.get_all()
    organizations = []

    db_abstract_products = AbstractProduct.get_all()
    abstract_products = []

    db_product_categories = ProductCategory.get_all()
    product_categories = []

    db_category_types = CategoryType.get_all()
    category_types = []

    for organization in db_organizations:
        organizations.append(organization.legal_name)

    for abstract_product in db_abstract_products:
        abstract_products.append(abstract_product.product_name)

    for category_type in db_category_types:
        product_categories.append(category_type.category_type_name)

    for product_category in db_product_categories:
        category_types.append(product_category.product_category_name)

    if request.method == 'POST':
        if 'date_time' in request.form:
            add_manual_check(current_user.public_id)
            return render_template('user/add_check.html',
                                   form=form,
                                   dateTime=datetime.now(),
                                   organizations=organizations,
                                   abstract_products=abstract_products,
                                   product_categories=product_categories,
                                   category_types=category_types)

        files = request.files.getlist('file[]')
        filename = request.files['file[]']

        if filename.filename == '':
            return render_template('user/add_check.html',
                                   form=form,
                                   dateTime=datetime.now(),
                                   organizations=organizations,
                                   abstract_products=abstract_products,
                                   product_categories=product_categories,
                                   category_types=category_types)
        for file in files:
            dynamic_name = str(uuid.uuid4())
            file_name = DIRECTORY_TEMP_FILES + dynamic_name
            source_file = file_name + '.jpg'
            target_file = file_name + '.xml'

            file.save(source_file)

            start_abbyy(target_file, source_file)
            start_check_process(target_file, current_user.public_id)

            os.remove(source_file)
            os.remove(target_file)
        return render_template('user/add_check.html',
                               form=form,
                               dateTime=datetime.now(),
                               organizations=organizations,
                               abstract_products=abstract_products,
                               product_categories=product_categories,
                               category_types=category_types)
    elif request.method == 'GET':
        return render_template('user/add_check.html',
                               form=form,
                               dateTime=datetime.now(),
                               organizations=organizations,
                               abstract_products=abstract_products,
                               product_categories=product_categories,
                               category_types=category_types)


@app.route(BASE_URL + '<public_id>/' + 'add-check', methods=['GET', 'POST'])
@csrf.exempt
def add_manual_check(public_id):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    date_time = request.form.get('date_time')
    organization = request.form.get('organization')
    abstract_products = request.form.getlist('abstract_product[]')
    category_types = request.form.getlist('category_type[]')
    product_categories = request.form.getlist('product_category[]')
    product_names = request.form.getlist('product_name[]')
    product_price = request.form.getlist('product_price[]')

    if organization is None or organization == '':
        db_organization = Organization.query.filter(Organization.legal_name == 'Неопределено').first()
    else:
        db_organization = Organization.query.filter(Organization.legal_name == organization).first()

    if db_organization is None:
        db_organization = Organization(legal_name=organization)
        manual_session.add(db_organization)
        manual_session.commit()

    db_check = Check(
        date_time_of_purchase=date_time,
        organization_id=db_organization.id,
        user_id=current_user.id
    )
    manual_session.add(db_check)
    manual_session.commit()

    product_amount = len(abstract_products)
    for i in range(product_amount):
        db_category_type = CategoryType.get_by_name(product_categories[i])
        db_product_category = ProductCategory.get_by_name(category_types[i])

        if db_product_category is None or db_product_category.category_type_id != db_category_type.id:
            db_product_category = ProductCategory(
                product_category_name=category_types[i],
                category_type_id=db_category_type.id
            )
            manual_session.add(db_product_category)
            manual_session.commit()

        db_abstract_product = AbstractProduct.query.filter(AbstractProduct.product_name == abstract_products[i]).first()
        if db_abstract_product is None or db_abstract_product.product_category_id != db_product_category.id:
            db_abstract_product = AbstractProduct(
                product_name=abstract_products[i],
                product_category_id=db_product_category.id
            )
            manual_session.add(db_abstract_product)
            manual_session.commit()

        db_product = Product(
            product_name=product_names[i],
            product_price=product_price[i],
            check_id=db_check.id,
            abstract_product_id=db_abstract_product.id
        )
        manual_session.add(db_product)
        manual_session.commit()


@app.route(BASE_URL + '<public_id>/<check_id>/excel', methods=['GET', 'POST'])
@csrf.exempt
def check_excel(public_id, check_id):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    date_time = request.form.get('date_time')
    organization = request.form.get('organization')
    abstract_products = request.form.getlist('abstract_product[]')
    category_types = request.form.getlist('category_type[]')
    product_categories = request.form.getlist('product_category[]')
    product_names = request.form.getlist('product_name[]')
    product_price = request.form.getlist('product_price[]')

    if request.form.get('word') == 'on':
        temp = []
        total_price = 0
        for i in range(len(abstract_products)):
            buf = {}
            buf['abstract_product'] = abstract_products[i]
            buf['category_type'] = category_types[i]
            buf['product_category'] = product_categories[i]
            buf['product_name'] = product_names[i]
            buf['product_price'] = product_price[i]
            total_price += float(product_price[i])
            temp.append(buf)

        from mailmerge import MailMerge

        word_name = check_id + ".docx"
        template_1 = "template.docx"

        if organization is None:
            organization = ' '
        cust = {
            'organization': organization,
            'date': date_time,
            'total_cost': str('{:.2f}'.format(total_price)),
        }

        document_3 = MailMerge(template_1)
        document_3.merge(**cust)
        document_3.merge_rows('product_name', temp)
        document_3.write(word_name)

        return send_file(word_name, as_attachment=True)

    excel_name = check_id + ".xls"

    dict_product_categories = {}
    dict_category_type = {}

    total_price = 0
    for num in range(0, len(abstract_products)):
        total_price += float(product_price[num])

        if dict_product_categories.get(product_categories[num]) is None:
            dict_product_categories[product_categories[num]] = float(product_price[num])
        else:
            dict_product_categories[product_categories[num]] = \
                dict_product_categories[product_categories[num]] + float(product_price[num])

        if dict_category_type.get(category_types[num]) is None:
            dict_category_type[category_types[num]] = float(product_price[num])
        else:
            dict_category_type[category_types[num]] = \
                dict_category_type[category_types[num]] + float(product_price[num])

    result_price = [float(item) for item in product_price]

    import pandas as pd
    df1 = pd.DataFrame({'№': [c + 1 for c in range(len(abstract_products))]})
    df2 = pd.DataFrame({'Название продукта': product_names})
    df3 = pd.DataFrame({'Цена': result_price})
    df4 = pd.DataFrame({'Продукт': abstract_products})
    df5 = pd.DataFrame({'Тип': category_types})
    df6 = pd.DataFrame({'Категория': product_categories})

    df7 = pd.DataFrame({'Дата': [date_time]})
    df8 = pd.DataFrame({'Организация': [organization]})
    df9 = pd.DataFrame({'Итого': [total_price]})

    df10 = pd.DataFrame({'Тип': [c for c in dict_category_type.keys()]})
    df11 = pd.DataFrame({'Цена': [c for c in dict_category_type.values()]})

    df12 = pd.DataFrame({'Категория': [c for c in dict_product_categories.keys()]})
    df13 = pd.DataFrame({'Цена': [c for c in dict_product_categories.values()]})

    writer = pd.ExcelWriter(excel_name, engine='xlsxwriter')

    df1.to_excel(writer, sheet_name='Sheet1', startrow=19, index=False)
    df2.to_excel(writer, sheet_name='Sheet1', startrow=19, startcol=1, index=False)
    df3.to_excel(writer, sheet_name='Sheet1', startrow=19, startcol=2, index=False)
    df4.to_excel(writer, sheet_name='Sheet1', startrow=19, startcol=3, index=False)
    df5.to_excel(writer, sheet_name='Sheet1', startrow=19, startcol=4, index=False)
    df6.to_excel(writer, sheet_name='Sheet1', startrow=19, startcol=5, index=False)

    df7.to_excel(writer, sheet_name='Sheet1', startcol=1, index=False)
    df8.to_excel(writer, sheet_name='Sheet1', startcol=3, index=False)
    df9.to_excel(writer, sheet_name='Sheet1', startcol=2, index=False)

    df10.to_excel(writer, sheet_name='Sheet1', startrow=21 + len(abstract_products), startcol=4, index=False)
    df11.to_excel(writer, sheet_name='Sheet1', startrow=21 + len(abstract_products), startcol=5, index=False)

    df12.to_excel(writer, sheet_name='Sheet1', startrow=21 + len(abstract_products), startcol=1, index=False)
    df13.to_excel(writer, sheet_name='Sheet1', startrow=21 + len(abstract_products), startcol=2, index=False)

    workbook = writer.book
    worksheet = writer.sheets['Sheet1']

    chart1 = workbook.add_chart({'type': 'pie',
                                 'subtype': 'smooth'})
    chart1.add_series({'categories': ['Sheet1', 20, 3, len(df2) + 19, 3],
                       'values': ['Sheet1', 20, 2, len(df2) + 19, 2]})
    worksheet.insert_chart('A4', chart1)

    chart2 = workbook.add_chart({'type': 'pie',
                                 'subtype': 'smooth'})
    chart2.add_series({'categories': [
        'Sheet1',
        22 + len(abstract_products),
        4,
        len(df2) + 21 + len(dict_category_type),
        4,
    ],
        'values': [
            'Sheet1',
            22 + len(abstract_products),
            5,
            len(df2) + 21 + len(dict_category_type),
            5,
        ]})
    worksheet.insert_chart('D4', chart2)

    chart3 = workbook.add_chart({'type': 'pie',
                                 'subtype': 'smooth'})
    chart3.add_series({'categories': [
        'Sheet1',
        22 + len(abstract_products),
        1,
        len(df2) + 21 + len(dict_product_categories),
        1,
    ],
        'values': [
            'Sheet1',
            22 + len(abstract_products),
            2,
            len(df2) + 21 + len(dict_product_categories),
            2,
        ]})
    worksheet.insert_chart('F4', chart3)

    cell_format = workbook.add_format({'italic': True})
    column_num_format = workbook.add_format()
    column_num_format.set_num_format('#,##0.00')

    table_format = workbook.add_format()
    table_format.set_border(6)
    table_format.set_border_color('white')
    table_format.set_font_color('gray')

    header_format = workbook.add_format()
    after_header_format = workbook.add_format()

    header_format.set_pattern(1)  # This is optional when using a solid fill.
    header_format.set_bg_color('black')
    header_format.set_align('center')
    header_format.set_align('vcenter')
    header_format.set_font_color('white')
    header_format.set_border(6)
    header_format.set_border_color('white')
    header_format.set_font_name('Times New Roman')
    header_format.set_font_size(14)

    after_header_format.set_align('center')
    after_header_format.set_align('vcenter')
    after_header_format.set_bg_color('gray')
    after_header_format.set_border(13)
    after_header_format.set_border_color('black')
    after_header_format.set_font_name('Times New Roman')
    after_header_format.set_font_size(12)

    worksheet.write('B1', 'Дата', header_format)
    worksheet.write('C1', 'Итого', header_format)
    worksheet.write('D1', 'Организация', header_format)

    worksheet.write('B2', date_time, after_header_format)
    worksheet.write('C2', total_price, after_header_format)
    worksheet.write('D2', organization, after_header_format)

    worksheet.set_row(0, 21, table_format)

    worksheet.set_column('A:A', 3, cell_format)
    worksheet.set_column('B:B', 52)
    worksheet.set_column('C:C', 10, column_num_format)
    worksheet.set_column('D:E', 33)
    worksheet.set_column('F:F', 40)

    writer.save()

    return send_file(excel_name, as_attachment=True)


@app.route(BASE_URL + '<public_id>/excel_all_time', methods=['GET', 'POST'])
@csrf.exempt
def detail_excel_all_time(public_id):
    return detail_information_excel(public_id, 'all_time')


@app.route(BASE_URL + '<public_id>/excel_week', methods=['GET', 'POST'])
@csrf.exempt
def detail_excel_week(public_id):
    return detail_information_excel(public_id, 'week')


@app.route(BASE_URL + '<public_id>/excel_month', methods=['GET', 'POST'])
@csrf.exempt
def detail_excel_month(public_id):
    return detail_information_excel(public_id, 'month')


@app.route(BASE_URL + '<public_id>/excel_year', methods=['GET', 'POST'])
@csrf.exempt
def detail_excel_year(public_id):
    return detail_information_excel(public_id, 'year')


@app.route(BASE_URL + '/<public_id>/excel_range', methods=['GET', 'POST'])
@csrf.exempt
def detail_range(public_id):
    start_date = request.form.get('start_date')
    final_date = request.form.get('final_date')
    if request.form.get('sample_type') == 'on':
        return redirect(url_for('detail_information_range',
                                public_id=public_id,
                                sample_type='range',
                                start_date=datetime.strptime(start_date, '%Y-%m-%d'),
                                final_date=datetime.strptime(final_date, '%Y-%m-%d'),
                                ))
    if request.form.get('word') == 'on':
        return detail_information_word(public_id, [start_date, final_date])
    return detail_information_excel(public_id, [start_date, final_date])


@app.route(BASE_URL + '<public_id>/word_all_time', methods=['GET', 'POST'])
@csrf.exempt
def detail_word_all_time(public_id):
    return detail_information_word(public_id, 'all_time')


@app.route(BASE_URL + '<public_id>/word_week', methods=['GET', 'POST'])
@csrf.exempt
def detail_word_week(public_id):
    return detail_information_word(public_id, 'week')


@app.route(BASE_URL + '<public_id>/word_month', methods=['GET', 'POST'])
@csrf.exempt
def detail_word_month(public_id):
    return detail_information_word(public_id, 'month')


@app.route(BASE_URL + '<public_id>/word_year', methods=['GET', 'POST'])
@csrf.exempt
def detail_word_year(public_id):
    return detail_information_word(public_id, 'year')


@app.route(BASE_URL + '<public_id>/compare_information_week', methods=['GET', 'POST'])
@csrf.exempt
def compare_information_week(public_id):
    return compare_information(public_id, 'week')


@app.route(BASE_URL + '<public_id>/compare_information_month', methods=['GET', 'POST'])
@csrf.exempt
def compare_information_month(public_id):
    return compare_information(public_id, 'month')


@app.route(BASE_URL + '<public_id>/compare_information_year', methods=['GET', 'POST'])
@csrf.exempt
def compare_information_year(public_id):
    return compare_information(public_id, 'year')


@app.route(BASE_URL + '<public_id>/compare_range', methods=['GET', 'POST'])
@csrf.exempt
def compare_information_range(public_id):
    start_date_first_period = request.form.get('start_date_first_period')
    final_date_first_period = request.form.get('final_date_first_period')
    start_date_second_period = request.form.get('start_date_second_period')
    final_date_second_period = request.form.get('final_date_second_period')

    return compare_information(
                                public_id=public_id,
                                sample_type='range',
                                start_date_first_period=start_date_first_period,
                                final_date_first_period=final_date_first_period,
                                start_date_second_period=start_date_second_period,
                                final_date_second_period=final_date_second_period,
                                )


def compare_information(public_id, sample_type, start_date_first_period=None, final_date_first_period=None,
                        start_date_second_period=None, final_date_second_period=None):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    if sample_type == 'week':
        legend_first_period = 'За текущую неделю'
        legend_second_period = 'За прошлую неделю'
        checks = Check.get_all_by_double_week(user_.id)

        start_date_second_period = date.today() - timedelta(days=date.today().weekday() + 7)
        final_date_second_period = date.today() - timedelta(days=date.today().weekday())

        start_date_first_period = date.today() - timedelta(days=date.today().weekday())
        final_date_first_period = date.today() + timedelta(days=-date.today().weekday() + 7)

    elif sample_type == 'month':
        legend_first_period = 'За текущий месяц'
        legend_second_period = 'За прошлый месяц'
        checks = Check.get_all_by_double_month(user_.id)

        if datetime.now().month == 1:
            last_period_month = 12
            last_period_year = datetime.today().year - 1
        else:
            last_period_month = datetime.today().month
            last_period_year = datetime.today().year

        start_date_second_period = date.today() - timedelta(
            days=date.today().day + calendar.monthrange(last_period_year, last_period_month)[1])
        final_date_second_period = date.today() - timedelta(days=date.today().day)

        start_date_first_period = date.today() - timedelta(days=date.today().day - 1)
        final_date_first_period = date.today() + timedelta(
            days=calendar.monthrange(last_period_year, last_period_month)[1] - date.today().day)

    elif sample_type == 'year':
        legend_first_period = 'За текущий год'
        legend_second_period = 'За прошлый год'
        checks = Check.get_all_by_double_year(user_.id)

        start_date_second_period = datetime.date(datetime.strptime(str(datetime.now().year - 1) + '-01-01', '%Y-%m-%d'))
        final_date_second_period = datetime.date(datetime.strptime(str(datetime.now().year - 1) + '-12-31', '%Y-%m-%d'))

        start_date_first_period = datetime.date(datetime.strptime(str(datetime.now().year) + '-01-01', '%Y-%m-%d'))
        final_date_first_period = datetime.date(datetime.strptime(str(datetime.now().year) + '-12-31', '%Y-%m-%d'))

    elif sample_type == 'range':
        start_date_first_period = datetime.date(datetime.strptime(start_date_first_period, '%Y-%m-%d'))
        final_date_first_period = datetime.date(datetime.strptime(final_date_first_period, '%Y-%m-%d'))

        start_date_second_period = datetime.date(datetime.strptime(start_date_second_period, '%Y-%m-%d'))
        final_date_second_period = datetime.date(datetime.strptime(final_date_second_period, '%Y-%m-%d'))

        if final_date_first_period < start_date_first_period:
            start_date_first_period, final_date_first_period = final_date_first_period, start_date_first_period

        if start_date_first_period.year == final_date_first_period.year and \
                start_date_second_period.year == final_date_second_period.year:
            sample_type = 'month' if start_date_first_period.month == final_date_first_period.month and \
                                     start_date_second_period.month == final_date_second_period.month else 'year'

        legend_first_period = 'За ' + str(start_date_first_period) + \
                              ' по ' + str(final_date_first_period)
        legend_second_period = 'За ' + str(start_date_second_period) + \
                               ' по ' + str(final_date_second_period)
        checks = Check.get_all_by_double_range(user_.id,
                                               start_date_first_period,
                                               final_date_first_period,
                                               start_date_second_period,
                                               final_date_second_period, )

    print('start_date_f_p ', start_date_first_period, 'final_date_f_p ', final_date_first_period)
    print('start_date_s_p ', start_date_second_period, 'final_date_s_p ', final_date_second_period)

    checks_amount = []
    dates = []

    current_sample_type_date = 0
    total_cost = 0
    product_amount = 0

    dict_category_types = {}
    dict_product_categories = {}
    dict_abstract_products = {}

    max_cost_product = ''
    max_cost_price = -1
    min_cost_product = ''
    min_cost_price = -1
    first_month = 1

    for check in checks:
        if current_sample_type_date == 0:
            current_sample_type_date = check.date_time_of_purchase
            first_month = check.date_time_of_purchase.month

        if sample_type == 'week' or sample_type == 'month':
            if current_sample_type_date != check.date_time_of_purchase:
                checks_amount.append(product_amount)
                dates.append(current_sample_type_date)

                current_sample_type_date = check.date_time_of_purchase
                product_amount = 0

        if sample_type == 'year':
            if current_sample_type_date.month != check.date_time_of_purchase.month or \
                    current_sample_type_date.year != check.date_time_of_purchase.year:
                checks_amount.append(product_amount)
                dates.append(current_sample_type_date)

                current_sample_type_date = check.date_time_of_purchase
                product_amount = 0

        products = Product.get_all_check_products(check.id)
        for product in products:
            if max_cost_price and min_cost_price == -1:
                max_cost_price = min_cost_price = float(product.product_price)
                min_cost_product = max_cost_product = product.product_name

            if max_cost_price < float(product.product_price):
                max_cost_product = product.product_name
                max_cost_price = product.product_price

            if min_cost_price > float(product.product_price):
                min_cost_product = product.product_name
                min_cost_price = product.product_price

            product_amount += product.product_price
            total_cost += product.product_price

            abstract_product = AbstractProduct.get_by_id(product.abstract_product_id)
            product_category = ProductCategory.get_by_id(abstract_product.product_category_id)
            category_type = CategoryType.get_by_id(product_category.category_type_id)

            if dict_category_types.get(category_type.category_type_name) is None:
                if datetime.date(check.date_time_of_purchase) >= start_date_first_period:
                    dict_category_types[category_type.category_type_name] = [{
                        product_category.product_category_name: [{
                            abstract_product.product_name: product.product_price
                        }]}]
                else:
                    dict_category_types[category_type.category_type_name] = [{
                        product_category.product_category_name: [{
                            '2' + abstract_product.product_name: product.product_price
                        }]}]

            else:
                for item in dict_category_types[category_type.category_type_name]:
                    for type_product in item.keys():
                        if product_category.product_category_name == type_product:
                            list_product_category = dict_category_types[category_type.category_type_name].copy()
                            for i in list_product_category:
                                if i.get(type_product):
                                    list_abstract_product = i[type_product].copy()

                                    if datetime.date(check.date_time_of_purchase) >= start_date_first_period:
                                        list_abstract_product.append({
                                            abstract_product.product_name: product.product_price
                                        })
                                    else:
                                        list_abstract_product.append({
                                            '2' + abstract_product.product_name: product.product_price
                                        })

                                    list_product_category.remove(i)

                                    for j in i.get(type_product):
                                        if j.get(abstract_product.product_name):
                                            dict_abstract_product = {
                                                abstract_product.product_name: j[abstract_product.product_name] +
                                                                               product.product_price
                                            }

                                            for ij in range(len(list_abstract_product)):
                                                if list_abstract_product[ij].get(abstract_product.product_name):
                                                    list_abstract_product[ij] = dict_abstract_product
                                            list_abstract_product = [
                                                dict(t) for t in set([tuple(d.items()) for d in list_abstract_product])
                                            ]

                                        if j.get('2' + abstract_product.product_name):
                                            dict_abstract_product = {
                                                '2' + abstract_product.product_name:
                                                    j['2' + abstract_product.product_name] + product.product_price
                                            }

                                            for ij in range(len(list_abstract_product)):
                                                if list_abstract_product[ij].get('2' + abstract_product.product_name):
                                                    list_abstract_product[ij] = dict_abstract_product
                                            list_abstract_product = [
                                                dict(t) for t in set([tuple(d.items()) for d in list_abstract_product])
                                            ]

                                    list_product_category_copy = list_product_category.copy()
                                    list_product_category_copy.append({type_product: list_abstract_product})
                                    dict_category_types[category_type.category_type_name] = list_product_category_copy

                if any(product_category.product_category_name in s.keys()
                       for s in dict_category_types[category_type.category_type_name]):
                    list_product_category = dict_category_types[category_type.category_type_name].copy()

                    if datetime.date(check.date_time_of_purchase) >= start_date_first_period:
                        list_product_category.append({
                            product_category.product_category_name: [{
                                abstract_product.product_name: product.product_price
                            }]})
                    else:
                        list_product_category.append({
                            product_category.product_category_name: [{
                                '2' + abstract_product.product_name: product.product_price
                            }]})

                else:
                    list_category_type = dict_category_types[category_type.category_type_name].copy()

                    if datetime.date(check.date_time_of_purchase) >= start_date_first_period:
                        list_category_type.append({
                            product_category.product_category_name: [{
                                abstract_product.product_name: product.product_price
                            }]})
                    else:
                        list_category_type.append({
                            product_category.product_category_name: [{
                                '2' + abstract_product.product_name: product.product_price
                            }]})

                    if list_category_type is not None:
                        dict_category_types[category_type.category_type_name] = list_category_type

            if dict_abstract_products.get(abstract_product.product_name) is None:
                dict_abstract_products[abstract_product.product_name] = product.product_price
            else:
                dict_abstract_products[abstract_product.product_name] = \
                    dict_abstract_products[abstract_product.product_name] + product.product_price

            if dict_abstract_products.get('2' + abstract_product.product_name) is None:
                dict_abstract_products['2' + abstract_product.product_name] = product.product_price
            else:
                dict_abstract_products['2' + abstract_product.product_name] = \
                    dict_abstract_products['2' + abstract_product.product_name] + product.product_price

    total_cost_first_period = 0
    total_cost_second_period = 0

    values_pie = []
    values_pie_first_period = []
    values_pie_second_period = []

    labels_pie = []
    category_type_cost = 0
    category_type_cost_first_period = 0
    category_type_cost_second_period = 0

    values_radar = []
    values_radar_first_period = []
    values_radar_second_period = []

    type_product_cost = 0
    type_product_cost_first_period = 0
    type_product_cost_second_period = 0

    last_category_type = ''
    last_category_type_first_period = ''
    last_category_type_second_period = ''

    last_product_category = ''
    last_type_product_first_period = ''
    last_type_product_second_period = ''

    total_costs_category_type = {}
    total_costs_product_category = {}

    max_cost_category_type_first_period = -1
    max_cost_category_type_name_first_period = ''
    min_cost_category_type_first_period = -1
    min_cost_category_type_name_first_period = ''

    max_cost_category_type_second_period = -1
    max_cost_category_type_name_second_period = ''
    min_cost_category_type_second_period = -1
    min_cost_category_type_name_second_period = ''

    max_cost_type_product_first_period = -1
    max_cost_type_product_name_first_period = ''
    min_cost_type_product_first_period = -1
    min_cost_type_product_name_first_period = ''

    max_cost_type_product_second_period = -1
    max_cost_type_product_name_second_period = ''
    min_cost_type_product_second_period = -1
    min_cost_type_product_name_second_period = ''

    for category_type in dict_category_types.keys():
        labels_pie.append(category_type)
        if category_type_cost != 0:
            total_costs_category_type[last_category_type] = category_type_cost
            values_pie.append(category_type_cost)

            category_type_cost = 0

        if category_type_cost_first_period != 0:
            values_pie_first_period.append(category_type_cost_first_period)

            if max_cost_category_type_first_period == -1:
                max_cost_category_type_first_period = min_cost_category_type_first_period = \
                    category_type_cost_first_period
                max_cost_category_type_name_first_period = min_cost_category_type_name_first_period = \
                    last_category_type_first_period

            if max_cost_category_type_first_period < category_type_cost_first_period:
                max_cost_category_type_first_period = category_type_cost_first_period
                max_cost_category_type_name_first_period = last_category_type_first_period

            if min_cost_category_type_first_period > category_type_cost_first_period:
                min_cost_category_type_first_period = category_type_cost_first_period
                min_cost_category_type_name_first_period = last_category_type_first_period

            category_type_cost_first_period = 0

        if category_type_cost_second_period != 0:
            values_pie_second_period.append(category_type_cost_second_period)

            if max_cost_category_type_second_period == -1:
                max_cost_category_type_second_period = min_cost_category_type_second_period = \
                    category_type_cost_second_period
                max_cost_category_type_name_second_period = min_cost_category_type_name_second_period = \
                    last_category_type_second_period

            if max_cost_category_type_second_period < category_type_cost_second_period:
                max_cost_category_type_second_period = category_type_cost_second_period
                max_cost_category_type_name_second_period = last_category_type_second_period

            if min_cost_category_type_second_period > category_type_cost_second_period:
                min_cost_category_type_second_period = category_type_cost_second_period
                min_cost_category_type_name_second_period = last_category_type_second_period

            category_type_cost_second_period = 0

        print(category_type)
        last_category_type = category_type

        for product_categories in dict_category_types.values():
            if dict_category_types[category_type] == product_categories:
                for list_product_category in product_categories:
                    for product_category in list_product_category:

                        if type_product_cost != 0:
                            total_costs_product_category[last_product_category] = type_product_cost
                            values_radar.append(tuple((last_category_type, last_product_category, type_product_cost)))
                            type_product_cost = 0

                        if type_product_cost_first_period != 0:
                            values_radar_first_period.append(tuple((last_category_type_first_period,
                                                                    last_type_product_first_period,
                                                                    type_product_cost_first_period)))
                            type_product_cost = 0

                            if max_cost_type_product_first_period == -1:
                                max_cost_type_product_first_period = min_cost_type_product_first_period = \
                                    type_product_cost_first_period
                                max_cost_type_product_name_first_period = min_cost_type_product_name_first_period = \
                                    last_type_product_first_period

                            if max_cost_type_product_first_period < type_product_cost_first_period:
                                max_cost_type_product_first_period = type_product_cost_first_period
                                max_cost_type_product_name_first_period = last_type_product_first_period

                            if min_cost_type_product_first_period > type_product_cost_first_period:
                                min_cost_type_product_first_period = type_product_cost_first_period
                                min_cost_type_product_name_first_period = last_type_product_first_period

                            type_product_cost_first_period = 0

                        elif type_product_cost_first_period == 0:
                            values_radar_first_period.append(tuple((last_category_type,
                                                                    last_product_category,
                                                                    0)))

                        if type_product_cost_second_period != 0:
                            values_radar_second_period.append(tuple((last_category_type_second_period,
                                                                     last_type_product_second_period,
                                                                     type_product_cost_second_period)))

                            if max_cost_type_product_second_period == -1:
                                max_cost_type_product_second_period = min_cost_type_product_second_period = \
                                    type_product_cost_second_period
                                max_cost_type_product_name_second_period = min_cost_type_product_name_second_period = \
                                    last_type_product_second_period

                            if max_cost_type_product_second_period < type_product_cost_second_period:
                                max_cost_type_product_second_period = type_product_cost_second_period
                                max_cost_type_product_name_second_period = last_type_product_second_period

                            if min_cost_type_product_second_period > type_product_cost_second_period:
                                min_cost_type_product_second_period = type_product_cost_second_period
                                min_cost_type_product_name_second_period = last_type_product_second_period

                            type_product_cost_second_period = 0

                        elif type_product_cost_second_period == 0:
                            values_radar_second_period.append(tuple((last_category_type,
                                                                     last_product_category,
                                                                     0)))

                        print(product_category)
                        last_product_category = product_category

                        for abstract_products in list_product_category.values():
                            if abstract_products == list_product_category[product_category]:
                                for dict_abstract_product in abstract_products:
                                    for abstract_product in dict_abstract_product:
                                        print(abstract_product)
                                        print(dict_abstract_product[abstract_product])
                                        category_type_cost += float(dict_abstract_product[abstract_product])
                                        type_product_cost += float(dict_abstract_product[abstract_product])

                                        if abstract_product[0] == '2':
                                            total_cost_second_period += float(dict_abstract_product[abstract_product])

                                            last_category_type_second_period = category_type
                                            category_type_cost_second_period += \
                                                float(dict_abstract_product[abstract_product])

                                            last_type_product_second_period = product_category
                                            type_product_cost_second_period += \
                                                float(dict_abstract_product[abstract_product])

                                        else:
                                            total_cost_first_period += float(dict_abstract_product[abstract_product])

                                            last_category_type_first_period = category_type
                                            category_type_cost_first_period += \
                                                float(dict_abstract_product[abstract_product])

                                            last_type_product_first_period = product_category
                                            type_product_cost_first_period += \
                                                float(dict_abstract_product[abstract_product])

                        if type_product_cost_first_period != 0:
                            if max_cost_type_product_first_period == -1:
                                max_cost_type_product_first_period = min_cost_type_product_first_period = \
                                    type_product_cost_first_period
                                max_cost_type_product_name_first_period = min_cost_type_product_name_first_period = \
                                    last_type_product_first_period

                            if max_cost_type_product_first_period < type_product_cost_first_period:
                                max_cost_type_product_first_period = type_product_cost_first_period
                                max_cost_type_product_name_first_period = last_type_product_first_period

                            if min_cost_type_product_first_period > type_product_cost_first_period:
                                min_cost_type_product_first_period = type_product_cost_first_period
                                min_cost_type_product_name_first_period = last_type_product_first_period

                        if type_product_cost_second_period != 0:
                            if max_cost_type_product_second_period == -1:
                                max_cost_type_product_second_period = min_cost_type_product_second_period = \
                                    type_product_cost_second_period
                                max_cost_type_product_name_second_period = min_cost_type_product_name_second_period = \
                                    last_type_product_second_period

                            if max_cost_type_product_second_period < type_product_cost_second_period:
                                max_cost_type_product_second_period = type_product_cost_second_period
                                max_cost_type_product_name_second_period = last_type_product_second_period

                            if min_cost_type_product_second_period > type_product_cost_second_period:
                                min_cost_type_product_second_period = type_product_cost_second_period
                                min_cost_type_product_name_second_period = last_type_product_second_period

    if category_type_cost_first_period != 0:
        if max_cost_category_type_first_period == -1:
            max_cost_category_type_first_period = min_cost_category_type_first_period = \
                category_type_cost_first_period
            max_cost_category_type_name_first_period = min_cost_category_type_name_first_period = \
                last_category_type_first_period

        if max_cost_category_type_first_period < category_type_cost_first_period:
            max_cost_category_type_first_period = category_type_cost_first_period
            max_cost_category_type_name_first_period = last_category_type_first_period

        if min_cost_category_type_first_period > category_type_cost_first_period:
            min_cost_category_type_first_period = category_type_cost_first_period
            min_cost_category_type_name_first_period = last_category_type_first_period

    if category_type_cost_second_period != 0:
        if max_cost_category_type_second_period == -1:
            max_cost_category_type_second_period = min_cost_category_type_second_period = \
                category_type_cost_second_period
            max_cost_category_type_name_second_period = min_cost_category_type_name_second_period = \
                last_category_type_second_period

        if max_cost_category_type_second_period < category_type_cost_second_period:
            max_cost_category_type_second_period = category_type_cost_second_period
            max_cost_category_type_name_second_period = last_category_type_second_period

        if min_cost_category_type_second_period > category_type_cost_second_period:
            min_cost_category_type_second_period = category_type_cost_second_period
            min_cost_category_type_name_second_period = last_category_type_second_period

    if current_sample_type_date != 0:
        checks_amount.append(product_amount)
        dates.append(current_sample_type_date)

    if sample_type == 'week':
        counter = 0
        new_dates = []
        checks_amount_first_period = []
        checks_amount_second_period = []

        for i in range(7):
            new_dates.append(date.today() + timedelta(days=-date.today().weekday() + i))

        if len(dates) != 14:
            for i in range(7):
                if datetime.date(dates[counter]) < date.today() - timedelta(days=date.today().weekday() + 1):
                    counter += 1
                else:
                    break

            for i in range(7):
                print(checks_amount[counter])
                if (datetime.date(dates[counter]) != date.today() +
                    timedelta(days=-date.today().weekday() + i)) and date.today() >= \
                        date.today() + timedelta(days=-date.today().weekday() + i):
                    checks_amount_first_period.append(0)
                elif date.today() < date.today() + timedelta(days=-date.today().weekday() + i):
                    pass
                else:
                    checks_amount_first_period.append(checks_amount[counter])
                    counter += 1

            preview_counter = counter
            counter = 0

            for i in range(7):
                if preview_counter == counter or datetime.date(dates[counter]) != date.today() + \
                    timedelta(days=-date.today().weekday() + i - 7) and date.today() >= \
                        date.today() + timedelta(days=-date.today().weekday() + i):
                    checks_amount_second_period.append(0)
                elif date.today() < date.today() + timedelta(days=-date.today().weekday() + i - 7):
                    pass
                else:
                    checks_amount_second_period.append(checks_amount[counter])
                    counter += 1
        dates = new_dates

        for i in range(len(dates)):
            dates[i] = get_label_week_day_by_double_date(dates[i])

    elif sample_type == 'month':
        counter = 0
        new_dates = []
        checks_amount_first_period = []
        checks_amount_second_period = []

        if datetime.now().month == 1:
            last_period_month = 12
            last_period_year = datetime.today().year - 1
        else:
            last_period_month = datetime.today().month - 1
            last_period_year = datetime.today().year

        days_in_month_first_period = calendar.monthrange(datetime.today().year, datetime.today().month)[1]
        days_in_month_second_period = calendar.monthrange(last_period_year, last_period_month)[1]
        print(start_date_first_period)

        if days_in_month_first_period > days_in_month_second_period:
            for i in range(days_in_month_first_period):
                new_dates.append(i + 1)
        else:
            for i in range(days_in_month_second_period):
                new_dates.append(i + 1)

        if len(dates) != days_in_month_first_period + days_in_month_second_period:
            for i in range(len(dates)):
                if datetime.date(dates[counter]).month < date.today().month:
                    counter += 1
                else:
                    break

            for i in range(days_in_month_first_period):
                if len(dates) == counter or datetime.date(dates[counter]).day != i + 1 and date.today().day > i:
                    checks_amount_first_period.append(0)
                elif date.today().day < i + 1:
                    pass
                else:
                    checks_amount_first_period.append(checks_amount[counter])
                    counter += 1

            preview_counter = counter
            counter = 0

            for i in range(days_in_month_second_period):
                if preview_counter == counter or datetime.date(dates[counter]).day != i + 1:
                    checks_amount_second_period.append(0)
                else:
                    checks_amount_second_period.append(checks_amount[counter])
                    counter += 1
        dates = new_dates

    elif sample_type == 'year':
        counter = 0
        checks_amount_first_period = []
        checks_amount_second_period = []

        month_in_year = 12

        if len(dates) != month_in_year * 2:
            for i in range(len(dates)):
                if datetime.date(dates[counter]).year != date.today().year:
                    counter += 1
                else:
                    break

            for i in range(month_in_year):
                if len(dates) == counter or datetime.date(dates[counter]).month != i + 1 and date.today().month > i:
                    checks_amount_first_period.append(0)
                elif date.today().month < i + 1:
                    pass
                else:
                    checks_amount_first_period.append(checks_amount[counter])
                    counter += 1

            preview_counter = counter
            counter = 0

            for i in range(month_in_year):
                if preview_counter == counter or datetime.date(dates[counter]).month != i + 1:
                    checks_amount_second_period.append(0)
                else:
                    checks_amount_second_period.append(checks_amount[counter])
                    counter += 1
        dates = []

        for i in range(month_in_year):
            dates.append(pytils.dt.ru_strftime(u"%b", inflected=True,
                                               date=date(datetime.today().year, i + 1, 1))
                         + ' (' + str(i + 1) + ')')

    values_pie.append(category_type_cost)
    values_pie_first_period.append(category_type_cost_first_period)
    values_pie_second_period.append(category_type_cost_second_period)

    print(values_pie_first_period)
    print(values_pie_second_period)

    values_radar.append(tuple((last_category_type, last_product_category, type_product_cost)))
    values_radar_first_period.append(tuple((last_category_type_first_period,
                                            last_type_product_first_period,
                                            type_product_cost_first_period)))
    values_radar_second_period.append(tuple((last_category_type_second_period,
                                             last_type_product_second_period,
                                             type_product_cost_second_period)))

    total_costs_category_type[last_category_type] = category_type_cost
    total_costs_product_category[last_product_category] = type_product_cost

    result_wage = 0
    if user_.wage is None:
        result_wage = 'Укажите Вашу заработную плату'
        result_month = 1
    elif len(dates) > 0 and sample_type == 'all_time':
        result_month = len([dt for dt in rrule(MONTHLY,
                                               dtstart=datetime(dates[0], first_month, 1),
                                               until=datetime(datetime.now().year, datetime.now().month, 1))]) - 2
        print(result_month)
        result_wage = user_.wage * result_month
    else:
        result_wage = user_.wage
        result_month = 1

    max_cost_category_type = -1
    max_cost_category_type_name = ''
    min_cost_category_type = -1
    min_cost_category_type_name = ''

    for item in total_costs_category_type:
        if max_cost_category_type == -1:
            max_cost_category_type = min_cost_category_type = total_costs_category_type[item]
            min_cost_category_type_name = max_cost_category_type_name = item

        if max_cost_category_type < total_costs_category_type[item]:
            max_cost_category_type_name = item
            max_cost_category_type = total_costs_category_type[item]

        if min_cost_category_type > total_costs_category_type[item]:
            min_cost_category_type_name = item
            min_cost_category_type = total_costs_category_type[item]

    print(total_costs_category_type)

    max_cost_product_category = -1
    max_cost_product_category_name = ''
    min_cost_product_category = -1
    min_cost_product_category_name = ''

    for item in total_costs_product_category:
        if max_cost_product_category == -1:
            max_cost_product_category = min_cost_product_category = total_costs_product_category[item]
            min_cost_product_category_name = max_cost_product_category_name = item

        if max_cost_product_category < total_costs_product_category[item]:
            max_cost_product_category_name = item
            max_cost_product_category = total_costs_product_category[item]

        if min_cost_category_type > total_costs_product_category[item]:
            min_cost_product_category_name = item
            min_cost_product_category = total_costs_product_category[item]

    interested_facts = [max_cost_product, max_cost_price, min_cost_product, min_cost_price, result_wage, result_month,
                        max_cost_category_type_name, max_cost_category_type, min_cost_category_type_name,
                        min_cost_category_type, max_cost_product_category_name, max_cost_product_category,
                        min_cost_product_category_name, min_cost_product_category, total_cost_first_period,
                        total_cost_second_period, max_cost_category_type_first_period,
                        max_cost_category_type_name_first_period, min_cost_category_type_first_period,
                        min_cost_category_type_name_first_period, max_cost_category_type_second_period,
                        max_cost_category_type_name_second_period, min_cost_category_type_second_period,
                        min_cost_category_type_name_second_period, max_cost_type_product_first_period,
                        max_cost_type_product_name_first_period, min_cost_type_product_first_period,
                        min_cost_type_product_name_first_period, max_cost_type_product_second_period,
                        max_cost_type_product_name_second_period, min_cost_type_product_second_period,
                        min_cost_type_product_name_second_period]

    return render_template('user/compare_information.html',
                           user=user_,
                           total_cost=total_cost,
                           values=checks_amount,
                           checks_amount_first_period=checks_amount_first_period,
                           checks_amount_second_period=checks_amount_second_period,
                           labels=dates,
                           legend_first_period=legend_first_period,
                           legend_second_period=legend_second_period,
                           dict_abstract_products=dict_abstract_products,
                           dict_category_types=dict_category_types,
                           interested_facts=interested_facts,
                           labels_pie=labels_pie,

                           values_pie=values_pie,
                           values_pie_first_period=values_pie_first_period,
                           values_pie_second_period=values_pie_second_period,

                           values_radar=values_radar,
                           values_radar_first_period=values_radar_first_period,
                           values_radar_second_period=values_radar_second_period,

                           total_costs_category_type=total_costs_category_type,
                           total_costs_product_category=total_costs_product_category,
                           sample_type=sample_type,
                           )
