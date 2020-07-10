import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { PasswordCheckService, PasswordCheckStrength } from '../../../../services/check-password';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'change-password-popup',
    templateUrl: './change-password-popup.component.html',
})
export class ChangePasswordPopupComponent extends SimpleModalComponent<null, null> {

    passwordEmpty = false;
    passwordInvalid = false;
    confirmPasswordEmpty = false;
    confirmPasswordInvalid = false;
    oldPasswordEmpty = false;

    password: string;
    oldPassword: string;
    confirmPassword: string;

    constructor(
        private passwordCheckService: PasswordCheckService,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService
    ) {
        super();
    }
    resetCondition() {
        this.oldPasswordEmpty = false;
        this.passwordEmpty = false;
        this.passwordInvalid = false;
        this.confirmPasswordEmpty = false;
        this.confirmPasswordInvalid = false;
    }

    inputValid() {
        this.resetCondition();
        let valid = true;

        if (!this.oldPassword) {
            valid = false;
            this.oldPasswordEmpty = true;
        }
        if (!this.password) {
            valid = false;
            this.passwordEmpty = true;
        }
        else {
            if (!this.strongPassword(this.password)) {
                valid = false;
                this.passwordInvalid = true;
            }
        }
        if (!this.confirmPassword) {
            valid = false;
            this.confirmPasswordEmpty = true;
        } else {
            if (this.password !== this.confirmPassword) {
                valid = false;
                this.confirmPasswordInvalid = true;
            }
        }



        if (!valid) {
            this.password = '';
            this.confirmPassword = '';
            this.oldPassword = '';
        }

        return valid;

    }
    strongPassword(password: string) {
        return this.passwordCheckService.checkPasswordStrength(password) === PasswordCheckStrength.Strong;
    }

    changePassword() {
        if (this.inputValid()) {
            this.authenticateService.changePassword(this.oldPassword, this.password).subscribe((res) => {
                if (res) {
                    this.toastr.success('Đổi mật khẩu thành công');
                    this.close();
                }
                else {
                    this.toastr.warning('Đổi mật khẩu thất bại');
                }
            }, () => {
                this.toastr.warning('Đã xảy ra lỗi');
            });
        }
    }
}
