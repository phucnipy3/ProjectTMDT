import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from '../../../../services/message.service';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';
import { PasswordCheckService, PasswordCheckStrength } from '../../../../services/check-password';

@Component({
    selector: 'get-password',
    templateUrl: './get-password.component.html',
})
export class GetPasswordComponent implements OnInit {

    email: string;
    code: string;
    password: string;
    confirmPassword: string;

    passwordEmpty = false;
    passwordInvalid = false;
    confirmPasswordEmpty = false;
    confirmPasswordInvalid = false;
    codeEmpty = false;


    constructor(
        private activatedRoute: ActivatedRoute,
        private messageService: MessageService,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService,
        private passwordCheckService: PasswordCheckService,
        private router: Router) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe(params => {
            this.email = params.get('email');
            this.authenticateService.forgetPassword(this.email).subscribe((res) => {
                if (res) {
                    this.toastr.success('Đã gửi mã tới email, kiểm tra email để lấy mã xác nhận');
                }
                else {
                    this.toastr.warning('Gửi mã thất bại');
                    this.router.navigate(['/']);
                }
            }, () => {
                this.toastr.warning('Đã xảy ra lỗi');
                this.router.navigate(['/']);
            });
        });
    }

    getPassword() {
        if (this.inputValid()) {
            this.authenticateService.getNewPassword(this.password, this.code, this.email).subscribe((res) => {
                if (res) {
                    this.toastr.success('Đổi mật khẩu thành công');
                    this.router.navigate(['/']);
                }
                else {
                    this.toastr.warning('Đổi mật khẩu thất bại');
                }

            }, () => {
                this.toastr.warning('Đã xảy ra lỗi');
            });
        }
    }
    resetCondition() {
        this.codeEmpty = false;
        this.passwordEmpty = false;
        this.passwordInvalid = false;
        this.confirmPasswordEmpty = false;
        this.confirmPasswordInvalid = false;
    }

    inputValid() {
        this.resetCondition();
        let valid = true;

        if (!this.code) {
            valid = false;
            this.codeEmpty = true;
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
        }

        return valid;

    }
    strongPassword(password: string) {
        return this.passwordCheckService.checkPasswordStrength(password) === PasswordCheckStrength.Strong;
    }
}
