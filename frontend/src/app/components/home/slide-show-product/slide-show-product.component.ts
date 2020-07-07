import { Component, Input, OnInit } from '@angular/core';
import { ProductSildeViewModel } from '../../../../models/product/product-slide';

@Component({
    selector: 'slide-show-product',
    templateUrl: './slide-show-product.component.html',
})
export class SlideShowProductComponent implements OnInit {

    @Input() id = '';
    @Input() title = '';
    @Input() products: ProductSildeViewModel[] = [];
    @Input() canCheckout = true;
    @Input() checkoutLink = '/san-pham';

    readonly itemCount = 6;

    constructor() {
        for (let i = 0; i < 10; i++) {
            this.products.push(new ProductSildeViewModel(i, '../../../assets/image/banner' + (i % 4 + 1) + '.jpg'));
        }
    }

    ngOnInit(): void { }

    getSubItems(index: number, items: any[]) {
        const subItems: any[] = [];
        for (let i = 0; i < this.itemCount && i < items.length; i++) {
            if (i + index < items.length) {
                subItems.push({ ...items[i + index] });
            } else {
                subItems.push({ ...items[i + index - 10] });
            }
        }
        return subItems;
    }
}
