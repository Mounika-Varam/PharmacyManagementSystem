import { Injectable } from '@angular/core';
import { Order } from '../models/api-models/order.model';

@Injectable({
  providedIn: 'root'
})
export class OrderPaymentService {

  private orderId!: string;
  private amount!: number;
  constructor() { }

  setOrderId(order: string) {
      this.orderId = order;
  }

  getOrderId(): string {
    return this.orderId;
  }

  setAmount(amount: number) {
      this.amount = amount;
  }
    getAmount(): number {
      return this.amount;
  }
}
