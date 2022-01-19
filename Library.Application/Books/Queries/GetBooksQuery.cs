namespace Library.Application.Books.Queries
{
    using Library.Domain.Entities;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record GetBooksQuery(): IRequest<IQueryable<Book>>;

    //public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, IQueryable<Book>>
    //{
    //    private readonly ISpeakerRepository _repository;

    //    public GetSpeakersQueryHandler(ISpeakerRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    public async Task<IQueryable<Speaker>> Handle(GetSpeakersQuery request, CancellationToken cancellationToken)
    //    {
    //        return _repository.GetAllSpeakers()
    //            .OrderBy(t => t.Name);
    //    }
    //}
}
