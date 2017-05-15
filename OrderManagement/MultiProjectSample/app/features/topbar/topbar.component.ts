import { Component } from "@angular/core";

import { DataContextService } from "../../services/datacontext.service";

@Component({
    selector: "topbar",
    templateUrl: `app/features/topbar/topbar.html`,
})
export class TopbarComponent {
    result: any;

    constructor(
        private dataContextService: DataContextService
    ) {

    }

    // method implementation
    onLogOut():any {
        this.dataContextService.httpPost("Home/Logout", null)
            .subscribe((resultData: any) => {
                this.result = resultData;
            });
    }
}