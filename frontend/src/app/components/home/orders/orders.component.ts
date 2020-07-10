import { Component, OnInit } from '@angular/core';
import { OrderViewModel } from '../../../../models/order/order';
import { ProductOnOrderViewModel } from '../../../../models/order/product-on-order';
import { TimeLog } from '../../../../models/order/time-log';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
})
export class OrdersComponent implements OnInit {

    orders: OrderViewModel[] = [];

    constructor(private messageService: MessageService) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void { 
        let order = new OrderViewModel();
        order.status = 'Đã giao';
        order.totalMoney = 1234546;
        let product = new ProductOnOrderViewModel();
        product.image = '../../../assets/image/banner1.jpg';
        product.name = 'agds sdf dsgdfd há á';
        product.price = 12354;
        product.promotionPrice = 136658;
        product.count = 2;
        order.products.push(product);
        let timelog = new TimeLog();
        timelog.timeLine = '12-12-2020';
        timelog.event = 'event sa grrga a';
        order.timeLogs.push(timelog);
        this.orders.push(order);
    }
}
