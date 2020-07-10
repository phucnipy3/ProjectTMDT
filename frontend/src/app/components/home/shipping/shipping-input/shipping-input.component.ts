import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { ShipmentDetailViewModel } from 'src/models/order/shipment-detail';

@Component({
    selector: 'shipping-input',
    templateUrl: './shipping-input.component.html',
})
export class ShippingInputComponent implements OnInit {

    @Input() id: number;
    @Output() cancel: EventEmitter<null> = new EventEmitter();
    updating = false;
    shipping: ShipmentDetailViewModel;
    constructor() {
        this.shipping = new ShipmentDetailViewModel();
    }

    ngOnInit(): void {
        if (this.id) {
            this.updating = true;
            this.getData();
        }
    }

    getData() {
        this.shipping = new ShipmentDetailViewModel();
        this.shipping.phoneNumber = '3544572334';
        this.shipping.name = 'phuc sag á d';
        this.shipping.address = 'quận 9';
        this.shipping.email = 'abc.asdas@ấ.ádasd';
    }

    onCancel(){
        this.cancel.emit();
    }
}
