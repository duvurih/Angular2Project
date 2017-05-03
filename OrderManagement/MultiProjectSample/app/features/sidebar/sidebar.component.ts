import { Component } from '@angular/core';

import { DataContextService } from '../../services/datacontext.service';

@Component({
    selector: 'sidebar',
    templateUrl: `app/features/sidebar/sidebar.html`,
})
export class SidebarComponent {
    constructor(
        private dataContextService: DataContextService
    ) {

    }
}