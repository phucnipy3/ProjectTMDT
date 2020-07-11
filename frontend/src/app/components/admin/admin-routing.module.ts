import { AdminGuard } from '../../../guards/admin.guard';
import { LoginComponent } from './login/login.component';
import { NgModule } from '@angular/core';
import { OrderComponent } from './order/order.component';
import { RouterModule, Routes } from '@angular/router';


const routes: Routes = [
    {
        path: '',
        component: OrderComponent,
        canActivate: [AdminGuard]
    },
    {
        path: 'quan-ly-don-hang',
        redirectTo: ''
    },
    {
        path: 'dang-nhap',
        component: LoginComponent,
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AdminRoutingModule { }