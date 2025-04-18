import { Merchant } from "../merchant";

export interface ProductPreview {
    idSku?: string;
    merchant?: Merchant
    name?: string;
    image?: string;
    url?: string;
    currentPrice?: string
    availability?: boolean
    


}

