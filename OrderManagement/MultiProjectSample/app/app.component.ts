import { Component, OnInit, ViewContainerRef } from '@angular/core';

// Add the RxJS Observable operators we need in this app.
import './rxjs-operators';

@Component({
    selector: 'my-app',
    template: `
        <dashboard></dashboard>
        `,
})
export class AppComponent {
    constructor(private viewContainerRef: ViewContainerRef) {
        this.viewContainerRef = viewContainerRef;
    }
    name = 'Angular v2.4 Application';
}