// importing angular core
import { Component, ChangeDetectorRef, OnInit, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { CustomerModel } from "../../models/customer.model";
import { FilterCriteria } from "../../models/filtercriteria.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "viewcustomer",
    templateUrl: "app/features/customer/viewcustomer.html",
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
export class ViewCustomerComponent implements OnInit {

    // initializing variables
    public customer: CustomerModel;
    private beforeEditCustomer: any = [];
    public validationRules: any = [];
    private resultResponse: any;
    public isEditable: boolean = false;
    public isAdding: boolean = false;

    customerForm: FormGroup;

    // constuctor
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private _formBuilder: FormBuilder,
        private dataContextService: DataContextService,
        private changeDetectorRef: ChangeDetectorRef
    ) { }

    // initialization methods
    ngOnInit(): void {

        this.customerForm = this._formBuilder.group({
            "customerID": [""],
            "companyName": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(40)]],
            "contactName": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "contactTitle": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "address": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(60)]],
            "city": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
            "region": ["", [Validators.maxLength(15)]],
            "postalCode": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(10)]],
            "country": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
            "phone": ["", [Validators.minLength(8), Validators.maxLength(24)]],
            "fax": ["", [Validators.minLength(8), Validators.maxLength(24)]],
        });

        this.getValidationRules();

        this.activatedRoute.params.subscribe((params: Params) => {
            let customerId: string = params["id"];
            // retrieving customer - than show view
            this.activatedRoute.data
                .subscribe((data: { customer: any }) => {
                    this.customer = new CustomerModel(data.customer);
                });
        });
    }


    // method implementation
    getValidationRules(): void {
        this.dataContextService.httpGet(URLEndPoints.CUSTOMER_VALIDATION_RULES, null)
            .subscribe((resultData: any) => {
                // this.customer = new CustomerModel(resultData.data);
                this.validationRules = resultData.validationRules;
            });
    }

    getCustomerByID(customerId: number): void {
        this.dataContextService.httpGet(URLEndPoints.CUSTOMER_GET_CUSTOMER_BY_ID + customerId, null)
            .subscribe((resultData: any) => {
                this.customer = new CustomerModel(resultData);
            });
    }

    setFilterCriteria(columnName: string, idValue: string): any {
        let caterogyNamefilter: FilterCriteria = { criteriaColumn: columnName, criteriaValue: idValue };
        return caterogyNamefilter;
    }

    addCustomer(value: any): void {
        this.customer = new CustomerModel(value);
        this.isAdding = true;
        this.changeDetectorRef.detectChanges();
    }

    editCustomer(): void {
        this.beforeEditCustomer = this.customer;
        this.isEditable = true;
        this.changeDetectorRef.detectChanges();
    }

    cancelOpertation(): void {
        this.customer = this.beforeEditCustomer;
        this.isEditable = false;
        this.isAdding = false;
        this.router.navigateByUrl("viewCustomerList");
    }

    saveCustomer(value: any): void {
        console.log(value);
        if (this.isAdding === true) {
            this.dataContextService.httpPost(URLEndPoints.SUPPLIER_ADD, this.customer)
                .subscribe((resultData: any) => {
                    this.customer = new CustomerModel(resultData);
                    this.isAdding = false;
                });
        } else {
            this.dataContextService.httpPost(URLEndPoints.SUPPLIER_UPDATE, this.customer)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                    this.isEditable = false;
                });
        }
    }
}