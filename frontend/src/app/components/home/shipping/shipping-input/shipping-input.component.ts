import { Component, OnInit, Input, EventEmitter, Output, OnChanges, SimpleChanges } from '@angular/core';
import { ShipmentDetailViewModel } from 'src/models/order/shipment-detail';
import { OrderService } from '../../../../../services/order.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'shipping-input',
    templateUrl: './shipping-input.component.html',
})
export class ShippingInputComponent implements OnInit, OnChanges {

    @Input() shippingInput: ShipmentDetailViewModel;
    @Output() cancel: EventEmitter<null> = new EventEmitter();
    @Output() callback: EventEmitter<ShipmentDetailViewModel> = new EventEmitter();
    @Output() updated: EventEmitter<null> = new EventEmitter();
    updating = false;
    shipping: ShipmentDetailViewModel;
    constructor(
        private orderService: OrderService,
        private toastr: ToastrService
    ) {
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
        this.orderService.updateShipping(this.shipping).subscribe((res) => {
            if (res) {
                this.toastr.success('Cập nhật thành công');
                this.updated.emit();
                this.cancel.emit();
            }
            else {
                this.toastr.warning('Cập nhật thất bại');
            }
        }, () => {
            this.toastr.warning('Có lỗi xảy ra');
        });
    }

    onMoveToCheckout() {
        this.callback.emit(this.shipping);
    }
}
