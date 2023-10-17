import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Sales } from '../models/api-models/sales.model';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  private baseApiUrl = "https://localhost:7079";

  constructor(private httpClient: HttpClient) {}

    getSalesPerYear() : Observable<any[]>{
      return this.httpClient.get<any[]>(this.baseApiUrl + "/sales-per-year");
    }
    getSalesPerMonth() : Observable<any[]>{
      return this.httpClient.get<any[]>(this.baseApiUrl + "/sales-per-month");
    }
    getSalesPerDay() : Observable<any[]>{
      return this.httpClient.get<any[]>(this.baseApiUrl + "/sales-per-day");
    }
    getSalesPerDrug() : Observable<any[]>{
      return this.httpClient.get<any[]>(this.baseApiUrl + "/sales-per-drug");
    }
    // getSalesPerYear() : Observable<Sales[]>{
    //   return this.httpClient.get<Sales[]>(this.baseApiUrl + "/sales-per-year");
    // }
    // getSalesPerMonth() : Observable<Sales[]>{
    //   return this.httpClient.get<Sales[]>(this.baseApiUrl + "/sales-per-month");
    // }
    // getSalesPerDay() : Observable<Sales[]>{
    //   return this.httpClient.get<Sales[]>(this.baseApiUrl + "/sales-per-day");
    // }
    // getSalesPerDrug() : Observable<Sales[]>{
    //   return this.httpClient.get<Sales[]>(this.baseApiUrl + "/sales-per-drug");
    // }
}
