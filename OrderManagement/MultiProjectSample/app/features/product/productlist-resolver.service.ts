// importing angular core
import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { ProductModel } from "../../models/product.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Injectable()
export class ProductListResolverService implements Resolve<ProductModel> {

    constructor(private dataContextService: DataContextService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ProductModel> | Promise<ProductModel> | any {

        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.PRODUCT_GET_ALL_PRODUCTS, null)
            //this.getProductByID(productId);
        );
    }

}
