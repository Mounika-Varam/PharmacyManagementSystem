import { Order } from "./order.model";

export interface PickedUpOrder{
    pickedUpOrderId: string;
    pickedUpDate: string;
    orderId: string;

    order: Order;
}