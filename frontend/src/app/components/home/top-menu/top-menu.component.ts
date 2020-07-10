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
import { Router } from '@angular/router';

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
        private toastr: ToastrService,
        private router: Router) {
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
        this.messageService.onLogin().subscribe(user => {
            this.user = user;
        });
    }

    ngOnInit(): void {
        this.authenticateService.authenticate().subscribe((res: User) => {
            if (res) {
                this.user = res;
                SessionHelper.saveUserToStorage(res);
            }
        });
    }

    logout() {
        this.authenticateService.logout().subscribe((res) => {
            if (res) {
                this.user = undefined;
                this.router.navigate(['/']);
            }
        }, () => {
            this.toastr.warning('Có lỗi xảy ra');
        });
    }

    showLogin() {
        this.simpleModalService.addModal(LoginPopupComponent).subscribe((res) => {
            if (res) { this.user = res; }
        });
    }
    showSignUp() {
        this.simpleModalService.addModal(SignUpPopupComponent).subscribe((res) => {
            if (res) {
                this.toastr.success('Đăng kí thành công, vui lòng kiểm tra email để kích hoạt tài khoản');
            }
            else {
                this.toastr.warning('Đăng kí thất bại');
            }
        });
    }
}
