import { Gender } from "src/app/Enums/gender.enum";
import { Order } from "./order.model";

export interface User{
    userId: string;
    fullName: string;
    email: string;
    phoneNumber: string;
    gender: Gender;
    role: string;

    orders: Order[];
}