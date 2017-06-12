// importing angular core
import { Component, OnInit, ContentChildren, QueryList, AfterContentInit } from "@angular/core";

import { TabComponent } from "./tab.component";

@Component({
    selector: "tabs-set",
    templateUrl: "app/layout/tabs/tabs.html"
})
export class TabsComponent implements OnInit, AfterContentInit {

    @ContentChildren(TabComponent) tabs: QueryList<TabComponent>;

    // constuctor
    constructor() {
    }

    // initialization methods
    ngOnInit(): void {

    }

    ngAfterContentInit(): void {
        // get all active tabs
        let activeTabs = this.tabs.filter((tab) => tab.isActive);
        if (activeTabs.length === 0) {
            this.selectTab(this.tabs.first);
        }
    }

    selectTab(tab: TabComponent) {
        // deactive all active tabs
        this.tabs.toArray().forEach((tab) => {
            tab.isActive = false;
        });

        // active current tab
        tab.isActive = true;
    }

}