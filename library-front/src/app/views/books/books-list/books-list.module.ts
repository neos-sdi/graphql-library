import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BooksListComponent } from './books-list.component';
import { TableModule } from 'primeng/table'
import { ButtonModule } from 'primeng/button';
import { ConfirmDialogModule} from 'primeng/confirmdialog'
import { ConfirmationService } from 'primeng/api';
import {DialogModule} from 'primeng/dialog';
import { BookFormModule } from 'src/app/components/books/book-form/book-form.module';

@NgModule({
  declarations: [
    BooksListComponent
  ],
  imports: [
    CommonModule,
    TableModule,
    ButtonModule,
    ConfirmDialogModule,
    DialogModule,
    BookFormModule
  ],
  providers: [ConfirmationService]
})
export class BooksListModule { }
