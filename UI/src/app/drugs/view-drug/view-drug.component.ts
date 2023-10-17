import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { DrugService } from 'src/app/services/drug.service';

@Component({
  selector: 'app-view-drug',
  templateUrl: './view-drug.component.html',
  styleUrls: ['./view-drug.component.css']
})
export class ViewDrugComponent implements OnInit{

  drugId: string | null | undefined;
  drug: Drug = {
    drugId: "",
    drugName: "",
    expiryDate: "",
    imageUrl: "",
    price: 0,
    quantity: 0,
    orders: [],
    suppliers: []
  };

  minDate = new Date();
  isNewDrug = false;
  header = '';
  drugImage = '';

  constructor(private readonly drugService: DrugService, 
    private readonly route: ActivatedRoute, 
    private snackbar: MatSnackBar,
    private router: Router) {}



  ngOnInit(): void {
    this.route.paramMap.subscribe(
      (params) => {
        this.drugId = params.get('drugId');

        if(this.drugId){

          if(this.drugId.toLowerCase() === 'Add'.toLowerCase()){
            this.isNewDrug = true;
            this.header = 'Add New Drug';
            this.setImage();
          }
          else{
            this.isNewDrug = false;
            this.header = 'Edit Drug Details';
            this.drugService.getDrug(this.drugId).subscribe(
              (succesResponse) =>{
               this.drug = succesResponse;
               this.setImage();
              },
              (errorResponse) =>{
               console.log(errorResponse);
              }
   
             );
          }
        } 
      });
  }

  onUpdate() : void {
    this.drugService.updateDrug(this.drug.drugId, this.drug).subscribe(
      (successResponse) =>{
        this.snackbar.open('Drug details updated successfully', undefined, {duration: 2000});
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  onDelete() : void {
    this.drugService.deleteDrug(this.drug.drugId).subscribe(
      (successResponse) => {
        this.snackbar.open('Drug deleted successfully', undefined, {duration: 2000});


        setTimeout(() => {
          this.router.navigateByUrl('drugs');
        }, 2000);
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
      );
  }

  onAdd(): void{
    // console.log(this.drug);
    this.drugService.addDrug(this.drug).subscribe(
      (succesResponse) => {
        this.snackbar.open('Drug added successfully', undefined, {duration: 2000});


        setTimeout(() => {
          this.router.navigateByUrl('drugs');
        }, 2000);
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  private setImage():void{
    if(this.drug.imageUrl){
      this.drugImage = this.drugService.getImagePath(this.drug.imageUrl);
      console.log(this.drugImage);
    }
    else{
      this.drugImage = '/assets/pill-bottle.jpeg';
    }
  }

  uploadImage(event : any): void{
    if(this.drugId){
      const file: File = event.target.files[0];
      this.drugService.uploadImage(this.drugId, file).subscribe(
        (succesResponse) => {
          this.drug.imageUrl = succesResponse;
          console.log(succesResponse);
          this.setImage();

          this.snackbar.open('Image updated successfully', undefined, {duration: 2000});

        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );
    }
  }
}
