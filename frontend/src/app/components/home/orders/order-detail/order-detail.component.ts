import { Component, OnInit } from '@angular/core';
import { OrderViewModel } from '../../../../../models/order/order';
import { ProductOnOrderViewModel } from '../../../../../models/order/product-on-order';
import { TimeLog } from '../../../../../models/order/time-log';
import { ShipmentDetailViewModel } from '../../../../../models/order/shipment-detail';
import { MessageService } from '../../../../../services/message.service';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { OrderService } from '../../../../../services/order.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'order-detail',
    templateUrl: './order-detail.component.html',
})
export class OrderDetailComponent implements OnInit {

    order: OrderViewModel;
    id: number;
    constructor(
        private messageService: MessageService,
        private activatedRoute: ActivatedRoute,
        private orderService: OrderService,
        private toastr: ToastrService) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe((res: ParamMap) => {
            if (res) {
                this.id = Number(res.get('id'));
                this.orderService.getOrderDetail(this.id).subscribe((order: OrderViewModel) => {
                    if (order) {
                        this.order = order;
                    }
                });
            }
        });

    }

    cancelOrder() {
        this.orderService.cancelOrder(this.id).subscribe((res) => {
            if (res) {
                this.toastr.success('Đã hủy đơn hàng');
                this.orderService.getOrderDetail(this.id).subscribe((order: OrderViewModel) => {
                    if (order) {
                        this.order = order;
                    }
                });
            }
            else {
                this.toastr.warning('Hủy đơn hàng thất bại');
            }
        }, () => {
            this.toastr.warning('Đã xảy ra lỗi');
        });
    }
}
