import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from '../../../../services/message.service';

@Component({
    selector: 'get-password',
    templateUrl: './get-password.component.html',
})
export class GetPasswordComponent implements OnInit {

    email: string;

    constructor(
        private activatedRoute: ActivatedRoute,
        private messageService: MessageService) {
        this.messageService.clearActivePage();
    }

    ngOnInit(): void {
        this.activatedRoute.paramMap.subscribe(params => {
            this.email = params.get('email');
        });
    }
}
