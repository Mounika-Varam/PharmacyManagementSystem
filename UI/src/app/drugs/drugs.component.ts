import { Component, OnInit, ViewChild } from '@angular/core';
import { DrugService } from '../services/drug.service';
import { Drug } from '../models/ui-models/drug.model';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';

@Component({
  selector: 'app-drugs',
  templateUrl: './drugs.component.html',
  styleUrls: ['./drugs.component.css']
})
export class DrugsComponent implements OnInit{

  drugs: Drug[] = [];
  displayColumns: string[] = ['drugName', 'expiryDate', 'price', 'quantity', 'edit'];
  dataSource: MatTableDataSource<Drug> = new MatTableDataSource<Drug>();

  @ViewChild(MatPaginator) matPaginator!: MatPaginator;
  @ViewChild(MatSort) matSort!: MatSort;

  constructor(private drugService: DrugService){}

  ngOnInit(): void {
    this.drugService.getDrugs().subscribe(
      (successResponse) => {
        this.drugs = successResponse;
        this.dataSource = new MatTableDataSource<Drug>(this.drugs);

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

  getCompleteUrl(imageUrl : string):string{
      return this.drugService.getImagePath(imageUrl);      
  }

}
