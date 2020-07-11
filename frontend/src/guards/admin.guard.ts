import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthenticateService } from '../services/authenticate.service';
import { SessionHelper } from '../app/common/helper/SessionHelper';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private router: Router) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean | import("@angular/router").UrlTree | import("rxjs").Observable<boolean | import("@angular/router").UrlTree> | Promise<boolean | import("@angular/router").UrlTree> {
        let user = SessionHelper.getUserFromStorage();
        if (user) {
            return true;
        }
        else {
            this.router.navigate(['/admin/dang-nhap']);
            return false;
        }
    }

}