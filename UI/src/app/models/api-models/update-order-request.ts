import { OrderStatus } from "src/app/Enums/order-status.enum";

export interface UpdateOrderRequest {
    status: OrderStatus;
}