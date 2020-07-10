import { RouterModule, Routes, CanActivate } from '@angular/router';
import { NgModule } from '@angular/core';
import { LoginComponent } from './login/login.component';
import { OrderComponent } from './order/order.component';
import { AdminGuard } from '../../../guards/admin.guard';


const routes: Routes = [
    {
        path: 'dang-nhap',
        component: LoginComponent,
    },
    {
        path: 'quan-ly-don-hang',
        redirectTo: ''
    },
    {
        path: '',
        component: OrderComponent,
        canActivate: [AdminGuard]
    },

];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class AdminRoutingModule { }