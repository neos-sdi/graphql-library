namespace Library.Application.Books.Queries
{
    using HotChocolate.Types.Relay;
    using Library.Application.Interfaces.Books;
    using Library.Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record GetBookByIdQuery([ID(nameof(Book))] Guid Id) : IRequest<Book>;

    public class GetSpeakerByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookByIdDataLoader _dataLoader;

        public GetSpeakerByIdQueryHandler(IBookByIdDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            return await _dataLoader.LoadAsync(request.Id, cancellationToken);
        }
    }
}
