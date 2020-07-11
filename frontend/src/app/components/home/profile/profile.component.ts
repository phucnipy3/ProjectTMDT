import { Component, OnInit } from '@angular/core';
import { ProfileViewModel } from '../../../../models/account/profile';
import { SimpleModalService } from 'ngx-simple-modal';
import { MessageService } from '../../../../services/message.service';
import { ChangePasswordPopupComponent } from '../change-password/change-password-popup.component';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'profile',
    templateUrl: './profile.component.html',
})
export class ProfileComponent implements OnInit {

    profile: ProfileViewModel;

    constructor(
        private simpleModalService: SimpleModalService,
        private messageService: MessageService,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.authenticateService.getProfile().subscribe((res: ProfileViewModel) => {
            if (res) {
                this.profile = res;
            }
        });
    }

    setMale() {
        this.profile.isMale = true;
    }
    setFemale() {
        this.profile.isMale = false;
    }
    changePassword() {
        this.simpleModalService.addModal(ChangePasswordPopupComponent);
    }

    update() {
        this.authenticateService.updateProfile(this.profile).subscribe((res) => {
            if (res) {
                this.toastr.success('Cập nhật thành công');
            }
            else {
                this.toastr.warning('Cập nhật thất bại');
            }
        }, () => {
            this.toastr.warning('Đã xảy ra lỗi');
        });
    }
}
