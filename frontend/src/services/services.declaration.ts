import { HomeService } from './home.service';
import { CartService } from './cart.service';
import { MessageService } from './message.service';
import { ViewedProductService } from './viewed-product.service';
import { AuthenticateService } from './authenticate.service';
import { ProductService } from './product.service';
import { OrderService } from './order.service';
import { PasswordCheckService } from './check-password';
export const Services: any = [
    HomeService,
    CartService,
    MessageService,
    ViewedProductService,
    AuthenticateService,
    ProductService,
    OrderService,
    PasswordCheckService,
];
