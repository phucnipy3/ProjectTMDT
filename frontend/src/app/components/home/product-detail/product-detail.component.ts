import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../../../models/product/product';
import { CommentViewModel } from '../../../../models/product/comment';
import { ProductCardViewModel } from '../../../../models/product/product-card';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit {

    product: ProductViewModel;
    showCreateComment = false;

    comments: CommentViewModel[] = [];

    relatedProducts: ProductCardViewModel[] = [];

    constructor() { }

    ngOnInit(): void {
        this.product = new ProductViewModel();
        this.product.name = 'name name an aemd á á';
        this.product.promotionPrice = 14356;
        this.product.price = 25776434;
        this.product.savePersent = '32%';
        this.product.image = '../../../assets/image/banner1.jpg';
        this.product.detail = '<p>details  ấ gs fa dhedf a</p>';
        this.product.brand = 'AOE';

        // const x = new CommentViewModel();
        // x.time = '12:12';
        // x.date = '21/2/2020';
        // x.content = 'this is a comment';
        // x.author = 'Phúc Nguyễn';
        // x.image = '../../../assets/image/banner1.jpg';
        // const y = {...x};
        // x.children = [];
        // x.children.push(y);
        // this.comments.push(x);

        const x = new ProductCardViewModel();
        x.id = 1;
        x.image = '../../../assets/image/banner1.jpg';
        x.name = 'abcasfa asd a eqa';
        x.price = 12435;
        x.promotionPrice = 1356;
        this.relatedProducts.push(x);
        this.relatedProducts.push({...x});

    }
}
