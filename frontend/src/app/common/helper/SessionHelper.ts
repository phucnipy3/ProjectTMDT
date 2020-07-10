import { CartItemViewModel } from '../../../models/cart/cart-item';
import { ShipmentDetailViewModel } from '../../../models/order/shipment-detail';
import { ProductSildeViewModel } from '../../../models/product/product-slide';
import { User } from '../../../models/account/user';
export class SessionHelper {
    private static readonly CART_LOCAL: string = 'cart';
    private static readonly SHIPPING_LOCAL: string = 'shipping';
    private static readonly VIEWED_LOCAL: string = 'viewed';
    private static readonly USER_LOCAL: string = 'user';

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

    public static removeCartStorage() {
        sessionStorage.removeItem(this.CART_LOCAL);
    }

    public static saveShippingToStorage(shipping: ShipmentDetailViewModel) {
        sessionStorage.setItem(this.SHIPPING_LOCAL, JSON.stringify(shipping));
    }

    public static getShippingFromStorage(): ShipmentDetailViewModel {
        const currentShipping = sessionStorage.getItem(this.CART_LOCAL);
        if (!currentShipping || currentShipping === '') {
            return undefined;
        }
        const shipping: ShipmentDetailViewModel = JSON.parse(currentShipping);
        return shipping;
    }

    public static removeShippingStorage() {
        sessionStorage.removeItem(this.SHIPPING_LOCAL);
    }

    public static saveViewedProductToStorage(products: ProductSildeViewModel[]) {
        sessionStorage.setItem(this.VIEWED_LOCAL, JSON.stringify(products));
    }

    public static getViewedProductFromStorage(): ProductSildeViewModel[] {
        const currentProducts = sessionStorage.getItem(this.VIEWED_LOCAL);
        if (!currentProducts || currentProducts === '') {
            return [];
        }
        const products: ProductSildeViewModel[] = JSON.parse(currentProducts);
        return products;
    }

    public static removeViewedProductStorage() {
        sessionStorage.removeItem(this.VIEWED_LOCAL);
    }

    public static saveUserToStorage(user: User) {
        sessionStorage.setItem(this.USER_LOCAL, JSON.stringify(user));
    }

    public static getUserFromStorage(): User {
        const currentUser = sessionStorage.getItem(this.USER_LOCAL);
        if (!currentUser || currentUser === '') {
            return undefined;
        }
        const user: User = JSON.parse(currentUser);
        return user;
    }

    public static removeUserStorage() {
        sessionStorage.removeItem(this.USER_LOCAL);
    }
}
