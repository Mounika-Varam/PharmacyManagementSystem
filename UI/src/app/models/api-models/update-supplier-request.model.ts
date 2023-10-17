import { Drug } from "./drug.model";

export interface UpdateSupplierRequest{
    name: string;
    contactNumber: string;
    email: string;
    drugs: Drug[];
}