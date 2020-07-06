import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';

@Component({
    selector: 'sign-up-popup',
    templateUrl: './sign-up-popup.component.html',
})
export class SignUpPopupComponent extends SimpleModalComponent<null, null> {
    constructor() {
        super();
    }
}
