namespace Library.Infrastructure.Repositories
{
    using Library.Application.Interfaces;
    using Library.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class BookRepository : IBookRepository, IAsyncDisposable
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context= context;
        }

        public ValueTask DisposeAsync()
        {
            Console.WriteLine("Disposed");
            return _context.DisposeAsync();
        }

        public Task<IQueryable<Book>> GetBooks()
        {
            return Task.FromResult(_context.Books.AsQueryable());
        }
    }
}
