import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Drug } from 'src/app/models/ui-models/drug.model';
// import { Drug } from 'src/app/models/ui-models/drug.model';
import { Supplier } from 'src/app/models/ui-models/supplier.model';
// import { DrugService } from 'src/app/services/drug.service';
import { SupplierService } from 'src/app/services/supplier.service';

@Component({
  selector: 'app-view-supplier',
  templateUrl: './view-supplier.component.html',
  styleUrls: ['./view-supplier.component.css']
})
export class ViewSupplierComponent implements OnInit{
  supplierId: string | null | undefined;
  supplier: Supplier = {
    supplierId: '',
    name: '',
    contactNumber: '',
    email: '',
    drugs: []
  };
  
  header = '';
  isNewSupplier = false;
  drugs: Drug[] = [];

  constructor(private readonly supplierService: SupplierService, 
    private readonly route: ActivatedRoute, 
    private snackbar: MatSnackBar,
    private router: Router) {
    }



  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.supplierId = params.get('supplierId');

        if(this.supplierId){

          if(this.supplierId.toLowerCase() === 'Add'.toLowerCase()){
            this.isNewSupplier = true;
            this.header = 'Add New Supplier';
          }
          else{
            this.isNewSupplier = false;
            this.header = 'Edit Supplier Details';
            this.supplierService.getSupplier(this.supplierId).subscribe(
              (succesResponse) =>{
               this.supplier = succesResponse;
              },
              (errorResponse) =>{
               console.log(errorResponse);
              }
   
             );
          }
        } 
      });

      this.setDrugs();

  }

  onUpdate() : void {
    this.supplierService.updateSupplier(this.supplier.supplierId, this.supplier).subscribe(
      (successResponse) =>{
        this.snackbar.open('Supplier details updated successfully', undefined, {duration: 2000});
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  onDelete() : void {
    this.supplierService.deleteSupplier(this.supplier.supplierId).subscribe(
      (successResponse) => {
        this.snackbar.open('Supplier deleted successfully', undefined, {duration: 2000});


        setTimeout(() => {
          this.router.navigateByUrl('suppliers');
        }, 2000);
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
      );
  }

  onAdd(): void{
    console.log(this.supplier);
    this.supplierService.addSupplier(this.supplier).subscribe(
      (succesResponse) => {
        this.snackbar.open('Supplier added successfully', undefined, {duration: 2000});


        setTimeout(() => {
          this.router.navigateByUrl('suppliers');
        }, 2000);
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  private setDrugs(): void {
    this.supplierService.getDrugs().subscribe(
      (successResponse) => {
        this.drugs = successResponse;

      },
      (errorResponse) =>{
        console.log(errorResponse);
      }
    );
  }
}
