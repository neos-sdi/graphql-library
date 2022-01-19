namespace GraphQL.Queries
{
    using Library.Domain.Entities;
    using Library.Infrastructure;
    using Library.Infrastructure.Extensions;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQueries
    {
        [UseLibraryDb]
        [UseSorting]
        public IQueryable<Book> GetBooks([ScopedService] LibraryDbContext context) {
            try
            {
                return context.Books;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
    }
}
