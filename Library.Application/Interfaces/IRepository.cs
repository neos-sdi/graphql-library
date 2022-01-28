namespace Library.Application.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

using Library.Domain.Entities;

public interface IRepository<T> where T : class, IEntity
{
    IQueryable<T> GetAllAsync();

    Task AddAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken);
}
