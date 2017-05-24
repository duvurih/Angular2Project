// importing angular core
import { Component, Input} from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";

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
        var base64String:any = btoa(String.fromCharCode.apply(null, new Uint8Array(imageData)));
        return base64String;
    }

}