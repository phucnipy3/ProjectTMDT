import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../../../models/product/product';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit {

    product: ProductViewModel;

    constructor() { }

    ngOnInit(): void {
        this.product = new ProductViewModel();
        this.product.name = 'name name an aemd á á';
        this.product.promotionPrice = 14356;
        this.product.price = 25776434;
        this.product.savePersent = '32%';
        this.product.image = '../../../assets/image/banner1.jpg';
        this.product.detail = '<p>details  ấ gs fa dhedf a</p>';
        this.product.brand = 'AOE';
    }
}
