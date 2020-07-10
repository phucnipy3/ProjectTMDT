import { Component, OnInit } from '@angular/core';
import { TransportViewModel } from '../../../../models/order/transport';
import { ShipmentDetailViewModel } from '../../../../models/order/shipment-detail';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { CartItemViewModel } from '../../../../models/cart/cart-item';
import { CartService } from '../../../../services/cart.service';
import { ShippingMethod } from '../../../../models/order/shipping-method';
import { OrderService } from '../../../../services/order.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';

@Component({
    selector: 'checkout',
    templateUrl: './checkout.component.html',
})
export class CheckoutComponent implements OnInit {

    shippingMethods: ShippingMethod[] = [];
    selectedShippingMethod: ShippingMethod;
    paymentMethods: string[] = [];
    selectedPaymentMethod: string;
    shipping: ShipmentDetailViewModel;
    cartItems: CartItemViewModel[] = [];
    total: number;
    totalCount: number;
    shipfee: number;
    constructor(
        private cartService: CartService,
        private orderService: OrderService,
        private toastr: ToastrService,
        private router: Router,
    ) { }

    ngOnInit(): void {
        this.shipping = SessionHelper.getShippingFromStorage();
        this.cartItems = SessionHelper.getCartFromStorage();
        this.total = this.cartService.getTotal();
        this.totalCount = this.cartService.getItemCount();
        this.getShippingMethods();
        this.getPaymentMethods();
    }

    shipChange(shippingMethod: ShippingMethod) {
        this.selectedShippingMethod = shippingMethod;
    }

    getShippingMethods() {
        this.orderService.getShippingMethods().subscribe((res: ShippingMethod[]) => {
            this.shippingMethods = res;
        });
    }

    getPaymentMethods() {
        this.orderService.getPaymentMethods().subscribe((res: string[]) => {
            this.paymentMethods = res;
            this.selectedPaymentMethod = res[0];
        });
    }

    createOrder() {
        this.orderService.createOrder(
            SessionHelper.getCartFromStorage(),
            SessionHelper.getShippingFromStorage(),
            this.selectedShippingMethod,
            this.selectedPaymentMethod)
            .subscribe((res) => {
                if (res) {
                    this.toastr.success('Đặt hàng thành công');
                } else {
                    this.toastr.warning('Đặt hàng thất bại');
                }
                SessionHelper.removeCartStorage();
                this.router.navigate(['/']);
            });
    }
}
