// importing angular core
import { Injectable } from "@angular/core";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";
import { Observable } from "rxjs/Observable";

// importing data services
import { DataContextService } from "../services/datacontext.service";

// importing url endpoints
import { URLEndPoints } from "../common/urlendpoints.component";

@Injectable()
export class DataResolverService<T> implements Resolve<T> {

    constructor(private dataContextService: DataContextService, private router: Router) { }

    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<T> | Promise<T> | any {
        return Observable.from(
            this.dataContextService.httpGet(URLEndPoints.ORDER_GET_ORDER_BY_ID, null)
        );
    }
}
