// importing angular core
import { Component, OnInit, Input } from "@angular/core";


@Component({
    selector: "tab-element",
    templateUrl: "app/layout/tabs/tab.html"
})
export class TabComponent implements OnInit {

    @Input() title: string; 
    isActive: boolean = false;

    // constuctor
    constructor() {
    }

    // initialization methods
    ngOnInit(): void {

    }


}