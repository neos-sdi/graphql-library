namespace Library.Application.Books.Commands;
using System;
using System.Threading;
using System.Threading.Tasks;

using HotChocolate;

using Library.Application.Interfaces;
using Library.Domain.Common;
using Library.Domain.Entities;

using MediatR;

public record UpdateBookCommand(Guid Id, Optional<string?> Title, Optional<string?> Description) : IRequest<Payload<Book>>;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Payload<Book>>
{
    private readonly IRepository<Book> _repository;

    public UpdateBookCommandHandler(IRepository<Book> repository)
    {
        _repository = repository;
    }

    public Task<Payload<Book>> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return HandleInternal(request, cancellationToken);
    }

    private async Task<Payload<Book>> HandleInternal(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var existingBook = await _repository.FindByIdAsync(request.Id, cancellationToken);
        if (existingBook == null)
        {
            return new Payload<Book>(new UserError($"Unable to find book. Id:{ request.Id}", "B002"));
        }

        if (request.Title.HasValue)
        {
            existingBook.Title = request.Title.Value;
        }

        if (request.Description.HasValue)
        {
            existingBook.Description = request.Description.Value;
        }

        await _repository.UpdateAsync(existingBook, cancellationToken);

        return new Payload<Book>(existingBook);
    }
}