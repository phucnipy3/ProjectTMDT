import { Config } from '../app/config';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PathController } from '../app/common/consts/path-controllers.const';
import { Observable } from 'rxjs';
import { ProductCardViewModel } from '../models/product/product-card';
import { map } from 'rxjs/operators';
import { PagedList } from '../models/paged-list/paged-list';
import { ProductViewModel } from '../models/product/product';
import { RateViewModel } from '../models/product/rate';
import { CommentViewModel } from '../models/product/comment';
import { CategoryViewModel } from '../models/product/category';

@Injectable()
export class ProductService {
    apiUrl = Config.getPath(PathController.Product);

    constructor(private http: HttpClient) { }

    public getProducts(category: number, searchString: string, pageNumber = 1, pageSize = 12): Observable<PagedList<ProductCardViewModel>> {
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

    public getProductDetails(id: number): Observable<ProductViewModel> {
        return this.http
            .get(this.apiUrl + '/GetProductDetail?productId=' + id)
            .pipe(
                map((res: ProductViewModel) => {
                    return res;
                })
            );
    }

    public getRelatedProducs(id: number): Observable<ProductCardViewModel[]> {
        return this.http
            .get(this.apiUrl + '/GetRelatedProduct?productId=' + id)
            .pipe(
                map((res: ProductCardViewModel[]) => {
                    return res;
                })
            );
    }

    public getRate(id: number): Observable<RateViewModel> {
        return this.http
            .get(this.apiUrl + '/GetRate?productId=' + id)
            .pipe(
                map((res: RateViewModel) => {
                    return res;
                })
            );
    }

    public rate(id: number, point: number): Observable<boolean> {
        return this.http
            .get(this.apiUrl + '/CreateRate?productId=' + id + '&point=' + point)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    public comment(productId: number, content: string): Observable<boolean> {
        return this.http
            .get(this.apiUrl + '/CreateComment?productId=' + productId + '&content=' + content)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    public reply(productId, parentId: number, content: string) {
        return this.http
            .get(this.apiUrl +
                '/Comment?productId=' + productId +
                '&content=' + content +
                '&parentId=' + parentId)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    public getComments(id: number, pageNumber = 1, pageSize = 10): Observable<PagedList<CommentViewModel>> {
        let params = new HttpParams();
        params = params
            .set('productId', id.toString())
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString());
        return this.http
            .get(this.apiUrl + '/GetComments', { params })
            .pipe(
                map((res: PagedList<CommentViewModel>) => {
                    return res;
                })
            );
    }

    getCateries(): Observable<CategoryViewModel[]>{
        return this.http
        .get(this.apiUrl + '/GetCategory')
        .pipe(
            map((res: CategoryViewModel[]) => {
                return res;
            })
        );
    }
}