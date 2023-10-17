import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Drug } from '../models/api-models/drug.model';
import { UpdateDrugRequest } from '../models/api-models/update-drug-request.model';
import { AddDrugRequest } from '../models/api-models/add-drug-request.model';
import { UpdateDrugQuantityRequest } from '../models/api-models/update-drug-quantity-request.model';

@Injectable({
  providedIn: 'root'
})
export class DrugService {

  private baseApiUrl = "https://localhost:7079/api";
  private imagesUrl = "https://localhost:7079";

  constructor(private httpClient: HttpClient) {}

    getDrugs() : Observable<Drug[]>{
      return this.httpClient.get<Drug[]>(this.baseApiUrl + "/Drugs");
    }

    getDrug(drugId: string) : Observable<Drug>{
      return this.httpClient.get<Drug>(this.baseApiUrl + "/Drugs/" + drugId);
    }

    updateDrug(drugId: string, drugRequest: Drug): Observable<Drug>{
      const updateDrugRequest: UpdateDrugRequest = {
          drugName: drugRequest.drugName,
          expiryDate: drugRequest.expiryDate,
          imageUrl: drugRequest.imageUrl,
          price: drugRequest.price,
          quantity: drugRequest.quantity
      };

      return this.httpClient.put<Drug>(this.baseApiUrl + '/drugs/' + drugId, updateDrugRequest);
    }

    deleteDrug(drugId: string): Observable<Drug> {
      return this.httpClient.delete<Drug>(this.baseApiUrl + '/drugs/' + drugId);
    }

    addDrug(drugRequest: Drug): Observable<Drug>{
      const addDrugRequest: AddDrugRequest = {
        drugName: drugRequest.drugName,
        expiryDate: drugRequest.expiryDate,
        imageUrl: drugRequest.imageUrl,
        price: drugRequest.price,
        quantity: drugRequest.quantity
    };

    return this.httpClient.post<Drug>(this.baseApiUrl + '/drugs/', addDrugRequest );
    }

    uploadImage(drugId: string, file: File): Observable<any> {
      const formData = new FormData();
      formData.append('drugImage', file);

      return this.httpClient.post(this.baseApiUrl + '/drugs/' + drugId + '/upload-image', formData, {
        responseType: 'text'
      });
    }
   
    getImagePath(path: string){
      return `${this.imagesUrl}/${path}`;
    }

    getExpiredDrugs() : Observable<Drug[]>{
      return this.httpClient.get<Drug[]>(this.baseApiUrl + "/Drugs/expired");
    }

    getOutOfStockDrugs() : Observable<Drug[]>{
      return this.httpClient.get<Drug[]>(this.baseApiUrl + "/Drugs/out-of-stock");
    }
}
