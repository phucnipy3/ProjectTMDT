import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';
import { User } from '../models/account/user';

@Injectable()
export class MessageService {
    private activeSubject = new Subject<string>();
    private cartSubject = new Subject<number>();
    private loginSubject = new Subject<User>();

    sendLogin(user: User) {
        this.loginSubject.next(user);
    }
    onLogin(): Observable<User> {
        return this.loginSubject.asObservable();
    }
    sendActivePage(message: string) {
        this.activeSubject.next(message);
    }

    clearActivePage() {
        this.activeSubject.next();
    }

    onActivePage(): Observable<any> {
        return this.activeSubject.asObservable();
    }

    sendItemCount(count: number) {
        this.cartSubject.next(count);
    }
    onItemCount(): Observable<number> {
        return this.cartSubject.asObservable();
    }
}