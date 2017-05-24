export class SupplierModel {
    supplierID: number;
    companyName: string;
    contactName: string;
    contactTitle: string;
    address: string;
    city: string;
    region: string;
    postalCode: number;
    country: string;
    phone: string;
    fax: string;
    homePage: string;

    constructor(supplierData:any) {
        this.supplierID = supplierData.supplierID;
        this.companyName = supplierData.companyName;
        this.contactName = supplierData.contactName;
        this.contactTitle = supplierData.contactTitle;
        this.address = supplierData.address;
        this.city = supplierData.city;
        this.region = supplierData.region;
        this.postalCode = supplierData.postalCode;
        this.country = supplierData.country;
        this.phone = supplierData.phone;
        this.fax = supplierData.fax;
        this.homePage = supplierData.homePage;
    }
}