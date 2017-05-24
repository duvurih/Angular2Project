import { Directive, OnInit, Input } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";

@Directive({
    selector: "[category-image]",
    host: {
        "[src]": "sanitizer.bypassSecurityTrustUrl(imageData)"
    }
})
export class ProfileImageDirective implements OnInit {
    imageData: any;
    @Input("category-image") categoryPicture: any;

    constructor(private sanitizer: DomSanitizer) { }

    ngOnInit():void {
        this.imageData = "data:image/png;base64," + this.categoryPicture;
    }
}