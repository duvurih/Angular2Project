// importing angular core
import { Directive, Component, OnInit, Input, Pipe} from "@angular/core";
import { BrowserModule, DomSanitizer } from "@angular/platform-browser";

@Directive({
    selector: '[category-image]',
    host: {
        '[src]': 'sanitizer.bypassSecurityTrustUrl(imageData)'
    }
})
export class ProfileImageDirective implements OnInit {
    imageData: any;
    @Input('category-image') categoryPicture: any;

    constructor(private sanitizer: DomSanitizer) { }

    ngOnInit() {
        this.imageData = 'data:image/png;base64,' + this.categoryPicture;
    }
}

@Pipe({ name: "safeHtml" })
export class SafeHtml {
    constructor(private sanitizer: DomSanitizer) { }

    transform(html:any) {
        return this.sanitizer.bypassSecurityTrustResourceUrl(html);
    }
}

@Component({
    selector: "category-item",
    templateUrl: `app/features/category/categoryitem.html`
})
export class CategoryItemComponent {

    // initializing variables
    @Input() categoryItem: any = [];

    constructor(private sanitizer: DomSanitizer) {

    }

    safeImage(imageData: any):any {
        return this.sanitizer.bypassSecurityTrustResourceUrl(imageData);
    }

    converToBase64(imageData: any):any {
        var base64String = btoa(String.fromCharCode.apply(null, new Uint8Array(imageData)));
        return base64String;
    }

}