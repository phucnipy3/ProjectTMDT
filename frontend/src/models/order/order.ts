import { ShipmentDetailViewModel } from './shipment-detail';
import { ProductOnOrderViewModel } from './product-on-order';
import { TimeLog } from './time-log';

export class OrderViewModel {
    public id: number;
    public information: ShipmentDetailViewModel;
    public status: string;
    public products: ProductOnOrderViewModel[] = [];
    public timeLogs: TimeLog[] = [];
    public totalProductMoney: number;
    public transport: string;
    public transportFee: number;
    public paymentMethods: string;
    public totalMoney: number;
    public tag: string;
    public createDate: string;
    public allNames: string;
}