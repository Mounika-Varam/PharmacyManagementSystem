import { SupplierDrug } from "./supplier-drug.model";


export interface AddSupplierRequest{
    name: string;
    contactNumber: string;
    email: string;
    // drugs: SupplierDrug[];
}