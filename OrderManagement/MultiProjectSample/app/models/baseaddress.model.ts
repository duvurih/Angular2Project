import { BaseModel } from "../models/base.model";

export class BaseAddress extends BaseModel {
    address: string;
    city: string;
    region: string;
    postalCode: number;
    country: string;
    constructor(baseAddressData: any) {
        super();

        baseAddressData = (baseAddressData === undefined) ? "" : baseAddressData;
        this.address = super.checkUndefinedValue(baseAddressData.address);
        this.city = super.checkUndefinedValue(baseAddressData.city);
        this.region = super.checkUndefinedValue(baseAddressData.region);
        this.postalCode = super.checkUndefinedValue(baseAddressData.postalCode);
        this.country = super.checkUndefinedValue(baseAddressData.country);
    }


}