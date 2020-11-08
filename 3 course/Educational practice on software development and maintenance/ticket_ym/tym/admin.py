from django.contrib import admin

from .models import Type_institution, Institution, Event, Type_payment
from .models import Type_ticket, Status_ticket, Payment, Ticket, User
admin.site.register(Type_institution)
admin.site.register(Institution)
admin.site.register(Event)
admin.site.register(Type_payment)
admin.site.register(Type_ticket)
admin.site.register(Status_ticket)
admin.site.register(Payment)
admin.site.register(Ticket)
admin.site.register(User)
