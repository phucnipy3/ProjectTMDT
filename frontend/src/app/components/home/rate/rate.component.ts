import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { RateViewModel } from '../../../../models/product/rate';

@Component({
    selector: 'rate',
    templateUrl: './rate.component.html',
})
export class RateComponent implements OnInit {

    @Input() rate: RateViewModel;
    stars: number[] = [1, 1, 1, 1, 1];
    @Output() callback: EventEmitter<number> = new EventEmitter();

    constructor() { }

    ngOnInit(): void {
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

    onClick(i) {
        this.callback.emit(i + 1);
    }
}
