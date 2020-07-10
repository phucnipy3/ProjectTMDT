import { Component, OnInit } from '@angular/core';
import { SimpleModalComponent } from 'ngx-simple-modal';

@Component({
    selector: 'cart-redirect-popup',
    templateUrl: './cart-redirect-popup.component.html',
})
export class CartRedictPopupComponent extends SimpleModalComponent<null, number> {
    constructor() {
        super();
    }

    confirm(state: number) {
        this.result = state;
        this.close();
    }
}
