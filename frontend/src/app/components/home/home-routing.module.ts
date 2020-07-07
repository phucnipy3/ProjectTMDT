import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProfileComponent } from './profile/profile.component';
import { CartComponent } from './cart/cart.component';
import { GetPasswordComponent } from './get-password/get-password.component';
import { OrdersComponent } from './orders/orders.component';
import { OrderDetailComponent } from './orders/order-detail/order-detail.component';
import { ShippingComponent } from './shipping/shipping.component';

const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'san-pham',
        component: ProductPageComponent,
    },
    {
        path: 'chi-tiet/:id',
        component: ProductDetailComponent
    },
    {
        path: 'thong-tin-ca-nhan',
        component: ProfileComponent
    },
    {
        path: 'gio-hang',
        component: CartComponent
    },
    {
        path: 'quen-mat-khau/:email',
        component: GetPasswordComponent
    },
    {
        path: 'xem-don-hang',
        component: OrdersComponent
    },
    {
        path: 'chi-tiet-don-hang/:id',
        component: OrderDetailComponent
    },
    {
        path: 'giao-hang',
        component: ShippingComponent
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class HomeRoutingModule { }