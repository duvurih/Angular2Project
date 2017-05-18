import { Component, ViewChild } from "@angular/core";

import { Modal } from "ng2-modal";

@Component({
    selector: "modal-common",
    templateUrl: "app/common/modal-common.html"
})
export class ModalCommonComponent {
    @ViewChild("myModal") _modal: Modal;

    close():void {
        this._modal.close();
    }

    open():void {
        this._modal.open();
    }
}