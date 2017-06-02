// importing angular core
import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { OrderModel } from "../../models/order.master.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Injectable()
export class OrderResolverService implements Resolve<OrderModel> {

    constructor(private dataContextService: DataContextService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<OrderModel> | Promise<OrderModel> | any {
        let orderId: number = route.params["id"];

        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.ORDER_GET_ORDER_BY_ID + orderId, null)
        );
    }
}
