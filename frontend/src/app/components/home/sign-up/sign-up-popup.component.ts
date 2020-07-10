import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { SignUpViewModel } from '../../../../models/account/sign-up';

@Component({
    selector: 'sign-up-popup',
    templateUrl: './sign-up-popup.component.html',
})
export class SignUpPopupComponent extends SimpleModalComponent<null, null> {

    model: SignUpViewModel;

    constructor() {
        super();
    }


}
