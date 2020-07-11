import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent, SimpleModalService } from 'ngx-simple-modal';
import { SignUpPopupComponent } from '../sign-up/sign-up-popup.component';
import { ForgetPasswordPopupComponent } from '../forget-password/forget-password-popup.component';
import { Router } from '@angular/router';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';
import { User } from '../../../../models/account/user';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'login-popup',
    templateUrl: './login-popup-component.html',
})
export class LoginPopupComponent extends SimpleModalComponent<null, User> {

    username: string;
    password: string;

    constructor(
        private simpleModalService: SimpleModalService,
        private router: Router,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService,
        private messageService: MessageService,
    ) {
        super();
    }

    login() {
        this.authenticateService.login(this.username, this.password).subscribe((res) => {
            if (res) {
                this.toastr.success('Đăng nhập thành công');
                this.result = res;
                this.messageService.sendLogin(res);
                this.close();
            }
            else {
                this.toastr.warning('Đăng nhập thất bại');
            }
        }, () => {
            this.toastr.warning('Đăng nhập thất bại');
        });
    }

    signUp() {
        this.simpleModalService.addModal(SignUpPopupComponent).subscribe((res) => {
            if (res) {
                this.toastr.success('Đăng kí thành công, vui lòng kiểm tra email để kích hoạt tài khoản');
            } else {
                this.toastr.warning('Đăng kí thất bại');
            }
        });
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
