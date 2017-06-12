// importing angular core
import { Component, trigger, state, style, transition, animate } from "@angular/core";
import { Router, ActivatedRoute, Params } from "@angular/router";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

// importing models
import { ProductModel } from "../../models/product.model";

// importing url endpoints
import { URLEndPoints } from "../../common/urlendpoints.component";

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
    private resultResponse: any;
    private actionEdit = '<a class="action-btn edit" href="#topinfo" [routerLink]="["/viewProduct/", product.productID]"><i class="fa fa-pencil-square-o" aria-hidden="true"></i></a>';
    private actionDelete = '<a class="action-btn remove"><i class="fa fa-trash-o" aria-hidden="true"></i></a>';

    public columns: Array<any> = [
        { title: "Product ID", name: "productID", sort:false },
        { title: "Product Name", name: "productName", sort: "asc"},
        { title: "Unit Price ($)", name: "unitPrice", sort: "desc" },
        { title: '', name: 'actionEdit', sort: false, className: 'accepter-col-action' },
        { title: '', name: 'actionDelete', sort: false, className: 'accepter-col-action' }
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
                this.activatedRoute.data
                    .subscribe((data: { products: any }) => {
                        this.products = data.products
                    });
            }
        });
    }


    // method implementation
    loadProductsByCategory(id:number): any {
        this.dataContextService.httpGet(URLEndPoints.PRODUCT_GET_PRODUCT_BY_CATEGORY + id , null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }


    viewProductDetials(productId: number):any {
        this.dataContextService.httpGet(URLEndPoints.PRODUCT_GET_PRODUCT_BY_ID + productId, null)
            .subscribe((resultData: any) => {
                this.products = resultData;
            });
    }

    deleteProduct(productId: number): void {
        var product:any = this.products.filter(item => item["productID"] === productId);
        if (product.length === 1) {
            var productData:ProductModel = new ProductModel(product[0]);
            this.dataContextService.httpPost(URLEndPoints.PRODUCT_DELETE, productData)
                .subscribe((resultData: any) => {
                    this.resultResponse = resultData;
                });
        }
    }
}