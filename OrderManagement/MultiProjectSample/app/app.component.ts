import { Component, OnInit, ViewContainerRef, AfterViewInit, trigger, state, style, transition, animate } from "@angular/core";

// add the RxJS Observable operators we need in this app.
import "./rxjs-operators";

// importing service
import { ReferenceDataService } from "./services/referencedata.service";

@Component({
    selector: "my-app",
    templateUrl: "app/app.html",
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
export class AppComponent implements OnInit, AfterViewInit {

    constructor(private viewContainerRef: ViewContainerRef,
        private referenceDataService: ReferenceDataService
    ) {
        this.viewContainerRef = viewContainerRef;
    }

    ngOnInit(): void {
    }

    ngAfterViewInit(): void {
        this.referenceDataService.retrieveReferenceData();
    }

    name = "Angular v2.4 Application";
}