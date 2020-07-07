import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent, SimpleModalService } from 'ngx-simple-modal';
import { SignUpPopupComponent } from '../sign-up/sign-up-popup.component';
import { ForgetPasswordPopupComponent } from '../forget-password/forget-password-popup.component';
import { Router } from '@angular/router';

@Component({
    selector: 'login-popup',
    templateUrl: './login-popup-component.html',
})
export class LoginPopupComponent extends SimpleModalComponent<null, null> {

    constructor(
        private simpleModalService: SimpleModalService,
        private router: Router,
    ) {
        super();
    }

    signUp() {
        this.simpleModalService.addModal(SignUpPopupComponent);
    }

    forgetPassword() {
        this.simpleModalService.addModal(ForgetPasswordPopupComponent)
            .subscribe((email) => {
                if (email) {
                    this.router.navigate(['/quen-mat-khau', email]);
                    this.close();
                }
            });
    }

}
