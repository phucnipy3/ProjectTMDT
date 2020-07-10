import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CommentViewModel } from '../../../../models/product/comment';
import { ProductService } from '../../../../services/product.service';

@Component({
    selector: 'comment',
    templateUrl: './comment.component.html',
})
export class CommentComponent implements OnInit {

    @Input() isChild = false;
    @Output() callbackToParent: EventEmitter<null> = new EventEmitter();
    showReply = false;
    @Output() callback: EventEmitter<string> = new EventEmitter();
    @Input() comment: CommentViewModel;

    constructor(
    ) { }

    ngOnInit(): void { }

    showReplyInput() {
        if (this.isChild) {
            this.callbackToParent.emit();
        }
        else {
            this.showReply = !this.showReply;
        }
    }

    reply(content: string) {
        this.callback.emit(content);
    }
}
