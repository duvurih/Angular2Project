import { Component, OnInit, ViewContainerRef } from '@angular/core';

// Add the RxJS Observable operators we need in this app.
import './rxjs-operators';

@Component({
    selector: 'my-app',
    template: `
        <h1>Hello {{name}}</h1>
        <router-outlet></router-outlet>
        `,
})
export class AppComponent {
    constructor(private viewContainerRef: ViewContainerRef) {
        this.viewContainerRef = viewContainerRef;
    }
    name = 'Workflow Application';
}