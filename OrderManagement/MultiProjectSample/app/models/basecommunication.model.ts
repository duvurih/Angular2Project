import { BaseModel } from "../models/base.model";

export class BaseCommunication extends BaseModel {
    phone: string;
    fax: string;
    homePage: string;

    constructor(baseCommunicationData: any) {
        super();
        this.phone = super.checkUndefinedValue(baseCommunicationData.phone);
        this.fax = super.checkUndefinedValue(baseCommunicationData.fax);
        this.homePage = super.checkUndefinedValue(baseCommunicationData.homePage);
    }
}