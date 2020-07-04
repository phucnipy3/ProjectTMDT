import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../../services/home.service';

@Component({
    selector: 'landing-page',
    templateUrl: './landing-page.component.html',
})
export class LandingPageComponent implements OnInit {

    version = '';

    constructor(
        private httpService: HomeService) { }

    ngOnInit(): void {
        this.httpService.getVersion().subscribe((res: string) => {
            this.version = res;
        })
    }
}
