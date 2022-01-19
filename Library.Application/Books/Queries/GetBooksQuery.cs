namespace Library.Application.Books.Queries
{
    using Library.Application.Interfaces;
    using Library.Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record GetBooksQuery(): IRequest<IQueryable<Book>>;

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IQueryable<Book>>
    {
        private readonly IBookRepository _repo;

        public GetBooksQueryHandler(IBookRepository repository)
        {
            _repo = repository;
        }

        public async Task<IQueryable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetBooks();
        }
    }
}
