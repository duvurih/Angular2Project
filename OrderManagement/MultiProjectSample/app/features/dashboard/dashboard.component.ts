// importing angular core
import { Component, OnInit, trigger, state, style, transition, animate } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "dashboard",
    templateUrl: "app/features/dashboard/dashboard.html",
    animations: [
        trigger("flyInOut", [
            state("in", style({ opacity: 1, transform: "translateX(0)" })),
            transition("void => *", [
                style({
                    opacity: 0,
                    transform: "translateX(-100%)"
                }),
                animate("0.6s ease-in")
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
export class DashboardComponent implements OnInit {

    // initializing variables
    public settings: any = [];
    visible = false;

    // constuctor
    constructor(
        private dataContextService: DataContextService) {}

    // initialization methods
    ngOnInit(): void {

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