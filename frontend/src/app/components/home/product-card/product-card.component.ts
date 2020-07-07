import { Component, OnInit, Input } from '@angular/core';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { CartItemViewModel } from '../../../../models/cart/cart-item';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { CartService } from '../../../../services/cart.service';

@Component({
    selector: 'product-card',
    templateUrl: './product-card.component.html',
})
export class ProductCardComponent implements OnInit {

    @Input() product: ProductCardViewModel;
    @Input() row = false;
    constructor(
        private cartService: CartService
    ) { }

    ngOnInit(): void { }

    addToCart() {
        this.cartService.addProductToCart(this.product);
    }
}
