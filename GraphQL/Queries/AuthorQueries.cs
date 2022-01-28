namespace GraphQL.Queries
{
    using Library.Application.Authors.Queries;
    using Library.Domain.Entities;
    using Library.Infrastructure;
    using MediatR;

    [ExtendObjectType(OperationTypeNames.Query)]
    public class AuthorQueries
    {
        public async Task<IQueryable<Author>> GetAuthors([Service] IMediator mediator)
        {
            try
            {
                return await mediator.Send(new GetAuthorsQuery());
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
