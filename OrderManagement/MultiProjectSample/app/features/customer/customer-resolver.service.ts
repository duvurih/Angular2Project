// importing angular core
import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { CustomerModel } from "../../models/customer.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Injectable()
export class CustomerResolverService implements Resolve<CustomerModel> {

    constructor(private dataContextService: DataContextService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<CustomerModel> | Promise<CustomerModel> | any {
        let customerId: string = route.params["id"];

        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.CUSTOMER_GET_CUSTOMER_BY_ID + customerId, null)
        );
    }
}
