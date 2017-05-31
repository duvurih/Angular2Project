import { BaseAddress } from "../models/baseaddress.model";
import { BaseCommunication } from "../models/basecommunication.model";
import { BaseModel } from "../models/base.model";

export class SupplierModel extends BaseModel {
    supplierID: number;
    companyName: string;
    contactName: string;
    contactTitle: string;
    addressModel: BaseAddress;
    communicationModel: BaseCommunication;

    constructor(supplierData: any) {
        super();

        this.supplierID = super.checkUndefinedValue(supplierData.supplierID);
        this.companyName = super.checkUndefinedValue(supplierData.companyName);
        this.contactName = super.checkUndefinedValue(supplierData.contactName);
        this.contactTitle = super.checkUndefinedValue(supplierData.contactTitle);
        this.addressModel = new BaseAddress(supplierData.addressModel);
        this.communicationModel = new BaseCommunication(supplierData.communicationModel);
    }
}