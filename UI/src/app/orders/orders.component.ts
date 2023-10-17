import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { Order } from '../models/ui-models/order.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { OrderService } from '../services/order.service';
import { OrderStatus } from '../Enums/order-status.enum';
import { PickedUpOrdersService } from '../services/picked-up-orders.service';
import { PickedUpOrder } from '../models/api-models/picked-up-order.model';
import { User } from '../models/ui-models/user.model';
import { Drug } from '../models/ui-models/drug.model';
import { DrugService } from '../services/drug.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {
  

  orders: Order[] = [];
  users: User[] = [];
  drugs: Drug[] = [];
  displayColumns: string[] = ['quantity', 'orderDate', 'status','userId','drugId', 'addOrderToPickedUp'];
  dataSource: MatTableDataSource<Order> = new MatTableDataSource<Order>();

  orderStatusMapping: { [key: number]: string };
  

  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort; 

  constructor(private orderService: OrderService, 
    private pickedUpOrderService : PickedUpOrdersService, 
    private drugsService: DrugService,
    private readonly route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private changeDetectorRef: ChangeDetectorRef,
    private snackbar: MatSnackBar){
    this.orderStatusMapping = {
      [OrderStatus.Pending]: 'Pending',
      [OrderStatus.Verified]: 'Verified',
      [OrderStatus.PickedUp]: 'PickedUp'
    };
  }

  ngOnInit(): void {
    this.orderService.getPendingOrders().subscribe(
      (successResponse) => {
        
        this.orders = successResponse;
        this.dataSource = new MatTableDataSource<Order>(this.orders);
        // console.log(this.orders);
        // console.log(successResponse);

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

    this.drugsService.getDrugs().subscribe(
      (successResponse) => {
        this.drugs = successResponse;
      },
      (errorResponse) =>{
        console.log(errorResponse);
      }
    ); 

    this.userService.getUsers().subscribe(
      (succesResponse) => {
        // console.log(succesResponse);
        this.users = succesResponse;
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
   }
  

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  onPick(order: Order): void{

    console.log(order);
      order.status = OrderStatus.PickedUp;
      this.orderService.updateOrder(order).subscribe(
        (succesResponse) =>{
          console.log(succesResponse);
        },
        (errorResponse) =>{
          console.log(errorResponse);
        }
      )

    this.pickedUpOrderService.addPickedUpOrder(order.orderId).subscribe(
      (succesResponse) => {
        console.log(succesResponse);
        this.snackbar.open('Order Picked successfully', undefined, {duration: 2000});

        
        this.changeDetectorRef.detectChanges();
        
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );

  }

  getDrugName(drugId: string): string{
    // console.log(this.drugs.find(drug => drug.drugId === drugId)?.drugName?? '');
    return this.drugs.find(drug => drug.drugId === drugId)?.drugName?? '';
  }

  getDoctorName(userId: string): string{
    return this.users.find(user => user.userId === userId)?.fullName?? '';
  }

}
