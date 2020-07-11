import { Config } from '../app/config';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { PathController } from '../app/common/consts/path-controllers.const';
import { ProductSildeViewModel } from '../models/product/product-slide';

@Injectable()
export class HomeService {
    apiUrl = Config.getPath(PathController.Home);

    constructor(private http: HttpClient) { }

    public getVersion(): Observable<string> {
        return this.http.get(this.apiUrl + '/GetVersion', { responseType: 'text' }).pipe(map((res: string) => res));
    }

    public getHotProducts(): Observable<ProductSildeViewModel[]> {
        return this.http
            .get(this.apiUrl + '/GetSlideProductHot')
            .pipe(
                map((res: ProductSildeViewModel[]) => {
                    return res;
                })
            );
    }
    public getBestProducts(): Observable<ProductSildeViewModel[]> {
        return this.http
            .get(this.apiUrl + '/GetSlideProductNew')
            .pipe(
                map((res: ProductSildeViewModel[]) => {
                    return res;
                })
            );
    }
}