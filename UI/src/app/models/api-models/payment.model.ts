import { PaymentMethod } from "src/app/Enums/payment-method.enum";
import { Order } from "./order.model";

export interface Payment{
    paymentId: string;
    method :PaymentMethod;
    amount: number;
    orderId: string;

    order: Order;
}