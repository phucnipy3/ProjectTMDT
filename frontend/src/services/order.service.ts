import { Injectable } from '@angular/core';
import { Config } from '../app/config';
import { PathController } from '../app/common/consts/path-controllers.const';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ShippingMethod } from '../models/order/shipping-method';
import { map } from 'rxjs/operators';
import { CartItemViewModel } from '../models/cart/cart-item';
import { ShipmentDetailViewModel } from '../models/order/shipment-detail';

@Injectable()
export class OrderService {
    apiUrl = Config.getPath(PathController.Order);

    constructor(private http: HttpClient) { }

    public getShippingMethods(): Observable<ShippingMethod[]> {
        return this.http
            .get(this.apiUrl + '/GetDeliveryMethod')
            .pipe(
                map((res: ShippingMethod[]) => {
                    return res;
                })
            );
    }

    public getPaymentMethods(): Observable<string[]> {
        return this.http
            .get(this.apiUrl + '/GetPaymentMethod')
            .pipe(
                map((res: string[]) => {
                    return res;
                })
            );
    }

    public createOrder(
        cartItems: CartItemViewModel[],
        shipmentDetail: ShipmentDetailViewModel,
        deliveryMethod: ShippingMethod,
        paymentMethod: string): Observable<boolean> {
        return this.http
            .post(this.apiUrl + '/CreateOrderCart', { cartItems, shipmentDetail, deliveryMethod, paymentMethod })
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    getShipmentDetails(): Observable<ShipmentDetailViewModel[]>{
        return this.http
        .get(this.apiUrl + '/GetShipmentDetails')
        .pipe(
            map((res: ShipmentDetailViewModel[]) => {
                return res;
            })
        );
    }
    getOrders(){

    }
}