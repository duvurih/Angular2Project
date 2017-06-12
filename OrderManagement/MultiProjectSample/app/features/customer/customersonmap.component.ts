// importing angular core
import { Component, OnInit, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "customers-on-map",
    templateUrl: "app/features/customer/customersonmap.html",
    animations: [
        trigger("flyInOut", [
            state("in", style({ opacity: 1, transform: "translateX(0)" })),
            transition("void => *", [
                style({
                    opacity: 0,
                    transform: "translateX(-100%)"
                }),
                animate("0.5s ease-in")
            ]),
            transition("* => void", [
                animate("0.2s 10 ease-out", style({
                    opacity: 0,
                    transform: "translateX(100%)"
                }))
            ])
        ])
    ]
})
export class CustomersOnMapComponent implements OnInit {

    // initializing variables
    public customers: Array<any> = [];
    public customerFullAddress: string;
    public selectedCustomer: string;

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit(): void {
        this.loadAllCustomers();
    }

    // method implementation
    loadAllCustomers(): any {
        this.dataContextService.httpGet(URLEndPoints.CUSTOMER_GET_ALL_CUSTOMEMRS, null)
            .subscribe((resultData: any) => {
                this.customers = resultData;
            });
    }
}