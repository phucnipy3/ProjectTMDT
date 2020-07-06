import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ProfileComponent } from './profile/profile.component';
import { CartComponent } from './cart/cart.component';

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
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class HomeRoutingModule { }