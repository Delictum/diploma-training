import re
import dateutil.parser as date_parser

from datetime import datetime

from project.models import organization, check, product


class DataCheck:
    Date = ''
    Unp = ''
    LegalName = ''
    LegalAddress = ''
    Products = {}
    ResultPrice = 0
    AbstractProducts = []


def check_parser(line, data_check):
    upper_text = line.upper()

    if data_check.LegalName == '':
        data_check.LegalName, line = legal_name_parse(line)

    if data_check.LegalAddress == '':
        data_check.LegalAddress, line = legal_address_parse(line)

    if data_check.Unp == '':
        data_check.Unp, line = unp_parse(upper_text, line)

    if data_check.Date == '':
        data_check.Date, line = date_parse(upper_text, line)

    if line.find('ИТОГ') != -1 or line.find('К ОПЛАТЕ') != -1:
        result_price = re.sub(r'\s+', ' ', line)
        match = re.search(r'(\d+[.\',]\d{2})',
                          result_price[0:len(result_price) - 1])
        try:
            if match is not None:
                data_str = match.group(1)
                data_check.ResultPrice = data_str
        except ValueError as err:
            print(err)

    return remove_rudiments(line)


def product_parser(line, previous_line, data_check):
    price = product_price_parse(line)
    if price != line:
        price.replace(',', '.')
        product_name = product_price_parse(previous_line)
        if product_name != previous_line:
            product_name = line[:len(line)-len(price)]

        product_name.replace('\n', '')

        if product_name.upper().find('ДИСКОНТ') != -1 or product_name.upper().find('СКИДКА') != -1\
                or product_name.upper().find('ОПЛАЧЕНО') != -1 or product_name.upper().find('СДАЧА') != -1\
                or product_name.upper().find('СЕРТИФИКАТ') != -1:
            return line

        product_name = product_name.strip()
        data_check.Products[product_name] = price
    return line


def highlight_abstract_product(product_name):
    product_name = ''.join([i for i in product_name if not i.isdigit()])
    product_name = product_name.strip()

    abstract_product = product_name[:product_name.find(' ')]
    return abstract_product


def product_price_parse(line):
    result_price = re.sub(r'\s+', ' ', line[::-1])
    match = re.search(r'(\d{2}[.\', ]\d+)',
                      result_price[:len(result_price) - 1])
    try:
        if match is not None:
            price_str = match.group(1)
            for ch in [',', '\'', ' ']:
                if ch in price_str:
                    price_str = price_str.replace(ch, '.')
            return price_str[::-1]
    except ValueError as err:
        print(err)
    return line


def date_parse(upper_text, line):
    if upper_text.find("ДАТА") != -1:
        data_str = upper_text[upper_text.rfind("ДАТА") + 4:upper_text.rfind("ДАТА") + 15]

        if upper_text.find("ВРЕМЯ") != -1:
            data_str += upper_text[upper_text.rfind("ВРЕМЯ") + 5:upper_text.rfind("ВРЕМЯ") + 12]

    else:
        data_str = ''.join(
            i for i in upper_text if
            (i.isdigit() or i == '/' or i == '\'' or i == ':' or i == '.' or i == ' ' or i == '-'))

        data_str = re.sub(r'\s+', ' ', data_str)
        match = re.search(r'(\d{2}[/.:-]\d{2}[/.:-]\d{2,4}([ -—]\d{2}[:]\d{2}(\d{2})*)*)',
                          data_str[0:len(data_str) - 1])
        try:
            if match is not None:
                data_str = match.group(1)
            else:
                return '', line
        except ValueError:
            return '', line

    try:
        data_str = date_parser.parse(data_str, fuzzy=True, dayfirst=True)
        if data_str.year < 2000:
            return '', line
    except ValueError:
        return '', line

    return data_str, ''


def unp_parse(upper_text, line):
    unp_str = ''
    if upper_text.find("УНП") != -1:
        unp_str = upper_text[upper_text.rfind("УНП") + 3:upper_text.rfind("УНП") + 13]

    unp_str = ''.join(i for i in unp_str if (i.isdigit()))

    if unp_str == '':
        return '', line

    return unp_str, ''


def legal_name_parse(line):
    legal_name_str = ''
    legal_abbreviation = ['ЧТУП', 'ООО', 'ОАО', 'ЗАО', 'ОДО', 'ЧУП', ]
    for abbreviation in legal_abbreviation:
        legal_name_str = search_organization(abbreviation, line)
        if legal_name_str != '':
            try:
                int(legal_name_str[4:7])
                continue
            except ValueError:
                pass
            legal_name_str = legal_name_str[0:legal_name_str.find('\n')]
            break

    if legal_name_str == '':
        return '', line

    return legal_name_str.strip(), ''


def search_organization(abbreviation, text):
    if text.find(abbreviation) != -1:
        return text[text.find(abbreviation):]
    return ''


def legal_address_parse(line):
    upper_text = line.upper()
    legal_address_str = ''

    if upper_text.find("ПР.") != -1 or upper_text.find("УЛ.") != -1 or upper_text.find("Г.") != -1 \
            or upper_text.find("ПР-Т") != -1 or upper_text.find("ПР-КТ.") != -1 or upper_text.find("Г.") != -1:
        legal_address_str = None

    if legal_address_str is not None:
        return '', line

    return line.strip(), ''


def remove_rudiments(line):
    if line.find('ЗВД') != -1 or line.find('СКНО') != -1 or line.find('РЕГ') != -1 or line.find('КАССА') != -1 or\
            line.find('ЧЕК') != -1 or line.find('Кассир') != -1 or line.find('Р/Н') != -1 or line.find('ККМ') != -1\
            or line.find('ИНН') != -1 or line.find('ДОК') != -1 or line.find('ККТ') != -1 or line.find('ПРИХОД') != -1\
            or line.find('ФН') != -1 or line.find('ЭКЗ') != -1 or line.find('ФП') != -1 or line.find('ФД') != -1\
            or line.find('ЗН') != -1 or line.find('ЗТО ЛЕГКО! ЭТО ПОЛЕЗНО!') != -1 or line.find('НАЛИЧНЫ') != -1\
            or line.find('СДАЧА') != -1 or line.find('СЧАСТЛИВОГО ПУТИ') != -1 or line.find('СПАСИБО ЗА ПОКУПКУ') != -1\
            or line.find('СТОИМОСТЬ') != -1 or line.find('ПРОДАЖА') != -1 or line.find('ВСЕГО') != -1:
        return ''
    return line
