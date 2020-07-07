import { Component, OnInit } from '@angular/core';
import { TransportViewModel } from '../../../../models/order/transport';
import { ShipmentDetailViewModel } from '../../../../models/order/shipment-detail';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { CartItemViewModel } from '../../../../models/cart/cart-item';
import { CartService } from '../../../../services/cart.service';

@Component({
    selector: 'checkout',
    templateUrl: './checkout.component.html',
})
export class CheckoutComponent implements OnInit {

    transports: TransportViewModel[] = [];
    shipping: ShipmentDetailViewModel;
    cartItems: CartItemViewModel[] = [];
    total: number;
    totalCount: number;
    shipfee: number;
    constructor(
        private cartService: CartService
    ) { }

    ngOnInit(): void {
        this.shipping = SessionHelper.getShippingFromStorage();
        this.cartItems = SessionHelper.getCartFromStorage();
        this.total = this.cartService.getTotal();
        this.totalCount = this.cartService.getItemCount();
        let x = new TransportViewModel();
        x.name = 'Giao hàng tiêu chuẩn';
        x.fee = 12346;
        let y = new TransportViewModel();
        y.name = 'Giao hàng nhanh';
        y.fee = 21533;
        this.transports.push(x);
        this.transports.push(y);

        this.shipfee = this.transports[0].fee;
    }

    shipChange(fee){
        this.shipfee = fee;
    }
}
