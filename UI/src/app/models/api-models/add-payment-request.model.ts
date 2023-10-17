import { PaymentMethod } from "src/app/Enums/payment-method.enum";

export interface AddPaymentRequest{
    paymentId: string;
    method :PaymentMethod;
    amount: number;
    orderId: string;
}