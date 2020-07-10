import { Component, OnInit } from '@angular/core';
import { ShipmentDetailViewModel } from '../../../../models/order/shipment-detail';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { Router } from '@angular/router';
import { User } from '../../../../models/account/user';
import { OrderService } from '../../../../services/order.service';
import { ToastrService } from 'ngx-toastr';
declare var $: any;
@Component({
    selector: 'shipping',
    templateUrl: './shipping.component.html',
})
export class ShippingComponent implements OnInit {

    user: User;

    shippings: ShipmentDetailViewModel[] = [];
    selectedShipping: ShipmentDetailViewModel;
    constructor(
        private router: Router,
        private orderService: OrderService,
        private toastr: ToastrService
    ) { }

    ngOnInit(): void {
        this.user = SessionHelper.getUserFromStorage();

        this.getShipmentDetails();

        $('.collapse').collapse({
            toggle: false
        });
    }

    getShipmentDetails() {
        this.orderService.getShipmentDetails().subscribe((res: ShipmentDetailViewModel[]) => {
            if (res) {
                this.shippings = res;
            }
        });
    }

    updateShipping(shipping: ShipmentDetailViewModel) {
        this.selectedShipping = shipping;
        $('#shippingCollapse').collapse('show');
    }
    closeCollapse() {
        $('#shippingCollapse').collapse('hide');
    }

    moveToCheckout(shipping: ShipmentDetailViewModel) {
        SessionHelper.saveShippingToStorage(shipping);
        this.router.navigate(['/thanh-toan']);
    }

    onDelete(id: number) {
        this.orderService.deleteShipping(id).subscribe((res) => {
            if (res) {
                this.toastr.success('Xóa thành công');
                this.getShipmentDetails();
            }
            else {
                this.toastr.warning('Thất bại');
            }
        }, () => {
            this.toastr.warning('Đã có lỗi xảy ra');
        });
    }
}
