import { gql } from 'apollo-angular';
import { DocumentNode } from 'graphql';

export abstract class BookListQueries {
  public static addBook: DocumentNode = gql`
    mutation addBook($input: AddBookCommandInput!) {
      addBook(input: $input) {
        item {
          id
          title
          description
        }
        errors {
          code
          message
        }
      }
    }
  `;

  public static updateBook: DocumentNode = gql`
    mutation updateBook($input: UpdateBookCommandInput!) {
      updateBook(input: $input) {
        item {
          id
          title
          description
        }
        errors {
          code
          message
        }
      }
    }
  `;

  public static bookList: DocumentNode = gql`
    query {
      books {
        id
        title
        description
      }
    }
  `;

  public static deleteBook: DocumentNode = gql`
    mutation deleteBook($id: UUID!) {
      deleteBook(id: $id) {
        item
        errors {
          code
          message
        }
      }
    }
  `;
}
