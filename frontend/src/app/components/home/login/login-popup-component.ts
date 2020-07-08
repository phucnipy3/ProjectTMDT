import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent, SimpleModalService } from 'ngx-simple-modal';
import { SignUpPopupComponent } from '../sign-up/sign-up-popup.component';
import { ForgetPasswordPopupComponent } from '../forget-password/forget-password-popup.component';
import { Router } from '@angular/router';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'login-popup',
    templateUrl: './login-popup-component.html',
})
export class LoginPopupComponent extends SimpleModalComponent<null, null> {

    username: string;
    password: string;

    constructor(
        private simpleModalService: SimpleModalService,
        private router: Router,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService
    ) {
        super();
    }

    login() {
        this.authenticateService.login(this.username, this.password).subscribe((res) => {
            if (res) {
                this.toastr.success('Đăng nhập thành công');
            }
        });
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
