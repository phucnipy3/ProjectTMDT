import { Component, OnInit, Input } from '@angular/core';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { CartItemViewModel } from '../../../../models/cart/cart-item';
import { SessionHelper } from '../../../common/helper/SessionHelper';

@Component({
    selector: 'product-card',
    templateUrl: './product-card.component.html',
})
export class ProductCardComponent implements OnInit {

    @Input() product: ProductCardViewModel;
    @Input() row = false;
    constructor() { }

    ngOnInit(): void { }

    addToCart() {
        const cartItem = new CartItemViewModel();
        cartItem.id = this.product.id;
        cartItem.image = this.product.image;
        cartItem.name = this.product.name;
        cartItem.price = this.product.promotionPrice ? this.product.promotionPrice : this.product.price;
        cartItem.count = 1;
        const cartItems = SessionHelper.getCartFromStorage();
        cartItems.push(cartItem);
        SessionHelper.saveCartToStorage(cartItems);
    }
}
