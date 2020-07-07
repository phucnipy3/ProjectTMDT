import { Component, OnInit } from '@angular/core';
import { CartItemViewModel } from '../../../../models/cart/cart-item';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { CartService } from '../../../../services/cart.service';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'cart',
    templateUrl: './cart.component.html',
})
export class CartComponent implements OnInit {

    cartItems: CartItemViewModel[] = [];
    total: number;
    constructor(
        private cartService: CartService,
        private messageService: MessageService) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.cartItems = SessionHelper.getCartFromStorage();
        this.total = this.cartService.getTotal();
    }

    remove(item) {
        this.cartService.removeProduct(item.id);
        this.cartItems = SessionHelper.getCartFromStorage();
        this.total = this.cartService.getTotal();

    }

    increase(item) {
        this.cartService.increaseCount(item.id);
        this.cartItems = SessionHelper.getCartFromStorage();
        this.total = this.cartService.getTotal();

    }

    decrease(item) {
        this.cartService.decreaseCount(item.id);
        this.total = this.cartService.getTotal();
        this.cartItems = SessionHelper.getCartFromStorage();
    }
}
