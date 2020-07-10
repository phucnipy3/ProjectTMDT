import * as fromHome from '../home';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HomeRoutingModule } from './home-routing.module';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import {NgxPaginationModule} from 'ngx-pagination';


const APP_COMPONENTS: any[] = [
    fromHome.AccountActivationComponent,
    fromHome.BannerComponent,
    fromHome.CartComponent,
    fromHome.CheckoutComponent,
    fromHome.CommentComponent,
    fromHome.CommentInputComponent,
    fromHome.FooterComponent,
    fromHome.GetPasswordComponent,
    fromHome.HomeComponent,
    fromHome.LandingPageComponent,
    fromHome.OrderDetailComponent,
    fromHome.OrdersComponent,
    fromHome.OurServicesComponent,
    fromHome.ProductCardComponent,
    fromHome.ProductDetailComponent,
    fromHome.ProductPageComponent,
    fromHome.ProfileComponent,
    fromHome.RateComponent,
    fromHome.ShippingComponent,
    fromHome.ShippingInputComponent,
    fromHome.SideBarComponent,
    fromHome.SlideShowBannerComponent,
    fromHome.SlideShowProductComponent,
    fromHome.TopMenuComponent,
];

const APP_POPUP_COMPONENTS: any[] = [
    fromHome.CartRedictPopupComponent,
    fromHome.ChangePasswordPopupComponent,
    fromHome.ForgetPasswordPopupComponent,
    fromHome.LoginPopupComponent,
    fromHome.SignUpPopupComponent,
];

@NgModule({
    declarations: [APP_COMPONENTS, APP_POPUP_COMPONENTS],
    imports: [
        CommonModule,
        FormsModule,
        HomeRoutingModule,
        NgxPaginationModule,
    ],
    exports: [APP_POPUP_COMPONENTS],
    entryComponents: [APP_POPUP_COMPONENTS],
})
export class HomeModule { }
