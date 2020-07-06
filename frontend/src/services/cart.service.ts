import { Injectable } from '@angular/core';
import { SessionHelper } from '../app/common/helper/SessionHelper';
import { ProductCardViewModel } from '../models/product/product-card';
import { CartItemViewModel } from '../models/cart/cart-item';

@Injectable()
export class CartService {
    public addProductToCart(product: ProductCardViewModel): boolean {
        const cartItems = SessionHelper.getCartFromStorage();
        const item = cartItems.find((x) => x.id === product.id);
        if (item) {
            item.count += 1;
            SessionHelper.saveCartToStorage(cartItems);
            return true;
        }
        const cartItem = new CartItemViewModel();
        cartItem.id = product.id;
        cartItem.image = product.image;
        cartItem.name = product.name;
        cartItem.price = product.promotionPrice ? product.promotionPrice : product.price;
        cartItem.count = 1;
        cartItems.push(cartItem);
        SessionHelper.saveCartToStorage(cartItems);
    }

    public getItemCount(): number {
        const cartItems = SessionHelper.getCartFromStorage();
        let count = 0;
        cartItems.forEach((x) => {
            count += x.count;
        });
        return count;
    }

    public getTotal(): number {
        const cartItems = SessionHelper.getCartFromStorage();
        let total = 0;
        cartItems.forEach((x) => {
            total += x.price * x.count;
        });
        return total;
    }

    public increaseCount(productId: number): boolean {
        const cartItems = SessionHelper.getCartFromStorage();
        const item = cartItems.find((x) => x.id === productId);
        if (item) {
            item.count += 1;
            SessionHelper.saveCartToStorage(cartItems);
            return true;
        }
        return false;
    }

    public decreaseCount(productId: number): boolean {
        let cartItems = SessionHelper.getCartFromStorage();
        const item = cartItems.find((x) => x.id === productId);
        if (item) {
            item.count -= 1;
            if (item.count === 0) {
                cartItems = cartItems.filter((x) => x !== item);
            }
            SessionHelper.saveCartToStorage(cartItems);
            return true;
        }
        return false;
    }

    public removeProduct(productId: number){
        let cartItems = SessionHelper.getCartFromStorage();
        cartItems = cartItems.filter((x) => x.id !== productId);
        SessionHelper.saveCartToStorage(cartItems);
        return true;
    }
}
