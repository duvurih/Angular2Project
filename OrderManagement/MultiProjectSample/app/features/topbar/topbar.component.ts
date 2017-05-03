import { Component } from '@angular/core';

import { DataContextService } from '../../services/datacontext.service';

@Component({
    selector: 'topbar',
    templateUrl: `app/features/topbar/topbar.html`,
})
export class TopbarComponent {
    constructor(
        private dataContextService: DataContextService
    ) {

    }
}