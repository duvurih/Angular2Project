export class ProductModel {
    productID: number;
    productName: string;
    supplierID: number;
    categoryID: number;
    quantityPerUnit: string;
    unitPrice: number;
    unitsInStock: number;
    unitsOnOrder: number;
    reorderLevel: number;
    discontinued: number;

    constructor(productData: any) {
        this.productID= productData.productID;
        this.productName = productData.productName;
        this.supplierID = productData.supplierID;
        this.categoryID = productData.categoryID;
        this.quantityPerUnit = productData.quantityPerUnit;
        this.unitPrice = productData.unitPrice;
        this.unitsInStock = productData.unitsInStock;
        this.unitsOnOrder = productData.unitsOnOrder;
        this.reorderLevel = productData.reorderLevel;
        this.discontinued = productData.discontinued;
    }
}