import datetime


def get_label_week_day_by_date(date):
    if date.weekday() == 0:
        label_text = 'Понедельник (' + date.strftime('%d.%m') + ')'
    elif date.weekday() == 1:
        label_text = 'Вторник (' + date.strftime('%d.%m') + ')'
    elif date.weekday() == 2:
        label_text = 'Среда (' + date.strftime('%d.%m') + ')'
    elif date.weekday() == 3:
        label_text = 'Четверг (' + date.strftime('%d.%m') + ')'
    elif date.weekday() == 4:
        label_text = 'Пятница (' + date.strftime('%d.%m') + ')'
    elif date.weekday() == 5:
        label_text = 'Суббота (' + date.strftime('%d.%m') + ')'
    else:
        label_text = 'Воскресенье (' + date.strftime('%d.%m') + ')'
    return label_text


def get_label_week_day_by_double_date(date):
    if date.weekday() == 0:
        label_text = 'Понедельник (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    elif date.weekday() == 1:
        label_text = 'Вторник (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    elif date.weekday() == 2:
        label_text = 'Среда (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    elif date.weekday() == 3:
        label_text = 'Четверг (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    elif date.weekday() == 4:
        label_text = 'Пятница (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    elif date.weekday() == 5:
        label_text = 'Суббота (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    else:
        label_text = 'Воскресенье (' + date.strftime('%d.%m') + \
                     '/' + (date - datetime.timedelta(days=7)).strftime('%d.%m') + ')'
    return label_text
