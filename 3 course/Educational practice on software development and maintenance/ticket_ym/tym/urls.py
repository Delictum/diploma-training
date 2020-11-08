"""ticket_ym URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/2.0/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.conf.urls import url
from django.urls import path, re_path

from . import views

urlpatterns = [
    path('', views.index, name='index'),
    path('type_institutions', views.type_institutions,
         name='type_institutions'),
    re_path(r'^type_institutions/(?P<id>\d+)/$',
        views.institutions, name='institutions'),
    re_path(r'^type_institutions/(\d+)/(?P<id>\d+)/$',
        views.events, name='events'),
    re_path(r'^type_institutions/(\d+)/(\d+)/(?P<id>\d+)/$',
        views.tickets, name='tickets'),
    re_path(r'^type_institutions/(\d+)/(\d+)/(\d+)/(?P<id>\d+)/$',
        views.ticket_details, name='ticket_details'),
    re_path(r'^type_institutions/(\d+)/(\d+)/(\d+)/(?P<id>\d+)/ticket_booked/$',
        views.ticket_booked, name='ticket_booked'),
]
