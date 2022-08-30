namespace Library.Application.Books.Queries
{
    using HotChocolate.Types.Relay;

    using Library.Application.Interfaces;
    using Library.Application.Interfaces.Books;
    using Library.Domain.Entities;

    using MediatR;

    using System;
    using System.Threading.Tasks;

    public record GetBookByIdQuery([ID(nameof(Book))] Guid Id) : IRequest<Book>;

    public class GetSpeakerByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly IBookByIdDataLoader _dataLoader;
        private readonly IRepository<Book> _repository;

        public GetSpeakerByIdQueryHandler(IRepository<Book> repository, IBookByIdDataLoader dataLoader) //
        {
            _dataLoader = dataLoader;
            _repository = repository;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            //return await _repository.FindByIdAsync(request.Id, cancellationToken);
            return await _dataLoader.LoadAsync(request.Id, cancellationToken);
        }
    }
}
