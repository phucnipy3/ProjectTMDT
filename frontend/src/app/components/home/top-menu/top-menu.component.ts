import { Component, OnInit } from '@angular/core';
import { SimpleModalService } from 'ngx-simple-modal';
import { LoginPopupComponent } from '../../shareds/login/login-popup-component';
import { SignUpPopupComponent } from '../../shareds/sign-up/sign-up-popup.component';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'top-menu',
    templateUrl: './top-menu.component.html',
})
export class TopMenuComponent implements OnInit {

    authen = false;
    activePage = '';
    constructor(
        private simpleModalService: SimpleModalService,
        private messageService: MessageService) {
        this.messageService.onActivePage().subscribe(activePage => {
            if (activePage) {
                this.activePage = activePage;
            }
            else {
                this.activePage = '';
            }
            console.log(this.activePage);
        });
    }

    ngOnInit(): void {

    }

    showLogin() {
        this.simpleModalService.addModal(LoginPopupComponent);
    }
    showSignUp() {
        this.simpleModalService.addModal(SignUpPopupComponent);
    }
}
