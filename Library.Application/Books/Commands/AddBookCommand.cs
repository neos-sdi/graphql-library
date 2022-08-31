namespace Library.Application.Books.Commands;

using Library.Application.Interfaces;
using Library.Domain.Common;
using Library.Domain.Entities;
using Library.Domain.Errors;

using MediatR;

using System;
using System.Threading;
using System.Threading.Tasks;

public record AddBookCommand(string Title, string? Description) : IRequest<Payload<Book>>;

public class AddBookCommandHandler : IRequestHandler<AddBookCommand, Payload<Book>>
{

    private readonly IRepository<Book> bookRepository;

    public AddBookCommandHandler(IRepository<Book> bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    public Task<Payload<Book>> Handle(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (request is null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return HandleInternal(request, cancellationToken);
    }

    public async Task<Payload<Book>> HandleInternal(AddBookCommand request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Title))
        {
            return new Payload<Book>(new UserError("A book must have a title.", (int)BookErrors.MustHaveTitle));
        }

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description
        };

        await bookRepository.AddAsync(book, cancellationToken);

        return new Payload<Book>(book);
    }
}
