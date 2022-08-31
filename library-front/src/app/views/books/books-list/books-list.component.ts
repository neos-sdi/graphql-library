import { Component, OnInit } from '@angular/core';
import { Apollo, gql } from 'apollo-angular';
import { ConfirmationService } from 'primeng/api';
import { map, Observable, of } from 'rxjs';
import { Book } from 'src/app/models/book';
import { BooksListService } from './books-list.service';

@Component({
  selector: 'app-books-list',
  templateUrl: './books-list.component.html',
  styleUrls: ['./books-list.component.scss']
})
export class BooksListComponent implements OnInit {

  books$ = this.service.books$
  formDisplay = false
  editingBook = undefined

  constructor(private service: BooksListService, private confirmationService: ConfirmationService) { }

  ngOnInit(): void {

  }

  edit(book: any){
    this.editingBook = book
    this.formDisplay = true
  }

  remove(book: any){
    this.confirmationService.confirm({
      message: `Voulez-vous supprimer le livre ${ book.title } ?`,
      accept:() =>{
        this.service.remove(book.id)
      }
    })
  }

  save(book: any){
    this.formDisplay = false
    if(!book){
      return;
    }

    if(book.id){
      this.service.updateBook(book)
    }else{
      this.service.addBook({ title: book.title, description: book.description})
    }
  }

}
