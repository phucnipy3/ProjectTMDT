import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';
import { SignUpViewModel } from '../../../../models/account/sign-up';
import { PasswordCheckService, PasswordCheckStrength } from '../../../../services/check-password';


@Component({
    selector: 'sign-up-popup',
    templateUrl: './sign-up-popup.component.html',
})
export class SignUpPopupComponent extends SimpleModalComponent<null, null> {

    model: SignUpViewModel = new SignUpViewModel();

    emailEmpty = false;
    emailInvalid = false;
    passwordEmpty = false;
    passwordInvalid = false;
    confirmPasswordEmpty = false;
    confirmPasswordInvalid = false;
    nameEmpty = false;
    addressEmpty = false;
    phoneNumberEmpty = false;
    phoneNumberInvalid = false;


    constructor(private passwordCheckService: PasswordCheckService) {
        super();
    }

    signUp() {
        this.inputValid();
    }

    resetCondition() {
        this.emailEmpty = false;
        this.emailInvalid = false;
        this.passwordEmpty = false;
        this.passwordInvalid = false;
        this.confirmPasswordEmpty = false;
        this.confirmPasswordInvalid = false;
        this.nameEmpty = false;
        this.addressEmpty = false;
        this.phoneNumberEmpty = false;
        this.phoneNumberInvalid = false;
    }

    inputValid() {
        this.resetCondition();
        let valid = true;
        if (!this.model.email) {
            valid = false;
            this.emailEmpty = true;
        }
        else {
            if (!this.emailValid(this.model.email)) {
                valid = false;
                this.emailInvalid = true;
            }
        }
        if (!this.model.password) {
            valid = false;
            this.passwordEmpty = true;
        }
        else {
            if (!this.strongPassword(this.model.password)) {
                valid = false;
                this.passwordInvalid = true;
            }
        }
        if (!this.model.confirmPassword) {
            valid = false;
            this.confirmPasswordEmpty = true;
        } else {
            if (this.model.password !== this.model.confirmPassword) {
                valid = false;
                this.confirmPasswordInvalid = true;
            }
        }

        if (!this.model.fullName) {
            valid = false;
            this.nameEmpty = true;
        }
        if (!this.model.phoneNumber) {
            valid = false;
            this.phoneNumberEmpty = true;
        }
        else {
            if (!this.phoneNumberValid(this.model.phoneNumber)) {
                valid = false;
                this.phoneNumberInvalid = true;
            }
        }

        if (!this.model.address) {
            valid = false;
            this.addressEmpty = true;
        }

        if (!valid) {
            this.model.password = '';
            this.model.confirmPassword = '';
        }

        return valid;

    }

    emailValid(email: string) {
        const regexp = new RegExp('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$');
        return regexp.test(email);
    }

    strongPassword(password: string) {
        return this.passwordCheckService.checkPasswordStrength(password) === PasswordCheckStrength.Strong;
    }

    phoneNumberValid(phoneNumber: string){
        const numberr = new RegExp('^0+[0-9]{9}$');
        return numberr.test(phoneNumber);
    }
}
