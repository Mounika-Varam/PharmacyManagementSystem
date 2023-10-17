import { Component, OnInit } from '@angular/core';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { DrugService } from 'src/app/services/drug.service';

@Component({
  selector: 'app-out-of-stock-drugs',
  templateUrl: './out-of-stock-drugs.component.html',
  styleUrls: ['./out-of-stock-drugs.component.css']
})
export class OutOfStockDrugsComponent implements OnInit {

  drugs: Drug[] = [];
  
  constructor(private drugService: DrugService){}

  ngOnInit(): void {
    this.drugService.getOutOfStockDrugs().subscribe(
      (successResponse)=>{
        this.drugs = successResponse;
      },
      (errorResponse) =>{
        console.log(errorResponse);
      }
    )
  }

}
