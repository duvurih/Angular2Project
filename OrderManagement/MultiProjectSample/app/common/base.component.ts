import { Component, OnInit, ViewContainerRef, AfterContentInit, AfterViewInit, OnDestroy, OnChanges} from "@angular/core";

export class AppComponent implements OnInit, AfterContentInit, AfterViewInit, OnDestroy, OnChanges {

    constructor(private viewContainerRef: ViewContainerRef,
    ) {
        this.viewContainerRef = viewContainerRef;
    }

    ngOnInit(): void {
    }

    ngAfterContentInit(): void {

    }

    ngAfterViewInit(): void {

    }

    ngOnDestroy(): void {

    }

    ngOnChanges(): void {

    }
}