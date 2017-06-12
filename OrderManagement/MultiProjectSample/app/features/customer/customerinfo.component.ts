// importing angular core
import { Component, Input} from "@angular/core";


@Component({
    selector: "customerinfo",
    templateUrl: "app/features/customer/customerinfo.html"
})
export class CustomerInfoComponent {

    // initializing variables
    @Input() customer: any;
    @Input() isSearchResult: boolean;

}