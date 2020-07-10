import { Component, OnInit } from '@angular/core';
import { ShipmentDetailViewModel } from '../../../../models/order/shipment-detail';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { Router } from '@angular/router';
import { User } from '../../../../models/account/user';
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
        private router: Router
    ) { }

    ngOnInit(): void {

        this.user = SessionHelper.getUserFromStorage();
        let shipping = new ShipmentDetailViewModel();
        shipping.phoneNumber = '3544572334';
        shipping.id = 1;
        shipping.name = 'phuc sag á d';
        shipping.address = 'quận 9';
        shipping.email = 'abc.asdas@ấ.ádasd';
        this.shippings.push(shipping);
        this.shippings.push({ ...shipping });

        this.shippings.push({ ...shipping });

        $('.collapse').collapse({
            toggle: false
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

    onDelete(id: number){
        // call api delete shipping, toast
    }
}
