import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';

const routes: Routes = [
    // {
    //     path: '',
    //     component: LandingPageComponent,
    // },
    // {
    //     path: '',
    //     component: ProductPageComponent,
    // },
    {
        path: '',
        component: ProductDetailComponent
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class HomeRoutingModule { }