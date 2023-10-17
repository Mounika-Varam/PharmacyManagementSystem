import { Component } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { PaymentMethod } from 'src/app/Enums/payment-method.enum';
import { Order } from 'src/app/models/api-models/order.model';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { Payment } from 'src/app/models/ui-models/payment.model';
import { DrugService } from 'src/app/services/drug.service';
import { OrderPaymentService } from 'src/app/services/order-payment.service';
import { PaymentService } from 'src/app/services/payment.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent {

  // paymentId: string;
  //   method :PaymentMethod;
  //   amount: number;
  //   orderId: string;

  
  paymentMethods: PaymentMethod[] =[
    PaymentMethod.Upi,
    PaymentMethod.DebitCard,
        PaymentMethod.CreditCard
  ];

  order!: Order;

  payment: Payment ={
    paymentId: '',
    method :PaymentMethod.CreditCard,
    amount: 0,
    orderId: '',
    order: this.order
  }
  

  constructor(private readonly orderPaymentService : OrderPaymentService, 
    private readonly paymentService: PaymentService, 
    private readonly route: ActivatedRoute, 
    private snackbar: MatSnackBar, private router: Router) {
      this.route.paramMap.subscribe(
        (params) => {
          this.payment.amount = parseFloat(params.get('amount')?? '');
          this.payment.amount = parseFloat(this.payment.amount.toFixed(2));
    });
    this.route.paramMap.subscribe(
      (params) => {
        this.payment.orderId = params.get('orderId')?? '';
  });
    }

    ngOninit(){

      
  }

  makePayment(){
    // console.log(this.payment);

    this.paymentService.addPayment(this.payment).subscribe(
      (successResponse) => {
        console.log(this.payment)
        console.log(successResponse);
        this.snackbar.open('Order Placed Successfully', undefined, {duration: 2000});
        
        setTimeout(() => {
          this.router.navigateByUrl('order-drug');
        }, 2000);
      },
      (errorResponse) =>{
        // console.log(this.payment);
        console.log(errorResponse);
      }
    );
  }

  getPaymentMethodName(method: PaymentMethod): string {
    switch (method) {
      case PaymentMethod.Upi:
        return 'UPI';
      case PaymentMethod.DebitCard:
        return 'Debit Card';
      case PaymentMethod.CreditCard:
        return 'Credit Card';
      default:
        return '';
    }
  }

}
