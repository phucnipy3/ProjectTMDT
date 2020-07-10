import { Component, OnInit } from '@angular/core';
import { SideBarData } from '../side-bar/side-bar.component';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { MessageService } from '../../../../services/message.service';
import { ProductService } from '../../../../services/product.service';

@Component({
    selector: 'product-page',
    templateUrl: './product-page.component.html',
})
export class ProductPageComponent implements OnInit {

    data: SideBarData[] = [];
    products: ProductCardViewModel[] = [];
    pageNumber = 1;
    pageSize = 10;
    totalCount = 0;

    constructor(
        private messageService: MessageService,
        private productService: ProductService) {
        this.messageService.sendActivePage('product');
        
        //side bar
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

    ngOnInit(): void { 
        this.getProducts();
    }

    getProducts(){
        this.productService.getProducts(1,'').subscribe((res) =>{
            if(res: PagedList<ProductCardViewModel>){
                this.products = res.items;
                this.totalCount = res.totalCount;
            }
        })
    }

}
