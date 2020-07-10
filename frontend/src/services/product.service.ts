import { Config } from '../app/config';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PathController } from '../app/common/consts/path-controllers.const';
import { Observable } from 'rxjs';
import { ProductCardViewModel } from '../models/product/product-card';
import { map } from 'rxjs/operators';
import { PagedList } from '../models/paged-list/paged-list';

@Injectable()
export class ProductService {
    apiUrl = Config.getPath(PathController.Product);

    constructor(private http: HttpClient) { }

    public getProducts(category: number, searchString: string, pageNumber = 1, pageSize = 10): Observable<PagedList<ProductCardViewModel>> {
        let params = new HttpParams();
        params = params
            .set('category', category.toString())
            .set('searchString', searchString)
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString());
        return this.http
            .get(this.apiUrl + '/GetProduct', { params })
            .pipe(
                map((res: PagedList<ProductCardViewModel>) => {
                    return res;
                })
            );
    }

}