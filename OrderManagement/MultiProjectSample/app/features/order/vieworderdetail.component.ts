// importing angular core
import { Component, ViewChild, ChangeDetectorRef, Input, Output, OnInit, EventEmitter } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { Modal } from "ng2-modal";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { OrderDetailModel } from "../../models/order.details.model";
import { FilterCriteria } from "../../models/filtercriteria.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "vieworderdetail",
    templateUrl: "app/features/order/vieworderdetail.html"
})
export class ViewOrderDetailComponent implements OnInit {

    // initializing variables
    @Input() orderdetail: OrderDetailModel;
    @Input() showView: boolean;
    @Output() orderUpdated: EventEmitter<any> = new EventEmitter<any>();
    @ViewChild("viewOrderDetailsModal") viewOrderDetailsModal: Modal;

    public validationRules: any = [];
    private resultResponse: any;
    public isEditable: boolean = false;
    public isAdding: boolean = false;

    orderForm: FormGroup;

    // constuctor
    constructor(
        private _formBuilder: FormBuilder,
        private dataContextService: DataContextService,
        private changeDetectorRef: ChangeDetectorRef
    ) { }

    // initialization methods
    ngOnInit(): void {

        this.orderForm = this._formBuilder.group({
            "orderID": [""],
            "productID": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(40)]],
            "unitPrice": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "quantity": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(30)]],
            "discount": ["", [Validators.required, Validators.minLength(1), Validators.maxLength(60)]],
        });

        this.getValidationRules();

    }

    // method implementation
    getValidationRules(): void {
        this.dataContextService.httpGet(URLEndPoints.ORDER_DETAIL_VALIDATION_RULES, null)
            .subscribe((resultData: any) => {
                //this.order = new OrderModel(resultData.data);
                this.validationRules = resultData.validationRules;
            });
    }

    addOrder(value: any): void {
        this.orderdetail = new OrderDetailModel(value);
        this.isAdding = true;
        this.changeDetectorRef.detectChanges();
    }

    editOrder(): void {
        this.isEditable = true;
        this.changeDetectorRef.detectChanges();
    }

    saveOrder(value: any): void {
        console.log(value);
        if (this.isAdding === true) {
        } else {
        }
    }

    close(): void {
        this.isEditable = false;
        this.isAdding = false;
        this.orderUpdated.emit({ value: this.orderdetail });
        this.viewOrderDetailsModal.close();
    }

    showOrderDetail(): void {
        this.viewOrderDetailsModal.open();
    }
}