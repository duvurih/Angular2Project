// importing angular core
import { Component, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { CustomerModel } from "../../models/customer.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "customerslist",
    templateUrl: "app/features/customer/customerlist.html",
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
export class CustomersListComponent {

    // initializing variables
    public customers: Array<any> = [];
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
        this.loadAllCustomers();
    }

    // method implementation
    loadAllCustomers(): any {
        this.dataContextService.httpGet(URLEndPoints.CUSTOMER_GET_ALL_CUSTOMEMRS, null)
            .subscribe((resultData: any) => {
                this.customers = resultData;
            });
    }

    viewCustomerDetials(customerId: number): any {
        this.dataContextService.httpGet(URLEndPoints.CUSTOMER_GET_CUSTOMER_BY_ID + customerId, null)
            .subscribe((resultData: any) => {
                this.customers = resultData;
            });
    }

    deleteCustomer(customerId: number): void {
        var customer: any = this.customers.filter((item:any) => item["customerID"] === customerId);
        if (customer.length === 1) {
            var customerData: CustomerModel = new CustomerModel(customer[0]);
            this.dataContextService.httpPost(URLEndPoints.CUSTOMER_DELETE, customerData)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                });
        }
    }
}