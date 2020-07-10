import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedComponent as SharedComponents, SharedPopupComponent as SharedPopupComponents } from './shared-component.declaration';
import { FormsModule } from '@angular/forms';

const APP_COMPONENTS: any[] = [
    SharedComponents
]

const APP_POPUP_COMPONENTS: any[] = [
    SharedPopupComponents
]

@NgModule({
    declarations: [
        APP_COMPONENTS,
        APP_POPUP_COMPONENTS,
    ],
    imports: [
        FormsModule,
        CommonModule,
    ],
    exports: [
        APP_COMPONENTS,
    ],
    entryComponents: [
        APP_POPUP_COMPONENTS
    ]
})
export class SharedComponentModule { }