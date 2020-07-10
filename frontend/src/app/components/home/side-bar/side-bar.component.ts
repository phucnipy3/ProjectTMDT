import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'side-bar',
    templateUrl: './side-bar.component.html',
})
export class SideBarComponent implements OnInit {

    @Input() public haveSearch = true;
    @Input() public data: SideBarData[] = [];
    @Input() public title: string;

    @Output() public callback: EventEmitter<SideBarData> = new EventEmitter();
    @Output() public search: EventEmitter<string> = new EventEmitter();

    @Input() public keyActive: any;
    searchString = '';

    constructor() { }

    ngOnInit(): void {
        if (this.data.length > 0) {
            this.keyActive = this.data[0].key;
        }
    }

    onClick(item: SideBarData) {
        this.keyActive = item.key;
        this.callback.emit(item);
    }
    onKeyup(event: any) {
        if (event.key === 'Enter') {
            this.search.emit(this.searchString);
        }
    }
}

export class SideBarData {
    public key: any;
    public value: any;
    public displayValue: string;
    constructor(key: any, value: any, displayValue: any) {
        this.key = key;
        this.value = value;
        this.displayValue = displayValue;
    }
}
