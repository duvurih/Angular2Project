// importing angular core
import { Component, Input } from "@angular/core";

// importing data services
import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "custom-chart",
    styles: [`
      chart {
        display: block;
        height: auto;
      }
    `],
    template: `<chart [options]="data" style="height: 250px;"></chart>`
})
export class ChartComponent {

    // initializing variables
    @Input() data: Object;

    // constuctor
    constructor() {
    }





}