import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const ct = req.detectContentTypeHeader();
        req = req.clone({
            withCredentials: true
        });

        if (ct !== null && ct.startsWith('text/plain')) {
            req = req.clone({
                setHeaders: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(req.body),
            });
        }

        return next.handle(req);
    }
}