import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { AuthenticateService } from '../services/authenticate.service';

@Injectable()
export class AdminGuard implements CanActivate {
    constructor(private authenticateService: AuthenticateService, private router: Router) { }
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        if (!this.authenticateService.authenticate(2)) {
            this.router.navigate(['/admin/dang-nhap']);
            return false;
        }
        else {
            return true;
        }
    }
}