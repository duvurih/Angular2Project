import { BaseAddress } from "../models/baseaddress.model";
import { BaseModel } from "../models/base.model";
import { OrderDetailModel } from "../models/order.details.model";

export class OrderModel extends BaseModel {
    orderID: number;
    customerID: string;
    orderDate: Date;
    requiredDate: Date;
    shippedDate: Date;
    freight: number;
    shipName: string;
    addressModel: BaseAddress;
    orderDetails: any;
    customer: any;


    constructor(orderData: any) {
        super();

        this.orderID = super.checkUndefinedValue(orderData.orderID);
        this.customerID = super.checkUndefinedValue(orderData.customerID);
        this.orderDate = super.checkUndefinedValue(orderData.orderDate);
        this.requiredDate = super.checkUndefinedValue(orderData.requiredDate);
        this.shippedDate = super.checkUndefinedValue(orderData.shippedDate);
        this.freight = super.checkUndefinedValue(orderData.freight);
        this.shipName = super.checkUndefinedValue(orderData.shipName);
        this.addressModel = new BaseAddress(orderData.addressModel);
        this.orderDetails = orderData.order_Details;
        this.customer = orderData.customer;
    }
}