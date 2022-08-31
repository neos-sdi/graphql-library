namespace GraphQL.Mutations;

using Library.Application.Authors.Commands;
using Library.Domain.Common;
using Library.Domain.Entities;

using MediatR;

[ExtendObjectType(OperationTypeNames.Mutation)]
public class AuthorMutations
{
    public async Task<Payload<Author>> AddBookAsync(
        AddAuthorCommand input,
        [Service] IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(input, cancellationToken);
    }

}
