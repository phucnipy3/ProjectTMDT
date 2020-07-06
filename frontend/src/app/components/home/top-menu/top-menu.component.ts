import { Component, OnInit } from '@angular/core';
import { SimpleModalService } from 'ngx-simple-modal';
import { LoginPopupComponent } from '../../shareds/login/login-popup-component';
import { SignUpPopupComponent } from '../../shareds/sign-up/sign-up-popup.component';

@Component({
    selector: 'top-menu',
    templateUrl: './top-menu.component.html',
})
export class TopMenuComponent implements OnInit {

    authen = false;

    constructor(private simpleModalService: SimpleModalService) { }

    ngOnInit(): void { }

    showLogin() {
        this.simpleModalService.addModal(LoginPopupComponent);
    }
    showSignUp() {
        this.simpleModalService.addModal(SignUpPopupComponent);
    }
}
