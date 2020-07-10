import { Component, OnInit } from '@angular/core';
import { SideBarData } from '../side-bar/side-bar.component';
import { ProductCardViewModel } from '../../../../models/product/product-card';
import { MessageService } from '../../../../services/message.service';
import { ProductService } from '../../../../services/product.service';
import { PagedList } from '../../../../models/paged-list/paged-list';
import { ToastrService } from 'ngx-toastr';
import { CategoryViewModel } from '../../../../models/product/category';

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
    activeKey = 0;
    constructor(
        private messageService: MessageService,
        private productService: ProductService,
        private toastr: ToastrService) {
        this.messageService.sendActivePage('product');
    }

    ngOnInit(): void {
        this.getCategories();
    }

    getCategories() {
        this.productService.getCateries().subscribe((res: CategoryViewModel[]) => {
            if (res) {
                this.activeKey = res[0].id;
                res.forEach((x) => {
                    this.data.push(new SideBarData(x.id, x, x.name));
                });
                this.getProducts();

            }
        });
    }
    getProducts() {
        this.productService.getProducts(this.activeKey, '').subscribe((res: PagedList<ProductCardViewModel>) => {
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
            }, () => {
                this.toastr.warning('Tải trang lỗi');
            });
    }

    onCategoryChange(data: SideBarData){
        this.categoryId = data.value.id;
        this.productService.getProducts(this.categoryId, '').subscribe((res: PagedList<ProductCardViewModel>) => {
            if (res) {
                this.products = res.items;
                this.totalCount = res.totalCount;
            }
        });
    }

    onSearch(seachString: string){
        this.searchString = seachString;
        this.productService.getProducts(this.categoryId, this.searchString).subscribe((res: PagedList<ProductCardViewModel>) => {
            if (res) {
                this.products = res.items;
                this.totalCount = res.totalCount;
            }
        });
    }
}
