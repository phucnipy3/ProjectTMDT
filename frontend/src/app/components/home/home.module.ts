import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HomeRoutingModule } from './home-routing.module';

import * as fromHome from '../home';

const APP_COMPONENTS: any[] = [
    fromHome.HomeComponent,
    fromHome.LandingPageComponent,
];

const APP_POPUP_COMPONENTS: any[] = [];

@NgModule({
    declarations: [APP_COMPONENTS, APP_POPUP_COMPONENTS],
    imports: [
        CommonModule,
        HomeRoutingModule,
    ],
    exports: [APP_POPUP_COMPONENTS],
    entryComponents: [APP_POPUP_COMPONENTS],
})
export class HomeModule { }
