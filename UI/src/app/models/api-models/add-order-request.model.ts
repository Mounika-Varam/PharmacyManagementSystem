import { OrderStatus } from "src/app/Enums/order-status.enum";

export interface AddOrderRequest{
    quantity: number;
    orderDate: string;
    status: OrderStatus;
    userId: string;
    drugId: string;
}