import { Component, OnInit } from '@angular/core';
import { RateViewModel } from '../../../../models/product/rate';

@Component({
    selector: 'rate',
    templateUrl: './rate.component.html',
})
export class RateComponent implements OnInit {

    rate: RateViewModel;
    stars: number[] = [1, 1, 1, 1, 1];

    constructor() { }

    ngOnInit(): void {
        this.rate = new RateViewModel();
        this.rate.ratePoint = 4.7;
        this.rate.persentPoints = [16, 19, 30, 70, 20];
    }

    resetStar() {
        this.stars = [1, 1, 1, 1, 1];
        if (this.rate.userRate) {
            for (let i = 0; i < this.rate.userRate; i++) {
                this.stars[i] = 2;
            }
        }
    }
    setStar(index) {
        this.stars = [1, 1, 1, 1, 1];
        for (let i = 0; i <= index; i++) {
            this.stars[i] = 2;
        }
    }
}
