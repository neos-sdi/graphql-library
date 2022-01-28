namespace GraphQL.Mutations
{
    using Library.Application.Books.Commands;
    using Library.Domain.Common;
    using Library.Domain.Entities;

    using MediatR;

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutations
    {
        public async Task<Payload<Book>> AddBookAsync(
        AddBookCommand input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
        {
            return await mediator.Send(input, cancellationToken);
        }
    }
}
