namespace Library.Application.Interfaces.Books;

using Library.Domain.Entities;

using System;
using System.Threading.Tasks;

public interface IBookRepository : IRepository<Book>
{
    new Task<Guid> RemoveAsync(Guid id, CancellationToken cancellationToken);
}
