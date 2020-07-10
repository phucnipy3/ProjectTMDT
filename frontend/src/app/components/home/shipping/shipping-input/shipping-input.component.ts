import { Component, OnInit, Input, EventEmitter, Output, OnChanges, SimpleChanges } from '@angular/core';
import { ShipmentDetailViewModel } from 'src/models/order/shipment-detail';

@Component({
    selector: 'shipping-input',
    templateUrl: './shipping-input.component.html',
})
export class ShippingInputComponent implements OnInit, OnChanges {

    @Input() shippingInput: ShipmentDetailViewModel;
    @Output() cancel: EventEmitter<null> = new EventEmitter();
    @Output() callback: EventEmitter<ShipmentDetailViewModel> = new EventEmitter();
    updating = false;
    shipping: ShipmentDetailViewModel;
    constructor() {
    }
    ngOnChanges(changes: SimpleChanges): void {
        if (this.shippingInput) {
            this.updating = true;
            this.shipping = { ...this.shippingInput }
        }
        else {
            this.shipping = new ShipmentDetailViewModel();
            this.updating = false;
        }
    }

    ngOnInit(): void {
        if (this.shippingInput) {
            this.updating = true;
            this.shipping = { ...this.shippingInput }
        }
        else {
            this.shipping = new ShipmentDetailViewModel();
            this.updating = false;
        }
    }

    onCancel() {
        this.cancel.emit();
    }

    onUpdate() {
        // call api update shipping, toast,  call cancel() to close;
        this.shippingInput = this.shipping;
    }

    onMoveToCheckout() {
        this.callback.emit(this.shipping);
    }
}
