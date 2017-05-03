import { Component, Input } from '@angular/core';

@Component({
    selector: 'productslist',
    templateUrl: `app/features/product/productslist.html`,
})
export class ProductsListComponent {

    //input variables
    @Input() products: any=[];

    //constuctor
    constructor() {
    }

}