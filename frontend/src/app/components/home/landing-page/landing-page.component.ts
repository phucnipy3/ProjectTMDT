import { Component, OnInit } from '@angular/core';
import { HomeService } from '../../../../services/home.service';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'landing-page',
    templateUrl: './landing-page.component.html',
})
export class LandingPageComponent implements OnInit {

    version = '';

    constructor(
        private httpService: HomeService,
        private messageService: MessageService) {
            this.messageService.sendActivePage('home');
         }

    ngOnInit(): void {
        this.httpService.getVersion().subscribe((res: string) => {
            this.version = res;
        })
    }
}
