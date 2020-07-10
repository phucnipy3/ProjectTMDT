import { Injectable } from '@angular/core';
import { Config } from '../app/config';
import { PathController } from '../app/common/consts/path-controllers.const';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable, pipe } from 'rxjs';
import { ShippingMethod } from '../models/order/shipping-method';
import { map } from 'rxjs/operators';
import { CartItemViewModel } from '../models/cart/cart-item';
import { ShipmentDetailViewModel } from '../models/order/shipment-detail';
import { OrderStatusViewModel } from '../models/order/order-status';
import { PagedList } from '../models/paged-list/paged-list';
import { OrderViewModel } from '../models/order/order';

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

    getShipmentDetails(): Observable<ShipmentDetailViewModel[]> {
        return this.http
            .get(this.apiUrl + '/GetShipmentDetails')
            .pipe(
                map((res: ShipmentDetailViewModel[]) => {
                    return res;
                })
            );
    }
    getOrders(searchString = '', status = 0, pageNumber = 1, pageSize = 10): Observable<PagedList<OrderViewModel>> {
        let params = new HttpParams();
        params = params.set('searchString', searchString)
            .set('status', status.toString())
            .set('pageNumber', pageNumber.toString())
            .set('pageSize', pageSize.toString());
        return this.http
            .get(this.apiUrl + '/GetOrders', { params })
            .pipe(
                map((res: PagedList<OrderViewModel>) => {
                    return res;
                })
            );
    }

    getOrderStatus(): Observable<OrderStatusViewModel[]> {
        return this.http
            .get(this.apiUrl + '/GetOrderStatus')
            .pipe(
                map((res: OrderStatusViewModel[]) => {
                    return res;
                })
            );
    }

    getOrderDetail(id: number): Observable<OrderViewModel> {
        return this.http
            .get(this.apiUrl + '/GetOrderDetail?orderId=' + id)
            .pipe(
                map((res: OrderViewModel) => {
                    return res;
                })
            );
    }

    updateShipping(shipmentDetail: ShipmentDetailViewModel): Observable<boolean> {
        return this.http
            .post(this.apiUrl + '/UpdateShipmentDetail', shipmentDetail)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    deleteShipping(shipmentDetailId: number): Observable<boolean> {
        return this.http
            .get(this.apiUrl + '/DeleteShipmentDetail?s;hipmentDetailId=' + shipmentDetailId)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }

    cancelOrder(orderId: number): Observable<boolean> {
        return this.http
            .get(this.apiUrl + '/cancelOrder?orderId=' + orderId)
            .pipe(
                map((res: boolean) => {
                    return res;
                })
            );
    }
}