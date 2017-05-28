// importing angular core
import { Component, ChangeDetectorRef, OnInit, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

// importing data services
import { DataContextService } from "../../services/datacontext.service";
import { ReferenceDataService } from "../../services/referencedata.service";

// importing models
import { ProductModel } from "../../models/product.model";
import { FilterCriteria } from "../../models/filtercriteria.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "viewproduct",
    templateUrl: "app/features/product/viewproduct.html",
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
export class ViewProductComponent implements OnInit {

    // initializing variables
    public product: any = [];
    public categories: any = [];
    public suppliers: any = [];
    private beforeEditProduct: any = [];
    public validationRules: any = [];
    private resultResponse: any;
    public isEditable: boolean = false;
    public isAdding: boolean = false;

    productForm: FormGroup;

    // constuctor
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private _formBuilder: FormBuilder,
        private dataContextService: DataContextService,
        private referenceDataService: ReferenceDataService,
        private changeDetectorRef: ChangeDetectorRef
    ) {}

    // initialization methods
    ngOnInit(): void {
        this.categories = this.referenceDataService.categoryReferenceData;
        this.suppliers = this.referenceDataService.supplierReferenceData;

        this.productForm = this._formBuilder.group({
            "productID": [""],
            "productName": ["", [Validators.required, Validators.minLength(3), Validators.maxLength(40)]],
            "categoryID": ["", [Validators.required]],
            "supplierID": ["", [Validators.required]],
            "quantityPerUnit": ["", [Validators.required]],
            "unitPrice": ["", [Validators.required]],
            "unitsInStock": ["", [Validators.required]],
            "unitsOnOrder": ["", [Validators.required]],
            "reorderLevel": ["", [Validators.required]],
            "discontinued": [""]
        });

        this.getValidationRules();

        this.activatedRoute.params.subscribe((params: Params) => {
            let productId: number = params["id"];
            //retrieving product - than show view
            this.activatedRoute.data
                .subscribe((data: { product: any }) => {
                    this.product = new ProductModel(data.product)
                });
        });
    }

    // method implementation
    getValidationRules(): void {
        this.dataContextService.httpGet(URLEndPoints.PRODUCT_VALIDATION_RULES, null)
            .subscribe((resultData: any) => {
                // this.product = resultData.data;
                this.validationRules = resultData.validationRules;
            });
    }


    setFilterCriteria(columnName: string, idValue: string): any {
        let caterogyNamefilter: FilterCriteria = { criteriaColumn: columnName, criteriaValue: idValue };
        return caterogyNamefilter;
    }

    addProduct(value: any): void {
        this.product = new ProductModel(value);
        this.isAdding = true;
        this.changeDetectorRef.detectChanges();
    }

    editProduct(): void {
        this.beforeEditProduct = this.product;
        this.isEditable = true;
        this.changeDetectorRef.detectChanges();
    }

    cancelOpertation(): void {
        this.product = this.beforeEditProduct;
        this.isEditable = false;
        this.isAdding = false;
        this.redirectToProdctList();
    }

    redirectToProdctList(): void {
        this.router.navigateByUrl("viewProductsList");
    }

    saveProduct(value: any): void {
        //console.log(value);
        if (this.isAdding === true) {
            this.dataContextService.httpPost(URLEndPoints.PRODUCT_ADD, this.product)
                .subscribe((resultData: any) => {
                    this.product = new ProductModel(resultData);
                    this.isAdding = false;
                });
        } else {
            this.dataContextService.httpPost(URLEndPoints.PRODUCT_UPDATE, this.product)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                    this.isEditable = false;
                });
        }
        //this.changeDetectorRef.detectChanges();
    }
}