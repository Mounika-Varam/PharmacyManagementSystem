import { OrderStatus } from "src/app/Enums/order-status.enum";
import { Drug } from "./drug.model";
import { Payment } from "./payment.model";
import { PickedUpOrder } from "./picked-up-order.model";
import { User } from "./user.model";

export interface Order{
    orderId: string;
    quantity: number;
    orderDate: string;
    status: OrderStatus;
    userId: string;
    drugId: string;

    drug: Drug;
    payment: Payment;
    pickedUpOrder: PickedUpOrder;
    user: User;
}