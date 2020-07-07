import { Component, OnInit } from '@angular/core';
import { SideBarData } from '../side-bar/side-bar.component';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'product-page',
    templateUrl: './product-page.component.html',
})
export class ProductPageComponent implements OnInit {

    data: SideBarData[] = [];
    products: ProductCardViewModel[] = [];

    constructor(private messageService: MessageService) {
        this.messageService.sendActivePage('product');
        for (let i = 0; i < 10; i++) {
            this.data.push(new SideBarData(i, 'somevalue', 'Mới nhất' + i));
        }
        let x = new ProductCardViewModel();
        x.id = 1;
        x.image = '../../../assets/image/banner1.jpg';
        x.name = 'abcasfa asd a eqa';
        x.price = 12435;
        x.promotionPrice = 1356;
        this.products.push(x);
    }

    ngOnInit(): void { }
}
