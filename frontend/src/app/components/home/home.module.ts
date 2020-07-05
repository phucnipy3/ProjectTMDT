import * as fromHome from '../home';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';


const APP_COMPONENTS: any[] = [
    fromHome.BannerComponent,
    fromHome.CommentComponent,
    fromHome.CommentInputComponent,
    fromHome.FooterComponent,
    fromHome.HomeComponent,
    fromHome.LandingPageComponent,
    fromHome.OurServicesComponent,
    fromHome.ProductCardComponent,
    fromHome.ProductDetailComponent,
    fromHome.ProductPageComponent,
    fromHome.RateComponent,
    fromHome.SideBarComponent,
    fromHome.SlideShowBannerComponent,
    fromHome.SlideShowProductComponent,
    fromHome.TopMenuComponent,
];

const APP_POPUP_COMPONENTS: any[] = [];

@NgModule({
    declarations: [APP_COMPONENTS, APP_POPUP_COMPONENTS],
    imports: [
        CommonModule,
        FormsModule,
        HomeRoutingModule,
    ],
    exports: [APP_POPUP_COMPONENTS],
    entryComponents: [APP_POPUP_COMPONENTS],
})
export class HomeModule { }
