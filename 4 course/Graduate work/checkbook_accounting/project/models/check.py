from datetime import datetime, timedelta

from config import *

from sqlalchemy import or_, and_


class Check(db.Model):
    __tablename__ = 'check'
    id = db.Column(db.Integer, primary_key=True)
    date_time_of_purchase = db.Column(db.DateTime, unique=False, nullable=True)
    organization_id = db.Column(db.Integer, db.ForeignKey('organization.id'))
    user_id = db.Column(db.INTEGER, db.ForeignKey('user.id'))

    def __repr__(self):
        return '<Check %r>' % self.date_time_of_purchase

    @staticmethod
    def get_all():
        return Check.query.all()

    @staticmethod
    def get_all_user_checks(user_id):
        return Check.query.filter(Check.user_id == user_id).all()

    @staticmethod
    def get_by_id(user_id):
        return Check.query.filter(Check.id == user_id).first()

    @staticmethod
    def get_all_by_week(user_id):
        weekday = datetime.today().weekday()
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      datetime.date(datetime.now()) - timedelta(days=weekday), datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_month_date(user_id, date, month_day):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(date + '-01', date + '-' + month_day)
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_month(user_id):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      str(datetime.now().year) + '-' +
                                      str(datetime.now().month) + '-01', datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_year(user_id):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      str(datetime.now().year) + '-01-01', datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_today(user_id):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(datetime.date(datetime.now()), datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_range(user_id, start_date, final_date):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(start_date, final_date)
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_double_week(user_id):
        weekday = datetime.today().weekday()
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      datetime.date(datetime.now()) - timedelta(days=weekday + 7), datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_double_month(user_id):
        if datetime.now().month == 1:
            datetime_last_period = str(datetime.now().year - 1) + '-12-01'
        else:
            datetime_last_period = str(datetime.now().year) + '-' + str(datetime.now().month - 1) + '-01'
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      datetime_last_period, datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_double_year(user_id):
        return Check.query.filter(Check.user_id == user_id,
                                  Check.date_time_of_purchase.between(
                                      str(datetime.now().year - 1) + '-01-01', datetime.now())
                                  ).order_by(Check.date_time_of_purchase.asc()).all()

    @staticmethod
    def get_all_by_double_range(user_id,
                                start_date_first_period,
                                final_date_first_period,
                                start_date_second_period,
                                final_date_second_period,
                                ):
        return Check.query.filter(or_(and_(Check.user_id == user_id,
                                           Check.date_time_of_purchase.between(start_date_first_period,
                                                                               final_date_first_period)),
                                      and_(Check.user_id == user_id,
                                           Check.date_time_of_purchase.between(start_date_second_period,
                                                                               final_date_second_period)))
                                  ).order_by(Check.date_time_of_purchase.asc()).all()
