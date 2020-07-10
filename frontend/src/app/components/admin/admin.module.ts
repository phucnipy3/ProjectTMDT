import * as fromAdmin from '../admin';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NgxPaginationModule } from 'ngx-pagination';
import { ToastrModule } from 'ngx-toastr';
import { RouterModule } from '@angular/router';
import { AdminRoutingModule } from './admin-routing.module';


const APP_COMPONENTS: any[] = [
    fromAdmin.LoginComponent,
    fromAdmin.OrderComponent,
    fromAdmin.AdminComponent,
];

const APP_POPUP_COMPONENTS: any[] = [

];

@NgModule({
    declarations: [APP_COMPONENTS, APP_POPUP_COMPONENTS],
    imports: [
        CommonModule,
        FormsModule,
        AdminRoutingModule,
        NgxPaginationModule,
    ],
    exports: [APP_POPUP_COMPONENTS],
    entryComponents: [APP_POPUP_COMPONENTS],
})
export class AdminModule { }
