import { Component, OnInit, Input } from '@angular/core';
import { ProductCardViewModel } from '../../../../models/product/product-card';

@Component({
    selector: 'product-card',
    templateUrl: './product-card.component.html',
})
export class ProductCardComponent implements OnInit {

    @Input() product: ProductCardViewModel;

    constructor() { }

    ngOnInit(): void { }
}
