from django.db import models
import uuid


class Type_institution(models.Model):
    """Тип заведения"""
    type_institution = models.CharField(max_length=100) 
    def __str__(self):
        return self.type_institution


class Institution(models.Model):
    """Информация о заведении"""
    type_institution = models.ForeignKey(Type_institution,
                                         on_delete=models.CASCADE, )
    name_institution = models.CharField(max_length=200)
    adress_institution = models.CharField(max_length=200)  
        
    def __str__(self):
        return self.name_institution
    

class Event(models.Model):
    institution = models.ForeignKey(Institution,
                                    on_delete=models.CASCADE, )
    name_event = models.TextField()
    date_added = models.DateTimeField()

    def __str__(self):
        return self.name_event


class Type_ticket(models.Model):
    type_ticket = models.CharField(max_length=100)

    def __str__(self):
        return self.type_ticket


class Status_ticket(models.Model):
    status_ticket = models.CharField(max_length=30)        

    def __str__(self):
        return self.status_ticket

    
class Ticket(models.Model):
    event = models.ForeignKey(Event,
                              on_delete=models.CASCADE, )
    type_ticket = models.ForeignKey(Type_ticket,
                                    on_delete=models.CASCADE, )
    status_ticket = models.ForeignKey(Status_ticket,
                                      on_delete=models.CASCADE, )
    seat_number_ticket = models.IntegerField()
    cost_ticket = models.DecimalField(max_digits=7, decimal_places=2)
    
    def __int__(self):
        return self.seat_number_ticket
    

class Type_payment(models.Model):
    type_payment = models.CharField(max_length=100)

    def __str__(self):
        return self.type_payment


class User(models.Model):
    login_user = models.TextField()
    password_user = models.DateTimeField()

    def __str__(self):
        return self.login_user


class Payment(models.Model):
    user = models.ForeignKey(User,
                             on_delete=models.CASCADE, )
    type_payment = models.ForeignKey(Type_payment,
                                    on_delete=models.CASCADE, )
    ticket = models.ForeignKey(Ticket,
                               on_delete=models.CASCADE, )
    date_payment = models.DateField()
    count_ticket = models.IntegerField()
    
    def __datetime__(self):
        return self.date_payment
