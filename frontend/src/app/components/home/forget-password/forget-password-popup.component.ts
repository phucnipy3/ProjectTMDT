import { Component, OnInit, Input } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
declare var $: any;
@Component({
    selector: 'forget-password-popup',
    templateUrl: './forget-password-popup.component.html',
})

export class ForgetPasswordPopupComponent extends SimpleModalComponent<null, string> {

    constructor() {
        super();
    }

    confirm() {
        this.result = $('#email').val();
        this.close();
    }
}
