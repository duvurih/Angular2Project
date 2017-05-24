// importing angular modules
import { Injectable } from "@angular/core";

// importing data services
import { DataContextService } from "../services/datacontext.service";

// importing data models
import { CategoryModel } from "../models/category.model";
import { SupplierModel } from "../models/supplier.model";

@Injectable()
export class ReferenceDataService {
    public categoryReferenceData: CategoryModel[];
    public supplierReferenceData: SupplierModel[];

    constructor(private dataContextService: DataContextService) {}

    retrieveReferenceData():void {
        this.retrieveCategoriesData();
        this.retrieveSupplierssData();
    }

    private retrieveCategoriesData(): void {
        this.dataContextService.httpGet("CategoryApiWeb/GetAllCategories", null)
            .subscribe((resultData: any) => {
                this.categoryReferenceData = resultData;
            });
    }

    private retrieveSupplierssData(): void {
        this.dataContextService.httpGet("SupplierApiWeb/GetAllSuppliers", null)
            .subscribe((resultData: any) => {
                this.supplierReferenceData = resultData;
            });
    }

}
