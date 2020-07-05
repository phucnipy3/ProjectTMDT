import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'top-menu',
    templateUrl: './top-menu.component.html',
})
export class TopMenuComponent implements OnInit {

    authen = false;

    constructor() { }

    ngOnInit(): void { }
}
