namespace Library.Application.Authors.Queries
{
    using System.Linq;
    using System.Threading.Tasks;

    using Library.Application.Interfaces;
    using Library.Domain.Entities;

    using MediatR;

    public record GetAuthorsQuery() : IRequest<IQueryable<Author>>;

    public class GetBooksQueryHandler : IRequestHandler<GetAuthorsQuery, IQueryable<Author>>
    {
        private readonly IRepository<Author> _repo;

        public GetBooksQueryHandler(IRepository<Author> repository)
        {
            _repo = repository;
        }

        public Task<IQueryable<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.GetAllAsync());
        }
    }
}
