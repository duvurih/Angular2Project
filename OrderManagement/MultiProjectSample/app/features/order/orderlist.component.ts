// importing angular core
import { Component, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { OrderModel } from "../../models/order.master.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "orderslist",
    templateUrl: "app/features/order/orderlist.html",
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
export class OrdersListComponent {

    // initializing variables
    public orders: Array<any> = [];
    private resultResponse: any;


    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit(): void {
        this.loadAllOrders();
    }

    // method implementation
    loadAllOrders(): any {
        this.dataContextService.httpGet(URLEndPoints.ORDER_GET_ALL_ORDERS, null)
            .subscribe((resultData: any) => {
                this.orders = resultData;
            });
    }

    deleteOrder(orderId: number): void {
        var order: any = this.orders.filter((item: any) => item["orderID"] === orderId);
        if (order.length === 1) {
            var orderData: OrderModel = new OrderModel(order[0]);
            this.dataContextService.httpPost(URLEndPoints.ORDER_DELETE, orderData)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                });
        }
    }
}