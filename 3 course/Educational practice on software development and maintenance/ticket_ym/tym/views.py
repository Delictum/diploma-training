from django.shortcuts import render, get_object_or_404
from django.http import HttpResponse, HttpResponseRedirect

from .models import Institution, Type_institution, Event, Type_payment
from .models import Ticket, Type_ticket, Status_ticket
from django.db import models

def index(request):    
    num_type_institution = Type_institution.objects.all().count()
    num_institution = Institution.objects.all().count()
    num_event = Event.objects.all().count()
    num_type_payment = Type_payment.objects.all().count()
    return render(
	request, 
	'index.html', 
	context={'num_institution':num_institution, 
	'num_type_institution':num_type_institution,
        'num_event':num_event, 'num_type_payment':num_type_payment},
	)


def type_institutions(request):
    type_institutions = Type_institution.objects.order_by('type_institution')
    return render(
	request, 
	'type_institutions.html', 
	context={'type_institutions':type_institutions}
	)


def institutions(request, id):
    institution_id = Type_institution.objects.get(id=id)
    institutions = Institution.objects.filter(type_institution=institution_id)
    return render(
	request, 
	'institutions.html', 
	context={'institutions':institutions}
	)


def events(request, id):
    event_id = Institution.objects.get(id=id)
    events = Event.objects.filter(institution=event_id)
    return render(
	request, 
	'events.html', 
	context={'events':events}
	)


def tickets(request, id):
    ticket_id = Event.objects.get(id=id)
    tickets = Ticket.objects.filter(event=ticket_id)
    type_tickets = Type_ticket.objects.order_by('type_ticket')
    type_tickets_count = Type_ticket.objects.count()
    return render(
	request, 
	'tickets.html', 
	context={'tickets':tickets, 'type_tickets':type_tickets,
        'type_tickets_count':type_tickets_count}
	)


def ticket_details(request, id):
    ticket_id = Ticket.objects.get(id=id)
    status_ticket = Status_ticket.objects.order_by('status_ticket')
    
    return render(
        request,
        'ticket_details.html',
        context={'ticket_id':ticket_id, 'status_ticket':status_ticket}
    )


def ticket_booked(request, id):
    ticket = get_object_or_404(Ticket, id=id)
    ticket.status_ticket = Status_ticket.objects.get(status_ticket='booked')
    ticket.save()
    return render(
        request,
        'ticket_booked.html',
        context={'ticket':ticket}
    )
