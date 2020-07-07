import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';

@Component({
    selector: 'change-password-popup',
    templateUrl: './change-password-popup.component.html',
})
export class ChangePasswordPopupComponent extends SimpleModalComponent<null, null> {
    constructor() {
        super();
    }

}
