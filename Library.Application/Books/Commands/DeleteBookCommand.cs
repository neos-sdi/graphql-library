namespace Library.Application.Books.Commands;

using Library.Application.Interfaces;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Errors;

using MediatR;

using System;
using System.Threading.Tasks;

public record DeleteBookCommand(Guid Id) : IRequest<Payload<Guid>>;
public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Payload<Guid>>
{
    private readonly IRepository<Book> _repository;

    public DeleteBookCommandHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public Task<Payload<Guid>> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return HandleInternal(request, cancellationToken);
    }

    private async Task<Payload<Guid>> HandleInternal(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.RemoveAsync(request.Id, cancellationToken);
        if (result == Guid.Empty)
        {
            return new Payload<Guid>(new UserError($"Could not delete profile with Id: '{ request.Id }'", (int)BookErrors.NotFound));
        }

        return new Payload<Guid>(result);
    }
}
