import { Component, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { OrderStatus } from 'src/app/Enums/order-status.enum';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { Order } from 'src/app/models/ui-models/order.model';
import { DrugService } from 'src/app/services/drug.service';
import { OrderService } from 'src/app/services/order.service';

@Component({
  selector: 'app-your-orders',
  templateUrl: './your-orders.component.html',
  styleUrls: ['./your-orders.component.css']
})
export class YourOrdersComponent {
  orders: Order[] = [];
  drugs: Drug[] = [];
  userId: string = "";
  displayColumns: string[] = ['drugName', 'orderDate', 'quantity', 'status'];
  dataSource: MatTableDataSource<Order> = new MatTableDataSource<Order>();
  orderStatusMapping: { [key: number]: string };
  
  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;

  constructor(private orderService: OrderService, private drugService: DrugService){
    this.orderStatusMapping = {
      [OrderStatus.Pending]: 'Pending',
      [OrderStatus.Verified]: 'Verified',
      [OrderStatus.PickedUp]: 'PickedUp'
    };
  }

  ngOnInit(): void {
    this.userId = localStorage.getItem('userId')?? '';

    this.orderService.getOrders().subscribe(
      (successResponse) => {
        this.orders = successResponse.filter(order => order.userId.toUpperCase() === this.userId.toUpperCase());
        // console.log(successResponse, this.orders, this.userId)
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

    this.drugService.getDrugs().subscribe(
          (successResponse) => {
            this.drugs = successResponse;
          },
          (errorResponse) => {
            console.log(errorResponse);
          });
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  getDrugName(drugId: string): string{   
    return this.drugs.find(drug => drug.drugId === drugId)?.drugName?? '';
  }

}
