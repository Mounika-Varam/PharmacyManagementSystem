import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../models/api-models/order.model';
import { Observable } from 'rxjs';
import { UpdateOrderRequest } from '../models/api-models/update-order-request';
import { AddOrderRequest } from '../models/api-models/add-order-request.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private baseApiUrl = "https://localhost:7079/api";

  constructor(private httpClient: HttpClient) { }

    getOrders(): Observable<Order[]> {
      return this.httpClient.get<Order[]>(this.baseApiUrl + "/Orders");
    }

    getPickedOrders():Observable<Order[]> {
      return this.httpClient.get<Order[]>(this.baseApiUrl + "/Orders/picked-orders");
    }

    getPendingOrders():Observable<Order[]> {
      return this.httpClient.get<Order[]>(this.baseApiUrl + "/Orders/doctor-orders");
    }

    getOrder(orderId: string) : Observable<Order>{
      return this.httpClient.get<Order>(this.baseApiUrl + "/Orders/" + orderId);
    }

    addOrder(addOrderRequest: AddOrderRequest): Observable<Order>{

    return this.httpClient.post<Order>(this.baseApiUrl + '/Orders/', addOrderRequest );
    }

    updateOrder(orderRequest: Order): Observable<Order>{
      const updateOrderRequest: UpdateOrderRequest = {
        status: orderRequest.status,
      };

      return this.httpClient.put<Order>(this.baseApiUrl + '/Orders/' + orderRequest.orderId, updateOrderRequest);
    }
}
