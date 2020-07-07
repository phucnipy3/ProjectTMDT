import { Injectable } from '@angular/core';
import { ProductSildeViewModel } from '../models/product/product-slide';
import { SessionHelper } from '../app/common/helper/SessionHelper';

@Injectable()
export class ViewedProductService {
    public addProduct(product: ProductSildeViewModel) {
        let products = SessionHelper.getViewedProductFromStorage();
        let p = products.find((x) => x.id === product.id);
        if (!p) {
            products.push(product);
            SessionHelper.saveViewedProductToStorage(products);
        }
    }
}