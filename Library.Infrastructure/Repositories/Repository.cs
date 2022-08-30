namespace Library.Infrastructure.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

using Library.Application.Interfaces;
using Library.Domain.Entities;

using Microsoft.EntityFrameworkCore;

public class Repository<T> : IAsyncDisposable, IRepository<T> where T : class, IEntity
{
    private readonly LibraryDbContext _context;

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
}
