import { Component, OnInit } from '@angular/core';
import { SimpleModalService } from 'ngx-simple-modal';
import { MessageService } from '../../../../services/message.service';
import { CartService } from '../../../../services/cart.service';
import { LoginPopupComponent } from '../login/login-popup-component';
import { SignUpPopupComponent } from '../sign-up/sign-up-popup.component';
import { User } from '../../../../models/account/user';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'top-menu',
    templateUrl: './top-menu.component.html',
})
export class TopMenuComponent implements OnInit {

    activePage = '';
    itemCount = 0;
    user: User;
    constructor(
        private simpleModalService: SimpleModalService,
        private messageService: MessageService,
        private cartService: CartService,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService) {
        this.messageService.onActivePage().subscribe(activePage => {
            if (activePage) {
                this.activePage = activePage;
            }
            else {
                this.activePage = '';
            }
            console.log(this.activePage);
        });
        this.itemCount = this.cartService.getItemCount();
        this.messageService.onItemCount().subscribe(count => {
            this.itemCount = count;
        });
    }

    ngOnInit(): void {
        this.user = SessionHelper.getUserFromStorage();
    }

    logout() {
        this.authenticateService.logout().subscribe((res) => {
            if (res) {
                this.user = undefined;
            }
        });
    }

    showLogin() {
        this.simpleModalService.addModal(LoginPopupComponent).subscribe((res) => {
            this.user = res;
        });
    }
    showSignUp() {
        this.simpleModalService.addModal(SignUpPopupComponent);
    }
}
