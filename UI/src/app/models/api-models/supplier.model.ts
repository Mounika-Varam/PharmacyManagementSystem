import { Drug } from "./drug.model";

export interface Supplier{
    supplierId: string;
    name: string;
    contactNumber: string;
    email: string;

    drugs: Drug[];
}