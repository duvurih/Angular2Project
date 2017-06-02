// importing angular core
import { Component, ChangeDetectorRef, OnInit, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { OrderModel } from "../../models/order.master.model";
import { FilterCriteria } from "../../models/filtercriteria.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "vieworder",
    templateUrl: "app/features/order/vieworder.html",
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
export class ViewOrderComponent implements OnInit {

    // initializing variables
    public order: OrderModel;
    private beforeEditOrder: any = [];
    public validationRules: any = [];
    private resultResponse: any;
    public isEditable: boolean = false;
    public isAdding: boolean = false;

    orderForm: FormGroup;

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

        this.orderForm = this._formBuilder.group({
            "orderID": [""],
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
            "homePage": ["", [Validators.maxLength(100)]]
        });

        this.getValidationRules();

        this.activatedRoute.params.subscribe((params: Params) => {
            let orderId: number = params["id"];
            // retrieving order - than show view
            this.activatedRoute.data
                .subscribe((data: { order: any }) => {
                    this.order = new OrderModel(data.order);
                });
        });
    }


    // method implementation
    getValidationRules(): void {
        this.dataContextService.httpGet(URLEndPoints.ORDER_VALIDATION_RULES, null)
            .subscribe((resultData: any) => {
                //this.order = new OrderModel(resultData.data);
                this.validationRules = resultData.validationRules;
            });
    }

    getOrderByID(orderId: number): void {
        this.dataContextService.httpGet(URLEndPoints.ORDER_GET_ORDER_BY_ID + orderId, null)
            .subscribe((resultData: any) => {
                this.order = new OrderModel(resultData);
            });
    }

    setFilterCriteria(columnName: string, idValue: string): any {
        let caterogyNamefilter: FilterCriteria = { criteriaColumn: columnName, criteriaValue: idValue };
        return caterogyNamefilter;
    }

    addOrder(value: any): void {
        this.order = new OrderModel(value);
        this.isAdding = true;
        this.changeDetectorRef.detectChanges();
    }

    editOrder(): void {
        this.beforeEditOrder = this.order;
        this.isEditable = true;
        this.changeDetectorRef.detectChanges();
    }

    cancelOpertation(): void {
        this.order = this.beforeEditOrder;
        this.isEditable = false;
        this.isAdding = false;
        this.router.navigateByUrl("viewOrderList");
    }

    saveOrder(value: any): void {
        console.log(value);
        if (this.isAdding === true) {
            this.dataContextService.httpPost(URLEndPoints.ORDER_ADD, this.order)
                .subscribe((resultData: any) => {
                    this.order = new OrderModel(resultData);
                    this.isAdding = false;
                });
        } else {
            this.dataContextService.httpPost(URLEndPoints.ORDER_UPDATE, this.order)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                    this.isEditable = false;
                });
        }
    }
}