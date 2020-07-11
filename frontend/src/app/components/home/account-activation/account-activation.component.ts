import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, ParamMap, Router } from '@angular/router';
import { AuthenticateService } from '../../../../services/authenticate.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'account-activation',
    templateUrl: './account-activation.component.html',
})
export class AccountActivationComponent implements OnInit {

    username = '';
    code = '';

    constructor(
        private activatedRoute: ActivatedRoute,
        private authenticateService: AuthenticateService,
        private toastr: ToastrService,
        private router: Router,
    ) { }

    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe((res: ParamMap) => {
            if (res) {
                this.username = res.get('username');
                this.code = res.get('code');
                if (this.username === null) {
                    this.username = '';
                }
                if (this.code === null) {
                    this.code = '';
                }
                console.log(this.username);
                console.log(this.code);
                this.authenticateService.activateAccount(this.username, this.code).subscribe((res) => {
                    if (res) {
                        this.toastr.success('Kích hoạt tài khoản thành công');
                    }
                    else {
                        this.toastr.warning('Kích hoạt tài khoản thất bại');
                    }
                    this.router.navigate(['/']);
                });
            }
        });
    }
}
