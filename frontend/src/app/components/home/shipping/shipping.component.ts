import { Component, OnInit } from '@angular/core';
import { ShipmentDetailViewModel } from '../../../../models/order/shipment-detail';
declare var $: any;
@Component({
    selector: 'shipping',
    templateUrl: './shipping.component.html',
})
export class ShippingComponent implements OnInit {

    authen = true;

    shippings: ShipmentDetailViewModel[] = [];
    shippingId: number;
    constructor() { }

    ngOnInit(): void {

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

    updateShipping(id) {
        this.shippingId = id;
        $('#shippingCollapse').collapse('show');
    }
    closeCollapse(){
        $('#shippingCollapse').collapse('hide');
    }
}
