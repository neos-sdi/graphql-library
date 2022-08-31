namespace Library.Application.Authors.Commands;

using Library.Application.Interfaces;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Errors;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

public record AddAuthorCommand(string FirstName, string LastName) : IRequest<Payload<Author>>;

public class AddAuthorCommandHandler : IRequestHandler<AddAuthorCommand, Payload<Author>>
{
    private readonly IRepository<Author> repository;

    public AddAuthorCommandHandler(IRepository<Author> repository)
    {
        this.repository = repository;
    }

    public Task<Payload<Author>> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return HandleInternal(request, cancellationToken);
    }

    private async Task<Payload<Author>> HandleInternal(AddAuthorCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.LastName))
        {
            return new Payload<Author>(new UserError("An author must have a last name", (int)AuthorErrors.MustHaveName));
        }

        var author = new Author
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        await repository.AddAsync(author, cancellationToken);
        return new Payload<Author>(author);
    }
}