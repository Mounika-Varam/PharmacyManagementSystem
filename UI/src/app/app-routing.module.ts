import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DrugsComponent } from './drugs/drugs.component';
import { ViewDrugComponent } from './drugs/view-drug/view-drug.component';
import { SuppliersComponent } from './suppliers/suppliers.component';
import { ViewSupplierComponent } from './suppliers/view-supplier/view-supplier/view-supplier.component';
import { OrdersComponent } from './orders/orders.component';
import { PickedUpOrdersComponent } from './picked-up-orders/picked-up-orders.component';
import { OutOfStockDrugsComponent } from './drugs/out-of-stock-drugs/out-of-stock-drugs.component';
import { ExpiredDrugsComponent } from './drugs/expired-drugs/expired-drugs.component';
import { SalesReportComponent } from './sales-report/sales-report.component';
import { HomeComponent } from './home/home.component';
import { OrderDrugComponent } from './doctor/order-drug/order-drug.component';
import { PaymentComponent } from './doctor/payment/payment.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { YourOrdersComponent } from './doctor/your-orders/your-orders.component';

const routes: Routes = [
  {
    path: "", redirectTo:"login", pathMatch: "full"
  },
  {
    path: "drugs",
    component: DrugsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "drugs/:drugId",
    component: ViewDrugComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "suppliers",
    component: SuppliersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "suppliers/:supplierId",
    component: ViewSupplierComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "orders",
    component: OrdersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "pickedorders",
    component: PickedUpOrdersComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "out-of-stock-drugs",
    component: OutOfStockDrugsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "expired-drugs",
    component: ExpiredDrugsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "sales-report",
    component: SalesReportComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "home",
    component: HomeComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "order-drug",
    component: OrderDrugComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "payment/:orderId/:amount",
    component: PaymentComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "login",
    component: LoginComponent,
  },
  {
    path: "register",
    component: RegisterComponent,
  },
  {
    path: "your-orders",
    component: YourOrdersComponent,
    canActivate: [AuthGuard]
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
