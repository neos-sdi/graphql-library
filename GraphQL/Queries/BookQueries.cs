namespace GraphQL.Queries
{
    using Library.Application.Books.Queries;
    using Library.Domain.Entities;
    using Library.Infrastructure;
    using Library.Infrastructure.Extensions;
    using MediatR;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQueries
    {
        
        [UseSorting]
        public async Task<IQueryable<Book>> GetBooks([Service]IMediator mediator) {
            try
            {
                return await mediator.Send(new GetBooksQuery());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        
        public async Task<Book> GetBook([Service]IMediator mediator, Guid id)
        {
            return await mediator.Send(new GetBookByIdQuery(id));
        }
    }
}
