import { BaseModel } from "../models/base.model";

export class BaseCommunication extends BaseModel {
    phone: string;
    fax: string;
    homePage: string;

    constructor(baseCommunicationData: any) {
        super();

        baseCommunicationData = (baseCommunicationData === undefined) ? "" : baseCommunicationData;
        this.phone = super.checkUndefinedValue(baseCommunicationData.phone);
        this.fax = super.checkUndefinedValue(baseCommunicationData.fax);
        this.homePage = super.checkUndefinedValue(baseCommunicationData.homePage);
    }
}