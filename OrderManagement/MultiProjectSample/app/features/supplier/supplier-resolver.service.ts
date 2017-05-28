// importing angular core
import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { SupplierModel } from "../../models/supplier.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Injectable()
export class SupplierResolverService implements Resolve<SupplierModel> {

    constructor(private dataContextService: DataContextService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<SupplierModel> | Promise<SupplierModel> | any {
        let supplierId:number = route.params["id"];

        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.SUPPLIER_GET_SUPPLIER_BY_ID + supplierId, null)
        );
    }
}
