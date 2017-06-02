import { BaseModel } from "../models/base.model";

export class OrderDetailModel extends BaseModel  {
    orderID: number;
    productID: number;
    unitPrice: number;
    quantity: number;
    discount: number;
    product: any;

    constructor(orderDetailData: any) {
        super();

        this.orderID = super.checkUndefinedValue(orderDetailData.orderID);
        this.productID = super.checkUndefinedValue(orderDetailData.productID);
        this.unitPrice = super.checkUndefinedValue(orderDetailData.unitPrice);
        this.quantity = super.checkUndefinedValue(orderDetailData.quantity);
        this.discount = super.checkUndefinedValue(orderDetailData.discount);
        this.product = orderDetailData.product;
    }
}