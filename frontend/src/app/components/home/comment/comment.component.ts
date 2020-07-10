import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CommentViewModel } from '../../../../models/product/comment';

@Component({
    selector: 'comment',
    templateUrl: './comment.component.html',
})
export class CommentComponent implements OnInit {

    @Input() isChild = false;
    @Output() callback: EventEmitter<null> = new EventEmitter();
    showReply = false;

    @Input() comment: CommentViewModel;

    constructor() { }

    ngOnInit(): void { }

    reply() {
        if (this.isChild) {
            this.callback.emit();
        }
        else{
            this.showReply = !this.showReply;
        }
    }
}
