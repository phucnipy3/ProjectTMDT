import { Component, OnInit } from '@angular/core';
import { ProductViewModel } from '../../../../models/product/product';
import { CommentViewModel } from '../../../../models/product/comment';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { MessageService } from '../../../../services/message.service';
import { ActivatedRoute } from '@angular/router';
import { ViewedProductService } from '../../../../services/viewed-product.service';
import { ProductSildeViewModel } from '../../../../models/product/product-slide';
import { SessionHelper } from '../../../common/helper/SessionHelper';
import { ProductService } from '../../../../services/product.service';
import { RateViewModel } from '../../../../models/product/rate';
import { User } from '../../../../models/account/user';
import { SimpleModalService } from 'ngx-simple-modal';
import { LoginPopupComponent } from '../login/login-popup-component';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit {

    product: ProductViewModel;
    showCreateComment = false;
    rate: RateViewModel = new RateViewModel();
    comments: CommentViewModel[] = [];

    relatedProducts: ProductCardViewModel[] = [];

    id: number;

    viewedProducts: ProductSildeViewModel[] = [];

    constructor(
        private messageService: MessageService,
        private activatedRoute: ActivatedRoute,
        private viewedProductService: ViewedProductService,
        private productService: ProductService,
        private simpleModalService: SimpleModalService,
        private toastr: ToastrService) {
        this.messageService.sendActivePage('product');
    }

    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe(params => {
            this.id = Number(params.get('id'));
            this.getProduct();
            this.getRelatedProduct();
            this.getRate();
        });
        this.viewedProducts = SessionHelper.getViewedProductFromStorage();
    }

    getProduct() {
        this.productService.getProductDetails(this.id).subscribe((res: ProductViewModel) => {
            this.product = res;
            let viewedProduct = new ProductSildeViewModel(this.product.id, this.product.image);
            this.viewedProductService.addProduct(viewedProduct);
            this.viewedProducts = SessionHelper.getViewedProductFromStorage();

        });
    }
    getRelatedProduct() {
        this.productService.getRelatedProducs(this.id).subscribe((res: ProductCardViewModel[]) => {
            this.relatedProducts = res;
        });
    }

    getRate() {
        this.productService.getRate(this.id).subscribe((res: RateViewModel) => {
            this.rate = res;
        });
    }

    onRate(point: number) {
        const user: User = SessionHelper.getUserFromStorage();
        if (!user) {
            this.simpleModalService.addModal(LoginPopupComponent).subscribe((res) => {
                if (res) {
                    this.productService.rate(this.id, point).subscribe((success) => {
                        if (success) {
                            this.toastr.success('Đánh giá thành công');
                            this.getRate();
                        }
                        else{
                            this.toastr.warning('Đánh giá thất bại');
                        }
                    });
                }
            });
        }
        else{
            this.productService.rate(this.id, point).subscribe((success) => {
                if (success) {
                    this.toastr.success('Đánh giá thành công');
                    this.getRate();
                }
                else{
                    this.toastr.warning('Đánh giá thất bại');
                }
            });
        }
    }
}
