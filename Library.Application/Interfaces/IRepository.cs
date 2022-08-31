namespace Library.Application.Interfaces;
using Library.Domain.Entities;

using System;
using System.Linq;
using System.Threading.Tasks;

public interface IRepository<T> where T : class, IEntity
{
    IQueryable<T> GetAllAsync();

    Task AddAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<Guid> RemoveAsync(Guid id, CancellationToken cancellationToken);
}
