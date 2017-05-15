// importing angular core
import { Component, OnInit } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";


@Component({
    selector: "dashboard",
    templateUrl: "app/features/dashboard/dashboard.html",
})
export class DashboardComponent implements OnInit {

    // initializing variables
    public settings: any = [];

    // constuctor
    constructor(
        private dataContextService: DataContextService) {
    }

    // initialization methods
    ngOnInit():void {
        this.loadAllSettings();
    }


    // method implementation
    loadAllSettings():any {
        // this.dataContextService.httpGet("CategoryApiWeb/GetAllCategories", null)
        //    .subscribe((resultData:any) => {
        //        this.products = resultData;
        // });
    }
}