import {
    Component,
    ElementRef,
    EventEmitter,
    Input,
    OnChanges,
    OnInit,
    Output,
    SimpleChange,
    SimpleChanges,
    ViewChild
    } from '@angular/core';

declare var $: any;

@Component({
    selector: 'comment-input',
    templateUrl: './comment-input.component.html',
})
export class CommentInputComponent implements OnInit, OnChanges {

    @Input() public show = false;
    @ViewChild('collapse') collapse: ElementRef;
    @Output() callback: EventEmitter<string> = new EventEmitter();
    afterInit = false;

    comment = '';

    constructor() { }

    ngOnChanges(changes: SimpleChanges): void {
        if (this.afterInit) {
            $(this.collapse.nativeElement).collapse('toggle');
        }
    }

    ngOnInit(): void {
        this.afterInit = true;
        $('.collapse').collapse({
            toggle: false
          });
    }

    onComment(){
        this.callback.emit(this.comment);
    }
}
