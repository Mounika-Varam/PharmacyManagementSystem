import { HttpClient, HttpParams } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { OrderStatus } from 'src/app/Enums/order-status.enum';
import { AddOrderRequest } from 'src/app/models/api-models/add-order-request.model';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { DrugService } from 'src/app/services/drug.service';
import { OrderPaymentService } from 'src/app/services/order-payment.service';
import { OrderService } from 'src/app/services/order.service';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-order-drug',
  templateUrl: './order-drug.component.html',
  styleUrls: ['./order-drug.component.css']
})
export class OrderDrugComponent {

  drugs: Drug[] = [];
  drug:Drug = {
    drugId: '',
        drugName: '',
        expiryDate: '',
        imageUrl: '',
        price: 0,
        quantity: 0,
        orders: [],
        suppliers: []
  };

  orderId: string ='';
  url: string ='';

  orderRequest!:AddOrderRequest;
  amount : number = 0;
  isCreatingOrder: boolean = false;

  constructor(private readonly drugService: DrugService, 
    private readonly orderService: OrderService,
    private readonly orderPaymentService: OrderPaymentService,
    private readonly userService: UserService,
    private router: Router,
    private httpClient: HttpClient) {}

    ngOnInit(): void {
      this.drugService.getDrugs().subscribe(
        (successResponse) => {
          this.drugs = successResponse;
          for(let drug of this.drugs){
             drug.quantity = 0;
          }
        },
        (errorResponse) =>{
          console.log(errorResponse);
        }
      );

      // for(let drug of this.drugs) {
      //   drug.imageUrl = this.setImage(drug);
      // }
    }

     setImage(imageUrl: string): string{
      if(imageUrl){
        return this.drugService.getImagePath(imageUrl);
      }
      else{
        return '/assets/pill-bottle.jpeg';
      }
    }

    createOrder(drug: Drug){
      this.isCreatingOrder = true;
      this.orderRequest = {
        drugId: drug.drugId,
        quantity: drug.quantity,
        orderDate: new Date().toISOString(),
        status: OrderStatus.Pending,
        userId: localStorage.getItem("userId")?? ' ',
      }

      this.orderService.addOrder(this.orderRequest).subscribe(
        (successResponse) => {
          // console.log(successResponse);
          // console.log(successResponse['orderId']);

          this.orderId = successResponse['orderId'];
          this.amount = drug.price * drug.quantity;
          this.url = `/payment/${this.orderId}/${this.amount}`;

           // console.log(this.orderId);
           console.log(this.url);

          this.drugService.getDrug(drug.drugId).subscribe(
            (successResponse) => {
              const q = drug.quantity;
                drug = successResponse;
                console.log(drug);
                drug.quantity = drug.quantity - q;
                console.log(drug);    
            }
          );
          this.drugService.updateDrug(drug.drugId, drug).subscribe(
            (successResponse) =>{
              console.log(successResponse);
            },
            (errorResponse) => {
              console.log(errorResponse);
            }
          );
          
          this.isCreatingOrder = false; 
          this.router.navigateByUrl(this.url);
        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );        
    }

    

}
