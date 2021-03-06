import { Item } from "./item";

export interface Sell {
    id: string;
    purchasePrice: number;
    sellingPrice: number;
    profit: number;
    sold: boolean;
    margin: number;
    comments?: string;
    item_id: string;
    listingDate?: Date | string;
    sellingDate?: Date | string;
}

export interface SellItem extends Sell {
    item?: Item;
}