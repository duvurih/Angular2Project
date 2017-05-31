import { BaseAddress } from "../models/baseaddress.model";
import { BaseCommunication } from "../models/basecommunication.model";
import { BaseModel } from "../models/base.model";

export class CustomerModel extends BaseModel {
    customerID: string;
    companyName: string;
    contactName: string;
    contactTitle: string;
    addressModel: BaseAddress;
    communicationModel: BaseCommunication;

    constructor(customerData: any) {
        super();

        this.customerID = super.checkUndefinedValue(customerData.customerID);
        this.companyName = super.checkUndefinedValue(customerData.companyName);
        this.contactName = super.checkUndefinedValue(customerData.contactName);
        this.contactTitle = super.checkUndefinedValue(customerData.contactTitle);
        this.addressModel = new BaseAddress(customerData.addressModel);
        this.communicationModel = new BaseCommunication(customerData.communicationModel);
    }
}