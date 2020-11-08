import datetime

from flask import send_file, redirect, url_for, render_template
from flask_login import current_user

from project.models.abstract_product import AbstractProduct
from project.models.category_type import CategoryType
from project.models.check import Check
from project.models.product import Product
from project.models.product_category import ProductCategory
from project.models.user import User


def detail_information_word(public_id, type_select):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    if len(type_select) == 2:
        if datetime.datetime.strptime(type_select[0], '%Y-%m-%d') > \
                datetime.datetime.strptime(type_select[1], '%Y-%m-%d'):
            type_select[0], type_select[1] = type_select[1], type_select[0]
        checks = Check.get_all_by_range(
            user_.id, datetime.datetime.strptime(type_select[0], '%Y-%m-%d'),
            datetime.datetime.strptime(type_select[1], '%Y-%m-%d')
        )
        word_name = type_select[0] + "_" + type_select[1] + ".docx"
        title_label = "За " + type_select[0] + " по " + type_select[1]

    elif type_select == 'all_time':
        checks = Check.query.filter(Check.user_id == current_user.id).order_by(Check.date_time_of_purchase.asc()).all()
        word_name = "all_time.docx"
        title_label = 'За все время'

    elif type_select == 'week':
        checks = Check.get_all_by_week(user_.id)
        word_name = "week.docx"
        title_label = 'За неделю'

    elif type_select == "month":
        month_day = str(datetime.datetime.now().day + 1)
        current_date = str(datetime.datetime.now().year) + '-' + str(datetime.datetime.now().month)

        checks = Check.get_all_by_month_date(user_.id, current_date, month_day)
        word_name = "month.docx"
        title_label = 'За месяц'

    elif type_select == 'year':
        checks = Check.get_all_by_year(user_.id)
        word_name = "year.docx"
        title_label = 'За год'

    else:
        return render_template('errors/404.html'), 404

    total_price = 0
    dict_product_categories = {}
    dict_category_type = {}

    product_price = []
    abstract_products = []
    product_names = []
    category_types = []
    product_categories = []

    for check in checks:
        products = Product.get_all_check_products(check.id)
        for product in products:
            abstract_product = AbstractProduct.get_by_id(product.abstract_product_id)
            product_category = ProductCategory.get_by_id(abstract_product.product_category_id)
            category_type = CategoryType.get_by_id(product_category.category_type_id)

            total_price += float(product.product_price)
            product_price.append(product.product_price)
            abstract_products.append(abstract_product.product_name)
            product_names.append(product.product_name)
            category_types.append(product_category.product_category_name)
            product_categories.append(category_type.category_type_name)

            if dict_product_categories.get(category_type.category_type_name) is None:
                dict_product_categories[category_type.category_type_name] = float(product.product_price)
            else:
                dict_product_categories[category_type.category_type_name] = \
                    dict_product_categories[category_type.category_type_name] + float(product.product_price)

            if dict_category_type.get(product_category.product_category_name) is None:
                dict_category_type[product_category.product_category_name] = float(product.product_price)
            else:
                dict_category_type[product_category.product_category_name] = \
                    dict_category_type[product_category.product_category_name] + float(product.product_price)

    result_price = [float(item) for item in product_price]
    if len(abstract_products) < 1:
        return render_template('errors/403.html'), 403

    temp = []
    total_price = 0
    for i in range(len(abstract_products)):
        buf = {}
        buf['abstract_product'] = abstract_products[i]
        buf['category_type'] = category_types[i]
        buf['product_category'] = product_categories[i]
        buf['product_name'] = product_names[i]
        buf['product_price'] = str(product_price[i])
        total_price += float(product_price[i])
        temp.append(buf)

    from mailmerge import MailMerge

    template_1 = "template_detail_information.docx"

    cust = {
        'total_cost': str('{:.2f}'.format(total_price)),
    }

    document_3 = MailMerge(template_1)
    document_3.merge(**cust)
    document_3.merge_rows('product_name', temp)
    document_3.write(word_name)

    return send_file(word_name, as_attachment=True)


