import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class MessageService {
    private activeSubject = new Subject<string>();

    sendActivePage(message: string) {
        this.activeSubject.next(message);
    }

    clearActivePage() {
        this.activeSubject.next();
    }

    onActivePage(): Observable<any> {
        return this.activeSubject.asObservable();
    }
}