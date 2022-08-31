namespace Library.Application.Books.Queries
{
    using System.Linq;
    using System.Threading.Tasks;

    using Library.Application.Interfaces;
    using Library.Domain.Entities;

    using MediatR;

    public record GetBooksQuery() : IRequest<IQueryable<Book>>;

    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IQueryable<Book>>
    {
        private readonly IRepository<Book> _repo;

        public GetBooksQueryHandler(IRepository<Book> repository)
        {
            _repo = repository;
        }

        public Task<IQueryable<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.GetAllAsync());
        }
    }
}
