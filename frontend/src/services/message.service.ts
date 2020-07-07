import { Injectable } from '@angular/core';
import { Subject, Observable } from 'rxjs';

@Injectable()
export class MessageService {
    private activeSubject = new Subject<string>();
    private cartSubject = new Subject<number>();
    sendActivePage(message: string) {
        this.activeSubject.next(message);
    }

    clearActivePage() {
        this.activeSubject.next();
    }

    onActivePage(): Observable<any> {
        return this.activeSubject.asObservable();
    }

    sendItemCount(count: number){
        this.cartSubject.next(count);
    }
    onItemCount(): Observable<number>{
        return this.cartSubject.asObservable();
    }
}