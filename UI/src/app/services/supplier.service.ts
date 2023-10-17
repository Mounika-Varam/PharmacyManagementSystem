import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Supplier } from '../models/api-models/supplier.model';
import { Observable } from 'rxjs';
import { UpdateSupplierRequest } from '../models/api-models/update-supplier-request.model';
import { AddSupplierRequest } from '../models/api-models/add-supplier-request.model';
import { Drug } from '../models/api-models/drug.model';

@Injectable({
  providedIn: 'root'
})
export class SupplierService {

  private baseApiUrl = "https://localhost:7079/api";

  constructor(private httpClient: HttpClient) {}

    getSuppliers() : Observable<Supplier[]>{
      return this.httpClient.get<Supplier[]>(this.baseApiUrl + "/Suppliers");
    }

    getSupplier(supplierId: string) : Observable<Supplier>{
      return this.httpClient.get<Supplier>(this.baseApiUrl + "/Suppliers/" + supplierId);
    }

    updateSupplier(supplierId: string, supplierRequest: Supplier): Observable<Supplier>{
      const updateSupplierRequest: UpdateSupplierRequest = {
        name: supplierRequest.name,
        contactNumber: supplierRequest.contactNumber,
        email: supplierRequest.email,
        drugs: supplierRequest.drugs
      };
      

      return this.httpClient.put<Supplier>(this.baseApiUrl + '/Suppliers/' + supplierId, updateSupplierRequest);
    }

    deleteSupplier(supplierId: string): Observable<Supplier> {
      return this.httpClient.delete<Supplier>(this.baseApiUrl + '/Suppliers/' + supplierId);
    }

   
    addSupplier(supplierRequest: Supplier): Observable<Supplier>{
      const addSupplierRequest: AddSupplierRequest = {
        name: supplierRequest.name,
        contactNumber: supplierRequest.contactNumber,
        email: supplierRequest.email,
        // drugs: supplierRequest.drugs
    };

    // const headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.httpClient.post<Supplier>(this.baseApiUrl + '/Suppliers/', addSupplierRequest);
    }

    getDrugs() : Observable<Drug[]>{
      return this.httpClient.get<Drug[]>(this.baseApiUrl + "/Drugs");
    }
}
