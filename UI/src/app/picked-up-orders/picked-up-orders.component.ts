import { Component, ViewChild } from '@angular/core';
import { PickedUpOrder } from '../models/ui-models/picked-up-order.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { OrderService } from '../services/order.service';
import { PickedUpOrdersService } from '../services/picked-up-orders.service';
import { DrugService } from '../services/drug.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Order } from '../models/ui-models/order.model';
import { Drug } from '../models/ui-models/drug.model';

@Component({
  selector: 'app-picked-up-orders',
  templateUrl: './picked-up-orders.component.html',
  styleUrls: ['./picked-up-orders.component.css']
})
export class PickedUpOrdersComponent {
    // pickedOrders: PickedUpOrder[] = [];
    orders: Order[] = [];
    drugs: Drug[] = [];
    displayColumns: string[] = ['quantity', 'drugId'];

    dataSource: MatTableDataSource<Order> = new MatTableDataSource<Order>();

    @ViewChild(MatPaginator) matPaginator!: MatPaginator;
    @ViewChild(MatSort) matSort!: MatSort; 

    constructor(private orderService: OrderService, 
      private ordersService : OrderService, 
      private drugsService: DrugService,
      private snackbar: MatSnackBar){}


      ngOnInit(): void {
        this.orderService.getPickedOrders().subscribe(
          (successResponse) => {
            this.orders = successResponse;
            this.dataSource = new MatTableDataSource<Order>(this.orders);
    
            if(this.matPaginator){
              this.dataSource.paginator = this.matPaginator;
            }
    
            if(this.matSort){
              this.dataSource.sort = this.matSort;
            }
          },
          (errorResponse) =>{
            console.log(errorResponse);
          }
        ); 

        // this.orderService.getOrders().subscribe(
        //   (successResponse) => {
        //     this.orders = successResponse;
        //   },
        //   (errorResponse) =>{
        //     console.log(errorResponse);
        //   }
        // ); 
    
        this.drugsService.getDrugs().subscribe(
          (successResponse) => {
            this.drugs = successResponse;
          },
          (errorResponse) =>{
            console.log(errorResponse);
          }
        ); 
       }

      //  getDrugName(drugId: string): string | undefined {
      //   return this.drugs.find(drug => drug.drugId === drugId)?.drugName;
      // }

      // getQuantity(orderId: string): number | undefined {
      //   return this.orders.find(order => order.orderId === orderId)?.quantity;
      // }

      // getOrderDate(orderId: string): string | undefined {
      //   return this.orders.find(order => order.orderId === orderId)?.orderDate;
      // }

      getDrugName(drugId: string): string{
        return this.drugs.find(drug => drug.drugId === drugId)?.drugName?? '';
      }

}
