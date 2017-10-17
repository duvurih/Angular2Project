// importing angular modules
import { Injectable } from "@angular/core";
import { NgRedux } from "@angular-redux/store";

// importing data services
import { DataContextService } from "../services/datacontext.service";

// importing data models
import { CategoryModel } from "../models/category.model";
import { SupplierModel } from "../models/supplier.model";

// importing redux store
import { IAppState } from "../redux/app-state";
import { CategoryAction, CategoryActions } from "../features/category/services/category.actions";

@Injectable()
export class ReferenceDataService {
    public categoryReferenceData: CategoryModel[];
    public supplierReferenceData: SupplierModel[];

    constructor(
        private dataContextService: DataContextService,
        private ngRedux: NgRedux<IAppState>
    ) {

    }

    retrieveReferenceData(): void {
        // this.ngRedux.dispatch({ type: RETRIEVE_CATEGORIES_DATA})
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
