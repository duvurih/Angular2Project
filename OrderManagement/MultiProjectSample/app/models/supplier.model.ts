import { BaseAddress } from "../models/baseaddress.model";
import { BaseCommunication } from "../models/basecommunication.model";
import { BaseModel } from "../models/base.model";

export class SupplierModel extends BaseModel {
    supplierID: number;
    companyName: string;
    contactName: string;
    contactTitle: string;
    address: BaseAddress;
    communication: BaseCommunication;

    constructor(supplierData: any) {
        super();

        this.supplierID = super.checkUndefinedValue(supplierData.supplierID);
        this.companyName = super.checkUndefinedValue(supplierData.companyName);
        this.contactName = super.checkUndefinedValue(supplierData.contactName);
        this.contactTitle = super.checkUndefinedValue(supplierData.contactTitle);
        this.address = new BaseAddress(supplierData.address);
        this.communication = new BaseCommunication(supplierData.communication);
    }
}