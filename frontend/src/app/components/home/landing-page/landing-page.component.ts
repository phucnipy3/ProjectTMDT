import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../../services/home.service';
import { MessageService } from '../../../../services/message.service';
import { ProductSildeViewModel } from '../../../../models/product/product-slide';

@Component({
    selector: 'landing-page',
    templateUrl: './landing-page.component.html',
})
export class LandingPageComponent implements OnInit {

    version = '';
    hotProducts: ProductSildeViewModel[] = [];
    bestProducts: ProductSildeViewModel[] = [];
    constructor(
        private httpService: HomeService,
        private messageService: MessageService) {
        this.messageService.sendActivePage('home');
    }

    ngOnInit(): void {
        this.getProducts();
    }

    getProducts() {
        this.httpService.getHotProducts().subscribe((res: ProductSildeViewModel[]) => {
            this.hotProducts = res;
        });
        this.httpService.getBestProducts().subscribe((res: ProductSildeViewModel[]) => {
            this.bestProducts = res;
        });
    }
}
