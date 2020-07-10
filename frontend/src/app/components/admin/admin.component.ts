import { Component, OnInit } from '@angular/core';
import { AuthenticateService } from '../../../services/authenticate.service';
import { Router } from '@angular/router';
import { SessionHelper } from '../../common/helper/SessionHelper';
import { User } from '../../../models/account/user';

@Component({
    selector: 'admin',
    templateUrl: './admin.component.html',
})
export class AdminComponent implements OnInit {
    constructor(
        private authenticateService: AuthenticateService,
        private router: Router) { }

    ngOnInit(): void {
        this.authenticateService.authenticate(2).subscribe((res: User) => {
            if (res) {
                SessionHelper.saveUserToStorage(res);
            } else {
                SessionHelper.removeUserStorage();
            }
        }, () => {
            SessionHelper.removeUserStorage();
        });
    }
}
