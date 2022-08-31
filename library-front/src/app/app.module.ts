import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GraphQLModule } from './graphql.module';
import { HttpClientModule } from '@angular/common/http'

import { MenubarModule } from 'primeng/menubar'
import { BooksListModule } from './views/books/books-list/books-list.module';
import {ToastModule} from 'primeng/toast';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    GraphQLModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MenubarModule,
    BooksListModule,
    ToastModule
  ],
  providers: [{
    provide: MessageService
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
