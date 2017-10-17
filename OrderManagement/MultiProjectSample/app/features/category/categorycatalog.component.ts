// importing angular core
import { Component, OnInit } from "@angular/core";
import { NgRedux, dispatch, select, select$ } from '@angular-redux/store';
import { Observable } from 'rxjs/Observable';

// importing data services
import { CategoryService } from "./services/category.service";

// importing redux actions
import { CategoryAction, CategoryActions } from "./services/category.actions";

// importing data models
import { CategoryModel, ICategory, ICategoryList, CategoryType } from "../../models/category.model";

@Component({
    selector: "category-catalog",
    templateUrl: `app/features/category/categorycatalog.html`,
})
export class CategoryCatalogComponent implements OnInit {

    // initializing variables
    // public productCategories: any = [];

    @select() readonly productCategories$: Observable<ICategory>;

    // constuctor
    constructor(
        private categoryService: CategoryService,
        private categoryActions: CategoryActions
    ) {
    }

    // initialization methods
    ngOnInit(): any {
        // https://www.pluralsight.com/guides/front-end-javascript/ui-state-management-with-redux-in-angular-4

        // https://www.youtube.com/watch?v=YxK4UW4UfCk
        // https://www.youtube.com/watch?v=s4xr2avwv3s
        // this.categoryActions.loadCategories("LOAD_CATEGORIES");

        // this.categoryService.loadAllProductCategories()
        //   .subscribe((resultData: any) => {
        //       this.productCategories = resultData;
        //   });

        // this.productCategories = this.categoryService.loadAll
        //    .subscribe((resultData: any) => {
        //        this.productCategories = resultData;
        //    });
    }



}