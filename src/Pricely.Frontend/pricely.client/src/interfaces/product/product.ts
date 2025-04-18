import { Merchant } from "../merchant";

export interface Product {
    name?: string;
    description?: string;
    gtin: string;
    images: string[];
    brand?: string;
    price?: string
    merchant?: Merchant


}

