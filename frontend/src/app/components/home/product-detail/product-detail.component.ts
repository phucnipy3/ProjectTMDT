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
import { PagedList } from '../../../../models/paged-list/paged-list';
import { CartService } from '../../../../services/cart.service';

@Component({
    selector: 'product-detail',
    templateUrl: './product-detail.component.html',
})
export class ProductDetailComponent implements OnInit {

    product: ProductViewModel = new ProductViewModel();
    showCreateComment = false;
    rate: RateViewModel = new RateViewModel();
    comments: CommentViewModel[] = [];

    relatedProducts: ProductCardViewModel[] = [];

    id: number;

    viewedProducts: ProductSildeViewModel[] = [];

    pageNumber = 1;
    pageSize = 10;
    totalCount = 0;

    constructor(
        private messageService: MessageService,
        private activatedRoute: ActivatedRoute,
        private viewedProductService: ViewedProductService,
        private productService: ProductService,
        private simpleModalService: SimpleModalService,
        private toastr: ToastrService,
        private cartService: CartService) {
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
                        else {
                            this.toastr.warning('Đánh giá thất bại');
                        }
                    }, () => {
                        this.toastr.warning('Đánh giá thất bại');
                    });
                }
            });
        }
        else {
            this.productService.rate(this.id, point).subscribe((success) => {
                if (success) {
                    this.toastr.success('Đánh giá thành công');
                    this.getRate();
                }
                else {
                    this.toastr.warning('Đánh giá thất bại');
                }
            }, () => {
                this.toastr.warning('Đánh giá thất bại');
            });
        }
    }

    onComment(content: string) {
        const user: User = SessionHelper.getUserFromStorage();
        if (!user) {
            this.simpleModalService.addModal(LoginPopupComponent).subscribe((res) => {
                if (res) {
                    this.productService.comment(this.product.id, content).subscribe((success) => {
                        if (success) {
                            this.getComments();
                            this.toastr.success('Bình luận thành công');
                        }
                        else {
                            this.toastr.warning('Bình luận thất bại');
                        }
                    }, () => {
                        this.toastr.warning('Bình luận thất bại');
                    });
                }
            });
        }
        else {
            this.productService.comment(this.product.id, content).subscribe((success) => {
                if (success) {
                    this.getComments();
                    this.toastr.success('Bình luận thành công');
                }
                else {
                    this.toastr.warning('Bình luận thất bại');
                }
            }, () => {
                this.toastr.warning('Bình luận thất bại');
            });
        }
    }

    onReply(content: string, parentId: number) {
        const user: User = SessionHelper.getUserFromStorage();
        if (!user) {
            this.simpleModalService.addModal(LoginPopupComponent).subscribe((res) => {
                if (res) {
                    this.productService.reply(this.product.id, parentId, content).subscribe((success) => {
                        if (success) {
                            this.getComments();
                            this.toastr.success('Trả lời bình luận thành công');
                        }
                        else {
                            this.toastr.warning('Trả lời bình luận thất bại');
                        }
                    }, () => {
                        this.toastr.warning('Trả lời bình luận thất bại');
                    });
                }
            });
        }
        else {
            this.productService.reply(this.product.id, parentId, content).subscribe((success) => {
                if (success) {
                    this.getComments();
                    this.toastr.success('Trả lời bình luận thành công');
                }
                else {
                    this.toastr.warning('Trả lời bình luận thất bại');
                }
            }, () => {
                this.toastr.warning('Trả lời bình luận thất bại');
            });
        }
    }

    getComments(pageNumber = 1, pageSize = 10) {
        this.productService.getComments(this.id, pageNumber, pageSize).subscribe((res: PagedList<CommentViewModel>) => {
            if (res) {
                this.comments = res.items;
                this.totalCount = res.totalCount;
                this.pageNumber = res.pageNumber;
            }
        });
    }

    changePage(page: number) {
        this.getComments(page);
    }

    addToCart() {
        this.cartService.addProductToCart(this.product);
    }
}
