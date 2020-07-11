import { ShipmentDetailViewModel } from './shipment-detail';
import { ProductOnOrderViewModel } from './product-on-order';
import { TimeLog } from './time-log';

export class OrderViewModel {
    public id: number;
    public products: ProductOnOrderViewModel[] = [];
    public deliveryMethod: string;
    public totalShipping: number;
    public status: string;
    public totalProductMoney: number;
    public canCancel: boolean;
    public totalMoney: number;
    public paymentMethod: string;
    public shipmentDetail: ShipmentDetailViewModel;
    public timeLogs: TimeLog[] = [];
}