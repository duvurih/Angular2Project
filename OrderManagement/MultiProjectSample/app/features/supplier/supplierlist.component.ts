// importing angular core
import { Component, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { SupplierModel } from "../../models/supplier.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "supplierslist",
    templateUrl: "app/features/supplier/supplierlist.html",
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
export class SuppliersListComponent {

    // initializing variables
    public suppliers: Array<any> = [];
    private resultResponse: any;


    public columns: Array<any> = [
        { title: "Customer ID", name: "customerID", sort: false },
        { title: "Company Name", name: "companyName", sort: "asc" },
        { title: "Contact Name", name: "contactName", sort: "desc" }
    ];

    public config: any = {
        paging: true,
        sorting: { columns: this.columns },
        className: ["table-striped", "table-bordered"]
    };

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit(): void {
        this.loadAllSuppliers();
    }

    // method implementation
    loadAllSuppliers(): any {
        this.dataContextService.httpGet(URLEndPoints.SUPPLIER_GET_ALL_SUPPLIERS, null)
            .subscribe((resultData: any) => {
                this.suppliers = resultData;
            });
    }

    viewSupplierDetials(supplierId: number): any {
        this.dataContextService.httpGet(URLEndPoints.SUPPLIER_GET_SUPPLIER_BY_ID + supplierId, null)
            .subscribe((resultData: any) => {
                this.suppliers = resultData;
            });
    }

    deleteProduct(supplierId: number): void {
        var product:any = this.suppliers.filter(item => item["supplierID"] === supplierId);
        if (product.length === 1) {
            var supplierData:SupplierModel = new SupplierModel(product[0]);
            this.dataContextService.httpPost(URLEndPoints.SUPPLIER_DELETE, supplierData)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                });
        }
    }
}