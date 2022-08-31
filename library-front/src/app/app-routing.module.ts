import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BooksListComponent } from './views/books/books-list/books-list.component';

const routes: Routes = [{
  path: '',
  redirectTo: 'books',
  pathMatch: 'full'
}, {
  path: 'books',
  component: BooksListComponent
}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
