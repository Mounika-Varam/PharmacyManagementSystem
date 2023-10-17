import { Component, OnInit } from '@angular/core';
import { Drug } from 'src/app/models/ui-models/drug.model';
import { DrugService } from 'src/app/services/drug.service';

@Component({
  selector: 'app-expired-drugs',
  templateUrl: './expired-drugs.component.html',
  styleUrls: ['./expired-drugs.component.css']
})
export class ExpiredDrugsComponent implements OnInit {
  drugs: Drug[] = [];
  
  constructor(private drugService: DrugService){}

  ngOnInit(): void {
    this.drugService.getExpiredDrugs().subscribe(
      (successResponse)=>{
        this.drugs = successResponse;
      },
      (errorResponse) =>{
        console.log(errorResponse);
      }
    )
  }
}
