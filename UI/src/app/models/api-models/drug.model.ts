import { Order } from "./order.model";
import { Supplier } from "./supplier.model";

export interface Drug{
    drugId: string;
    drugName: string;
    expiryDate: string;
    imageUrl: string;
    price: number;
    quantity: number;

    orders: Order[];
    suppliers: Supplier[];
}