def detail_information_excel(public_id, type_select):
    user_ = User.query.filter_by(public_id=public_id).first_or_404()
    if current_user.is_anonymous or current_user.public_id != user_.public_id:
        return render_template('errors/404.html'), 404

    if len(type_select) == 2:
        if datetime.datetime.strptime(type_select[0], '%Y-%m-%d') > \
                datetime.datetime.strptime(type_select[1], '%Y-%m-%d'):
            type_select[0], type_select[1] = type_select[1], type_select[0]
        checks = Check.get_all_by_range(
            user_.id, datetime.datetime.strptime(type_select[0], '%Y-%m-%d'),
            datetime.datetime.strptime(type_select[1], '%Y-%m-%d')
        )
        excel_name = type_select[0] + "_" + type_select[1] + ".xls"
        title_label = "За " + type_select[0] + " по " + type_select[1]

    elif type_select == 'all_time':
        checks = Check.query.filter(Check.user_id == current_user.id).order_by(Check.date_time_of_purchase.asc()).all()
        excel_name = "all_time.xls"
        title_label = 'За все время'

    elif type_select == 'week':
        checks = Check.get_all_by_week(user_.id)
        excel_name = "week.xls"
        title_label = 'За неделю'

    elif type_select == "month":
        month_day = str(datetime.datetime.now().day + 1)
        current_date = str(datetime.datetime.now().year) + '-' + str(datetime.datetime.now().month)

        checks = Check.get_all_by_month_date(user_.id, current_date, month_day)
        excel_name = "month.xls"
        title_label = 'За месяц'

    elif type_select == 'year':
        checks = Check.get_all_by_year(user_.id)
        excel_name = "year.xls"
        title_label = 'За год'

    else:
        return render_template('errors/404.html'), 404

    total_price = 0
    dict_product_categories = {}
    dict_category_type = {}

    product_price = []
    abstract_products = []
    product_names = []
    category_types = []
    product_categories = []

    for check in checks:
        products = Product.get_all_check_products(check.id)
        for product in products:
            abstract_product = AbstractProduct.get_by_id(product.abstract_product_id)
            product_category = ProductCategory.get_by_id(abstract_product.product_category_id)
            category_type = CategoryType.get_by_id(product_category.category_type_id)

            total_price += float(product.product_price)
            product_price.append(product.product_price)
            abstract_products.append(abstract_product.product_name)
            product_names.append(product.product_name)
            category_types.append(product_category.product_category_name)
            product_categories.append(category_type.category_type_name)

            if dict_product_categories.get(category_type.category_type_name) is None:
                dict_product_categories[category_type.category_type_name] = float(product.product_price)
            else:
                dict_product_categories[category_type.category_type_name] = \
                    dict_product_categories[category_type.category_type_name] + float(product.product_price)

            if dict_category_type.get(product_category.product_category_name) is None:
                dict_category_type[product_category.product_category_name] = float(product.product_price)
            else:
                dict_category_type[product_category.product_category_name] = \
                    dict_category_type[product_category.product_category_name] + float(product.product_price)

    result_price = [float(item) for item in product_price]
    if len(abstract_products) < 1:
        return render_template('errors/403.html'), 403

    import pandas as pd
    df1 = pd.DataFrame({'№': [c + 1 for c in range(len(abstract_products))]})
    df2 = pd.DataFrame({'Название продукта': product_names})
    df3 = pd.DataFrame({'Цена': result_price})
    df4 = pd.DataFrame({'Продукт': abstract_products})
    df5 = pd.DataFrame({'Тип': category_types})
    df6 = pd.DataFrame({'Категория': product_categories})

    df7 = pd.DataFrame({'За все время'})
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

    worksheet.write('B2', title_label, after_header_format)
    worksheet.write('C2', total_price, after_header_format)

    worksheet.set_row(0, 21, table_format)

    worksheet.set_column('A:A', 3, cell_format)
    worksheet.set_column('B:B', 52)
    worksheet.set_column('C:C', 10, column_num_format)
    worksheet.set_column('D:E', 33)
    worksheet.set_column('F:F', 40)

    writer.save()

    return send_file(excel_name, as_attachment=True)
