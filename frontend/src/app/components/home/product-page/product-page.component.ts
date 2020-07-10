import { Component, OnInit } from '@angular/core';
import { SideBarData } from '../side-bar/side-bar.component';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { MessageService } from '../../../../services/message.service';
import { ProductService } from '../../../../services/product.service';
import { PagedList } from '../../../../models/paged-list/paged-list';

@Component({
    selector: 'product-page',
    templateUrl: './product-page.component.html',
})
export class ProductPageComponent implements OnInit {

    data: SideBarData[] = [];
    products: ProductCardViewModel[] = [];
    pageNumber = 1;
    pageSize = 12;
    totalCount = 0;
    categoryId = 0;
    searchString = '';
    constructor(
        private messageService: MessageService,
        private productService: ProductService) {
        this.messageService.sendActivePage('product');

        //side bar
        for (let i = 0; i < 10; i++) {
            this.data.push(new SideBarData(i, 'somevalue', 'Mới nhất' + i));
        }
    }

    ngOnInit(): void {
        this.getProducts();
    }

    getProducts() {
        this.productService.getProducts(0, '').subscribe((res: PagedList<ProductCardViewModel>) => {
            if (res) {
                this.products = res.items;
                this.totalCount = res.totalCount;
            }
        });
    }

    changePage(page: number) {
        this.productService.getProducts(this.categoryId, this.searchString, page, this.pageSize)
        .subscribe((res: PagedList<ProductCardViewModel>) => {
            if (res) {
                this.products = res.items;
                this.totalCount = res.totalCount;
                this.pageNumber = page;
                }
            });
    }

}
