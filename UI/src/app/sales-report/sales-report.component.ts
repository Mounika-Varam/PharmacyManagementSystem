import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { SalesService } from '../services/sales.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas';

@Component({
  selector: 'app-sales-report',
  templateUrl: './sales-report.component.html',
  styleUrls: ['./sales-report.component.css']
})
export class SalesReportComponent implements OnInit {

  ordersPerMonth: any[]= [];
  ordersPerYear: any[] = [];
  ordersPerDay: any[] = [];
  ordersPerDrug: any[] = [];

    displayDayColumns: string[] = ['day', 'sales'];
    dayDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

    displayMonthColumns: string[] = ['month', 'sales'];
    monthDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

    displayYearColumns: string[] = ['year', 'sales'];
    yearDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

    displayDrugColumns: string[] = ['drugName', 'sales'];
    drugDataSource: MatTableDataSource<any> = new MatTableDataSource<any>();

    @ViewChild(MatSort) matSort!: MatSort;

    @ViewChild('pdfContent') pdfContent!: ElementRef;


  constructor(private salesService: SalesService) {}


  ngOnInit(): void {
    this.salesService.getSalesPerMonth().subscribe(
      (SuccessResponse) =>{
        // console.log(SuccessResponse);
        this.ordersPerMonth = SuccessResponse;
        this.monthDataSource = new MatTableDataSource<any>(this.ordersPerMonth);

        if(this.matSort){
          this.monthDataSource.sort = this.matSort;
        }
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );

    this.salesService.getSalesPerYear().subscribe(
      (SuccessResponse) => {
        // console.log(SuccessResponse);

        this.ordersPerYear = SuccessResponse;
        this.yearDataSource = new MatTableDataSource<any>(this.ordersPerYear);

        if(this.matSort){
          this.yearDataSource.sort = this.matSort;
        }
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );

    this.salesService.getSalesPerDay().subscribe(
      (SuccessResponse) => {
        // console.log(SuccessResponse);
        this.ordersPerDay = SuccessResponse;
        this.dayDataSource = new MatTableDataSource<any>(this.ordersPerDay);

        if(this.matSort){
          this.dayDataSource.sort = this.matSort;
        }
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
    this.salesService.getSalesPerDrug().subscribe(
      (SuccessResponse) => {
        // console.log(SuccessResponse);
        this.ordersPerDrug = SuccessResponse;
        this.drugDataSource = new MatTableDataSource<any>(this.ordersPerDrug);

        if(this.matSort){
          this.drugDataSource.sort = this.matSort;
        }
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
 
    }


    generatePDF() {
      const pdf = new jsPDF();
    
      const options = {
        background: 'white',
        scale: 3,
      };

      const button = document.getElementById('button');
      if(button){
        button.style.display = 'none';
      }
    
      pdf.text("Sales Per Day", 0, 0)
      html2canvas(this.pdfContent.nativeElement, options).then((canvas) => {
        const contentDataURL = canvas.toDataURL('image/png');
        const imgWidth = 210; // PDF page width (in mm)
        const pageHeight = (canvas.height * imgWidth) / canvas.width;
        let position = 0;
    
        pdf.addImage(contentDataURL, 'PNG', 0, position, imgWidth, pageHeight);
        position -= pageHeight;

        if(button){
          button.style.display = 'flex';
        }
        pdf.save('sales_report.pdf');
      });
    }

}

    
    

   
    
  

