import { Injectable } from '@angular/core';

import { Apollo, gql } from 'apollo-angular';
import { MessageService } from 'primeng/api';
import { catchError, map, take, Observable, EMPTY } from 'rxjs';
import { AddBookCommandInput, Book } from 'src/app/models/book';
import { MessageServiceHelper } from 'src/app/shared/messages/message-service-helper.service';
import { BookListQueries } from './queries';

@Injectable({
  providedIn: 'root',
})
export class BooksListService {
  constructor(
    private apollo: Apollo,
    private messageService: MessageServiceHelper
  ) {}

  get books$() {
    return this.apollo
      .watchQuery<any>({
        query: BookListQueries.bookList,
      })
      .valueChanges.pipe(
        map((result) => {
          return result.data.books;
        })
      );
  }

  addBook(value: any){
    this.apollo.mutate({
      mutation: BookListQueries.addBook,
      variables:{input: value},
      update:(cache: any, result: any)=>{
        if (result.data?.addBook.errors) {
          return result
        }

        const currentData = cache.readQuery({
          query: BookListQueries.bookList
        })

        const books = [
          ...currentData.books,
          result.data.addBook.item
        ]

        cache.writeQuery({
          query: BookListQueries.bookList,
          data: { books }
        })

        return result
      }
    }).pipe(
      take(1),
      map((result: any)=>{
        if (result.errors || result?.data.addBook.errors) {
          this.messageService.addError({
            detail: 'Erreur lors de l\'ajout du livre',
          });
        }else{
          this.messageService.addSuccess({
            detail: 'Livre ajouté'
          })
        }
      }),
      catchError((err)=>{
        this.messageService.addError({
          detail: 'Erreur lors de l\'ajout du livre',
        });
        return EMPTY
      })
    ).subscribe()
  }


  updateBook(value: any){
    this.apollo.mutate({
      mutation: BookListQueries.updateBook,
      variables:{input: value},
      update:(cache: any, result: any)=>{
        if (result.data?.updateBook.errors) {
          return result
        }

        const currentData = cache.readQuery({
          query: BookListQueries.bookList
        })

        const updatedBook = result.data.updateBook.item

        const books = currentData.books.map((b: any)=>b.id === updatedBook.id ? updatedBook : b)

        cache.writeQuery({
          query: BookListQueries.bookList,
          data: { books }
        })

        return result
      }
    }).pipe(
      take(1),
      map((result: any)=>{

        if (result.errors || result?.data.updateBook.errors) {
          this.messageService.addError({
            detail: 'Erreur lors de la mise à jour du livre',
          });
        }else{
          this.messageService.addSuccess({
            detail: 'Livre mis à jour'
          })
        }
      }),
      catchError((err)=>{
        this.messageService.addError({
          detail: 'Erreur lors de l\'ajout du livre',
        });
        return EMPTY
      })
    ).subscribe()
  }




  remove(id: string) {
    this.apollo
      .mutate({
        mutation: BookListQueries.deleteBook,
        variables: { id },
        update: (cache, result: any) =>{
          if(result.data?.deleteBook.errors){
            this.messageService.addError({
              detail: 'Erreur lors de la suppression du livre'
            })
            return;
          }

          const currentData = cache.readQuery<any>({ query: BookListQueries.bookList })
          const deletedId = result.data.deleteBook.item

          const filtered = currentData.books.filter((b: any)=>b.id !== deletedId)

          cache.writeQuery({
            query: BookListQueries.bookList,
            data: { books: filtered ?? [] }
          })
        }
      })
      .pipe(
        take(1),
        map((result: any) =>{
          if (result.errors || result?.data.deleteBook.errors) {
            this.messageService.addError({
              detail: 'Erreur lors de la suppression du livre',
            });
          }else{
            this.messageService.addSuccess({
              detail: 'Livre supprimé'
            })
          }
        }),
        catchError((err) =>{
          this.messageService.addError({
            detail: 'Erreur lors de la suppression du livre',
          });
          return EMPTY
        })
        )
      .subscribe();
  }
}
