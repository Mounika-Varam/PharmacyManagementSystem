import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Payment } from '../models/api-models/payment.model';
import { Observable } from 'rxjs';
import { AddPaymentRequest } from '../models/api-models/add-payment-request.model';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  private baseApiUrl = "https://localhost:7079/api";

  constructor(private httpClient: HttpClient) { }

  addPayment(addPaymentRequest: AddPaymentRequest): Observable<Payment>{

    return this.httpClient.post<Payment>(this.baseApiUrl + '/Payments/', addPaymentRequest );
    }
}
