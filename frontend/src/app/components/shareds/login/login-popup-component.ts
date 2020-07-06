import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';

@Component({
    selector: 'login-popup',
    templateUrl: './login-popup-component.html',
})
export class LoginPopupComponent extends SimpleModalComponent<null, null> {
    constructor() {
        super();
    }

}
