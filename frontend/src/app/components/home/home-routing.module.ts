import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LandingPageComponent } from './landing-page/landing-page.component';
import { ProductPageComponent } from './product-page/product-page.component';

const routes: Routes = [
    {
        path: '',
        component: LandingPageComponent,
    },
    {
        path: 'product',
        component: ProductPageComponent,
    }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class HomeRoutingModule { }