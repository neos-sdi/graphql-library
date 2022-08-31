namespace Library.Infrastructure.Repositories;

using Library.Application.Interfaces.Books;
using Library.Domain.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading;
using System.Threading.Tasks;

internal class BookRepository : Repository<Book>, IBookRepository
{
    public BookRepository(LibraryDbContext context) : base(context)
    {
    }

    public async override Task<Guid> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var existing = await _context.Books.Include(b => b.Authors).FirstOrDefaultAsync(b => b.Id == id);
        if (existing == null)
        {
            return Guid.Empty;
        }
        _context.Remove(existing);
        await _context.SaveChangesAsync(cancellationToken);
        return id;
    }
}
