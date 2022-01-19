namespace GraphQL.Queries
{
    using Library.Domain.Entities;
    using Library.Infrastructure;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQueries
    {
        public IQueryable<Book> GetBooks([Service] LibraryDbContext context) =>
           context.Books;
    }
}
