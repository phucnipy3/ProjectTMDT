import { Injectable } from '@angular/core';
import { Config } from '../app/config';
import { PathController } from '../app/common/consts/path-controllers.const';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/account/user';
import { SessionHelper } from '../app/common/helper/SessionHelper';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { SignUpViewModel } from '../models/account/sign-up';

@Injectable()
export class AuthenticateService {

    private apiUrl = Config.getPath(PathController.Account);

    constructor(
        private http: HttpClient,) { }

    public login(username: string, password: string): Observable<User> {
        return this.http
            .post(this.apiUrl + '/Login', { username, password })
            .pipe(
                map((res: User) => {
                    SessionHelper.saveUserToStorage(res);
                    return res;
                })
            );
    }

    public logout(): Observable<boolean> {
        return this.http
            .get(this.apiUrl + '/logout')
            .pipe(
                map((res: boolean) => {
                    SessionHelper.removeUserStorage();
                    return res;
                })
            );
    }

    public authenticate(role: number = 3): Observable<User> {
        return this.http
            .get(this.apiUrl + '/authentication?role=' + role)
            .pipe(
                map((res: User) => {
                    SessionHelper.saveUserToStorage(res);
                    return res;
                })
            );
    }

    public register(registerViewModel: SignUpViewModel): Observable<boolean> {
        return this.http
            .post(this.apiUrl + '/Register', registerViewModel)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    public activateAccount(username: string, code: string): Observable<boolean> {
        return this.http
            .post(this.apiUrl + '/ActivateAccount', { username, code })
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }
}
