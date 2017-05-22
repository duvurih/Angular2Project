// importing angular core
import { Component, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "productslist",
    templateUrl: "app/features/product/productslist.html",
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
        className: ["table-striped", "table-bordered"]
    };

    // constuctor
    constructor(
        private router: Router,
        private activatedRoute: ActivatedRoute,
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit(): void {
        this.activatedRoute.params.subscribe((params: Params) => {
            /* tslint:disable:no-string-literal */
            let categoryId: number = params["id"];
            /* tslint:enable:no-string-literal */

            if (categoryId !== undefined) {
                this.loadProductsByCategory(categoryId);
            } else {
                this.loadAllProducts();
            }
        });
    }


    // method implementation
    loadAllProducts():any {
        this.dataContextService.httpGet("ProductApiWeb/GetAllProducts", null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }

    loadProductsByCategory(id:number): any {
        this.dataContextService.httpGet("ProductApiWeb/GetProductsByCategory/" + id , null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }


    viewProductDetials(productId: number):any {
        this.dataContextService.httpGet("ProductApiWeb/GetProductByID/" + productId, null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }
}