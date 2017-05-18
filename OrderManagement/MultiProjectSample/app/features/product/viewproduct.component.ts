// importing angular core
import { Component, Input, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "productslist",
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
export class ViewProductComponent {

    // initializing variables
    public product: any = [];
    private resultResponse: any;

    @Input() productId: number;

    // constuctor
    constructor(
        private dataContextService: DataContextService) { }

    // initialization methods
    ngOnInit(): void {
        this.getProductByID(this.productId);
    }


    // method implementation
    getProductByID(productId:number): void {
        this.dataContextService.httpGet("ProductApiWeb/GetProductByID/" + productId, null)
            .subscribe((resultData: any) => {
                this.product = resultData;
            });
    }

    editProduct(): any {

    }

    deleteProduct(): void {

    }

    saveProduct(): void {
        this.dataContextService.httpPost("ProductApiWeb/EditProduct", this.product)
            .subscribe((resultData: any) => {
                this.resultResponse = resultData;
            });
    }
}