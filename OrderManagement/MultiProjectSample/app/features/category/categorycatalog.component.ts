// importing angular core
import { Component, OnInit } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";


@Component({
    selector: "category-catalog",
    templateUrl: `app/features/category/categorycatalog.html`,
})
export class CategoryCatalogComponent implements OnInit {

    // initializing variables
    public productCategories: any = [];

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit():any {
        this.loadAllProductCategories();
    }


    // method implementation
    loadAllProductCategories():any {
        this.dataContextService.httpGet("CategoryApiWeb/GetAllCategories", null)
            .subscribe((resultData: any) => {
                this.productCategories = resultData;
            });
    }
}