// importing angular core
import { Pipe, PipeTransform } from "@angular/core";
import { DomSanitizer } from "@angular/platform-browser";

// importing models
import { FilterCriteria } from "../models/filtercriteria.model";

@Pipe({
    name: "namefilter",
    pure: false
})
export class NameFilterPipe implements PipeTransform {
    transform(items: any[], filter: FilterCriteria): any {
        if (!items || !filter) {
            return items;
        }
        // filter items array, items which match and return true will be kept, false will be filtered out
        // return items.filter(item => item.categoryID.indexOf(filter.criteriaValue) !== -1);
        return items.filter(item => item[filter.criteriaColumn]===(filter.criteriaValue));
    }
}

@Pipe({ name: "safeHtml" })
export class SafeHtml {
    constructor(private sanitizer: DomSanitizer) { }

    transform(html: any):any {
        return this.sanitizer.bypassSecurityTrustResourceUrl(html);
    }
}

@Pipe({
    name: "dateFormat"
})
export class DateFormatPipe implements PipeTransform {
    transform(value: any, args: any[]): any {

        if (args && args[0] === "local") {
            return new Date(value).toLocaleString();
        }else if (value) {
            return new Date(value);
        }
        return value;
    }
}