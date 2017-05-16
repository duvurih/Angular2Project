// importing angular core
import { Component } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "productslist",
    templateUrl: "app/features/product/productslist.html",
})
export class ProductsListComponent {

    // initializing variables
    public products: Array<any> = [];

    public columns: Array<any> = [
        { title: "Product ID", name: "productID", sort:false },
        { title: "Product Name", name: "productName", sort: "asc"},
        { title: "Unit Price ($)", name: "unitPrice", sort:"desc" }
    ];

    public config: any = {
        paging: true,
        sorting: { columns: this.columns },
        className: ['table-striped', 'table-bordered']
    };

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit():void {
        this.loadAllProducts();
    }


    // method implementation
    loadAllProducts():any {
        this.dataContextService.httpGet("ProductApiWeb/GetAllProducts", null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }
}