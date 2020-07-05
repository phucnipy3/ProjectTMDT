import { Component, OnInit } from '@angular/core';
import { RateViewModel } from '../../../../models/product/rate';

@Component({
    selector: 'rate',
    templateUrl: './rate.component.html',
})
export class RateComponent implements OnInit {

    rate: RateViewModel;

    constructor() { }

    ngOnInit(): void {
        this.rate = new RateViewModel();
        this.rate.ratePoint = 4.7;
        this.rate.persentPoints = [16, 19, 30, 70, 20];

    }
}
