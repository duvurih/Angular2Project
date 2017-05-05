//Importing angular core
import { Component, OnInit } from '@angular/core';

//Importing data services
import { DataContextService } from '../../services/datacontext.service';


@Component({
    selector: 'dashboard',
    templateUrl: `app/features/dashboard/dashboard.html`,
})
export class DashboardComponent implements OnInit {

    //initializing variables
    public products: any = [];

    //constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    //Initialization methods
    ngOnInit() {
        this.loadAllProducts();
    }


    //method implementation
    loadAllProducts() {
        this.dataContextService.httpGet('ProductApiWeb/GetAllProducts', null)
            .subscribe((resultData:any) => {
                this.products = resultData;
        });
    }
}