import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PickedUpOrder } from '../models/api-models/picked-up-order.model';
import { Observable } from 'rxjs';
import { AddPickedUpOrderRequest } from '../models/api-models/add-picked-up-order-request';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class PickedUpOrdersService {

  private baseApiUrl = "https://localhost:7079/api";
  constructor(private httpClient: HttpClient) {}

  getPickedUpOrders() : Observable<PickedUpOrder[]>{
    return this.httpClient.get<PickedUpOrder[]>(this.baseApiUrl + "/PickedUpOrders");
  }

  addPickedUpOrder(orderId : string): Observable<PickedUpOrder>{
    const addPickedUpOrderRequest: AddPickedUpOrderRequest = {
      orderId: orderId
  };

  return this.httpClient.post<PickedUpOrder>(this.baseApiUrl + '/PickedUpOrders', addPickedUpOrderRequest);
  }
}
