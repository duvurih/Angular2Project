// importing angular core
import { Component, OnInit, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { SupplierModel } from "../../models/supplier.model";
import { FilterCriteria } from "../../models/filtercriteria.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "viewsupplier",
    templateUrl: "app/features/supplier/viewsupplier.html",
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
export class ViewSupplierComponent implements OnInit {

    // initializing variables
    public supplier: SupplierModel;
    private beforeEditSupplier: any = [];
    public validationRules: any = [];
    private resultResponse: any;
    public isEditable: boolean = false;
    public isAdding: boolean = false;

    supplierForm: FormGroup;

    // constuctor
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private _formBuilder: FormBuilder,
        private dataContextService: DataContextService
    ) { }

    // initialization methods
    ngOnInit(): void {

        this.supplierForm = this._formBuilder.group({
            "supplierID": [""],
            "companyName": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(40)]],
            "contactName": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "contactTitle": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "address": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(60)]],
            "city": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
            "region": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
            "postalCode": ["", [Validators.required, Validators.minLength(4), Validators.maxLength(4)]],
            "country": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(15)]],
            "phone": ["", [Validators.required, Validators.minLength(8), Validators.maxLength(12)]],
            "fax": ["", [Validators.minLength(8), Validators.maxLength(12)]],
            "homePage": ["", [Validators.maxLength(100)]]
        });

        this.getValidationRules();

        this.activatedRoute.params.subscribe((params: Params) => {
            let supplierId: number = params["id"];
            this.getSupplierByID(supplierId);
        });
    }


    // method implementation
    getValidationRules(): void {
        this.dataContextService.httpGet(URLEndPoints.SUPPLIER_VALIDATION_RULES, null)
            .subscribe((resultData: any) => {
                this.supplier = new SupplierModel(resultData.data);
                this.validationRules = resultData.validationRules;
            });
    }

    getSupplierByID(supplierId: number): void {
        this.dataContextService.httpGet(URLEndPoints.SUPPLIER_GET_SUPPLIER_BY_ID + supplierId, null)
            .subscribe((resultData: any) => {
                this.supplier = new SupplierModel(resultData);
            });
    }

    setFilterCriteria(columnName: string, idValue: string): any {
        let caterogyNamefilter: FilterCriteria = { criteriaColumn: columnName, criteriaValue: idValue };
        return caterogyNamefilter;
    }

    addSupplier(value: any): void {
        this.supplier = new SupplierModel(value);
        this.isAdding = true;
    }

    editSupplier(): void {
        this.beforeEditSupplier = this.supplier;
        this.isEditable = true;
    }

    cancelOpertation(): void {
        this.supplier = this.beforeEditSupplier;
        this.isEditable = false;
        this.isAdding = false;
        this.router.navigateByUrl("viewSupplierList");
    }

    saveSupplier(value: any): void {
        console.log(value);
        if (this.isAdding === true) {
            this.dataContextService.httpPost(URLEndPoints.SUPPLIER_ADD, this.supplier)
                .subscribe((resultData: any) => {
                    this.supplier = new SupplierModel(resultData);
                    this.isAdding = false;
                });
        } else {
            this.dataContextService.httpPost(URLEndPoints.SUPPLIER_UPDATE, this.supplier)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                    this.isEditable = false;
                });
        }
    }
}