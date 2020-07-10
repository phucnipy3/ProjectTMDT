import { Component, OnInit } from '@angular/core';
import { OrderViewModel } from '../../../../models/order/order';
import { ProductOnOrderViewModel } from '../../../../models/order/product-on-order';
import { TimeLog } from '../../../../models/order/time-log';
import { MessageService } from '../../../../services/message.service';
import { OrderStatusViewModel } from '../../../../models/order/order-status';
import { OrderService } from '../../../../services/order.service';
import { Router } from '@angular/router';

@Component({
    selector: 'orders',
    templateUrl: './orders.component.html',
})
export class OrdersComponent implements OnInit {

    orders: OrderViewModel[] = [];
    orderStatus: OrderStatusViewModel[] = [];
    selectedStatus: OrderStatusViewModel = new OrderStatusViewModel();
    searchString = '';
    tempString = '';
    pageSize = 10;
    pageNumber = 1;
    totalCount = 0;

    constructor(
        private messageService: MessageService,
        private orderService: OrderService,
        private router: Router) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.orderService.getOrderStatus().subscribe((res) => {
            if (res) {
                this.orderStatus = res;
                this.selectedStatus = res[0];
                this.getOrders('', 1);
            }
        });
    }

    changeStatus(status: OrderStatusViewModel) {
        this.selectedStatus = status;
        this.tempString = '';
        this.searchString = '';
        this.getOrders('', 1);
    }

    getOrders(searchString: string, pageNumber: number) {
        this.orderService.getOrders(this.searchString, this.selectedStatus.id, pageNumber, this.pageNumber)
            .subscribe((res) => {
                if (res) {
                    this.orders = res.items;
                    this.pageNumber = res.pageNumber;
                    this.totalCount = res.totalCount;
                }
            });
    }

    search() {
        this.searchString = this.tempString;
        this.getOrders(this.searchString, 1);
    }

    changePage(page){
        this.getOrders(this.searchString, page);
    }

    moveToDetail(id: number){
        this.router.navigate(['/chi-tiet-don-hang/' + id]);
    }

    cancelOrder(id: number){
        
    }
}
