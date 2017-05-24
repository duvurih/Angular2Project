import { Component, OnInit, ViewContainerRef } from "@angular/core";

// add the RxJS Observable operators we need in this app.
import "./rxjs-operators";

// importing service
import { ReferenceDataService } from "./services/referencedata.service";

@Component({
    selector: 'my-app',
    template: `
        <dashboard></dashboard>
        `,
})
export class AppComponent implements OnInit {

    constructor(private viewContainerRef: ViewContainerRef,
        private referenceDataService: ReferenceDataService
    ) {
        this.viewContainerRef = viewContainerRef;
    }

    ngOnInit():void{
        this.referenceDataService.retrieveReferenceData();    
    }

    name = 'Angular v2.4 Application';
}