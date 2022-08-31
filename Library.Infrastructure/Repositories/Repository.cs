namespace Library.Infrastructure.Repositories;
using Library.Application.Interfaces;
using Library.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq;
using System.Threading.Tasks;

public class Repository<T> : IAsyncDisposable, IRepository<T> where T : class, IEntity
{
    protected readonly LibraryDbContext _context;

    public Repository(LibraryDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.AddAsync<T>(entity);
        await _context.SaveChangesAsync();
    }

    public ValueTask DisposeAsync()
    {
        return _context.DisposeAsync();
    }

    public async Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.FindAsync<T>(id);
    }

    public IQueryable<T> GetAllAsync()
    {
        return _context.Set<T>().AsNoTracking();
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Update<T>(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<Guid> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var existing = await FindByIdAsync(id, cancellationToken);
        if (existing == null)
        {
            return Guid.Empty;
        }
        _context.Remove(existing);
        await _context.SaveChangesAsync(cancellationToken);
        return id;
    }
}
