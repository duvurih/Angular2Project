// importing angular core modules
import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { of } from 'rxjs/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/startWith';

// importing data services
import { DataContextService } from "../../../services/datacontext.service";
import { CategoryAction, CategoryActions } from "./category.actions";

// importing url endpoints
import { URLEndPoints } from "../../../common/urlendpoints.component";

// importing store
import { IAppState } from "../../../redux/app-state";

// importing data models
import { CategoryModel, ICategory, ICategoryList, CategoryType } from "../../../models/category.model";


@Injectable()
export class CategoryService {

    // constuctor
    constructor(
        private dataContextService: DataContextService,
        private categoryActions: CategoryActions
    ) {
    }

    // method implementation
    loadAllProductCategories(): Observable<any> {
        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.CATEGORY_GET_ALL_CATEGORIES, null)
        );

        //return Observable.from(
        //    this.dataContextService.httpGet(URLEndPoints.CATEGORY_GET_ALL_CATEGORIES, null)
        //        .map((payload: ICategory[]) => {
        //            return { type: categoryType, payload };
        //        })
        //        .subscribe((action) => {
        //            this.
        //        })
        //);
    }

    // loadAll = (categoryType: CategoryType): Observable<ICategory[]> =>
    //    this.dataContextService.httpGet(URLEndPoints.CATEGORY_GET_ALL_CATEGORIES, null);

    loadAll(categoryType: CategoryType) {
        return (action$, store) => action$
            .ofType(CategoryActions.LOAD_CATEGORIES)
            .switchMap(a => this.dataContextService.httpGet(URLEndPoints.CATEGORY_GET_ALL_CATEGORIES, null)
                .map(data => this.categoryActions.loadSucceeded(categoryType, data))
            )
            .startWith(this.categoryActions.loadStarted(categoryType));
    }

}