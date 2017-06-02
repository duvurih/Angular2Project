// importing angular core
import { Component, ViewChild, Input} from "@angular/core";

// child application component
import { ViewOrderDetailComponent } from "../../features/order/vieworderdetail.component";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { OrderDetailModel } from "../../models/order.details.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

@Component({
    selector: "orderdetaillist",
    templateUrl: "app/features/order/orderdetaillist.html"
})
export class OrderDetailsListComponent {

    // initializing variables
    @Input() orderdetails: Array<any> = [];
    @ViewChild(ViewOrderDetailComponent) viewOrderDetailComponent: ViewOrderDetailComponent;
    public selectedOrder: any;
    private resultResponse: any;
    public isViewOrderDetail: boolean;
    public isOrderDetailsDataLoaded: boolean = false;

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
        this.isViewOrderDetail = true;
    }


    // methods
    showOrderDetail(orderId: number, productId: number): void {
        var order: any = this.orderdetails.filter((item: any) => (item["orderID"] === orderId && item["productID"] === productId));
        if (order.length === 1) {
            this.selectedOrder = new OrderDetailModel(order[0]);
            this.isOrderDetailsDataLoaded = true;
            this.viewOrderDetailComponent.showOrderDetail();
        }
    }

    onUpdatedOrder($event: any): void {
        this.isOrderDetailsDataLoaded = false;
        this.selectedOrder = $event.value;
    }

    deleteOrder(orderId: number, productId:number): void {
        var order: any = this.orderdetails.filter((item: any) => (item["orderID"] === orderId && item["productID"]===productId));
        if (order.length === 1) {
            var orderDetailData: OrderDetailModel = new OrderDetailModel(order[0]);
            this.dataContextService.httpPost(URLEndPoints.ORDER_DETAIL_DELETE, orderDetailData)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                });
        }
    }
}