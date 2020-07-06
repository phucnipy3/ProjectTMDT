import { CartItemViewModel } from '../../../models/cart/cart-item';
export class SessionHelper {
    private static readonly CART_LOCAL: string = 'cart';

    public static saveCartToStorage(cartItems: CartItemViewModel[]) {
        sessionStorage.setItem(this.CART_LOCAL, JSON.stringify(cartItems));
    }

    public static getCartFromStorage(): CartItemViewModel[] {
        const currentCart = sessionStorage.getItem(this.CART_LOCAL);
        if (!currentCart || currentCart === '') {
            return [];
        }
        const cartItems: CartItemViewModel[] = JSON.parse(currentCart);
        return cartItems;
    }

    public static removeCartStorage(){
        sessionStorage.removeItem(this.CART_LOCAL);
    }
}
