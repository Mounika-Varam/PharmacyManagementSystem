import { Component, ViewChild } from '@angular/core';
import { Supplier } from '../models/ui-models/supplier.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { SupplierService } from '../services/supplier.service';

@Component({
  selector: 'app-suppliers',
  templateUrl: './suppliers.component.html',
  styleUrls: ['./suppliers.component.css']
})
export class SuppliersComponent {
  suppliers: Supplier[] = [];
  displayColumns: string[] = ['name', 'contactNumber', 'email', 'drugs', 'edit'];
  dataSource: MatTableDataSource<Supplier> = new MatTableDataSource<Supplier>();

  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;

  constructor(private supplierService: SupplierService){}

  ngOnInit(): void {
    this.supplierService.getSuppliers().subscribe(
      (successResponse) => {
        this.suppliers = successResponse;
        this.dataSource = new MatTableDataSource<Supplier>(this.suppliers);

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
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }


}
