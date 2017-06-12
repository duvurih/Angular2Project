// importing angular core
import { Component, OnInit, trigger, state, style, transition, animate } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "customersearch",
    templateUrl: "app/features/customer/customersearch.html",
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
export class CustomerSearchComponent implements OnInit {

    // initializing variables
    public customer: any;
    public customerSearchFrm: FormGroup;
    public isSearchResult: boolean = false;
    public customerFullAddress: string;
    public selectedCustomer: string;

    // constuctor
    constructor(
        private dataContextService: DataContextService,
        private _formBuilder: FormBuilder
    ) {
    }

    // initialization methods
    ngOnInit(): void {
        this.customerSearchFrm = this._formBuilder.group({
            "customerSearch": [""],
        });
    }

    // method implementation
    viewSelectedCustomer(values: any) {
        this.isSearchResult = true;
        this.customer = values;
        // this.customerFullAddress = this.customer.address + ' ' + this.customer.city + ' ' + this.customer.region + ' ' + this.customer.country + ' ' + this.customer.postalCode;
        this.customerFullAddress = this.customer.address + ' ' + this.customer.city + ' ' + this.customer.country + ' ' + this.customer.postalCode;
        this.selectedCustomer = this.customer.companyName;
        if (values.companyName === null || values.companyName === undefined) {
            this.isSearchResult = false;
        }
    }
}