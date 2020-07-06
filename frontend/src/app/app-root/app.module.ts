import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { Services } from '../../services/services.declaration';
import { SimpleModalModule, defaultSimpleModalOptions } from 'ngx-simple-modal';

const APP_PROVIDERS: any[] = [
  Services,
]

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    HttpClientModule,
    SimpleModalModule.forRoot({container: 'modal-container'}, {...defaultSimpleModalOptions, ...{
      closeOnEscape: true,
      closeOnClickOutside: true,
      wrapperDefaultClasses: 'modal fade',
      wrapperClass: 'show',
      animationDuration: 300,
      autoFocus: false
    }}),
  ],
  providers: [
    APP_PROVIDERS,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
