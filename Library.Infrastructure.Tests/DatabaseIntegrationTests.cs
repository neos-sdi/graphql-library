namespace Library.Infrastructure.Tests
{
    using Library.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DatabaseIntegrationTests
    {
        private LibraryDbContext _context = default!;
        private readonly string _connectionString = "server=localhost;user=sa;pwd=P@ssword;database=Library";
        [SetUp]
        public void SetUp()
        {
            var optionsBuilder = new DbContextOptionsBuilder<LibraryDbContext>();

            optionsBuilder.UseSqlServer(_connectionString);
            this._context = new LibraryDbContext(optionsBuilder.Options);
        }
        [Test]
        public void ShouldInsertAuthor()
        {
            var firstAuthorGuid = Guid.NewGuid();
            var secondAuthorGuid = Guid.NewGuid();
            var firstBookId = Guid.NewGuid();
            var secondBookId = Guid.NewGuid();

            var author1 = new Author
            {
                Id = firstAuthorGuid,
                FirstName = "Prénom 1",
                LastName = "Nom 1"
            };

            var author2 = new Author
            {
                Id = secondAuthorGuid,
                FirstName = "Prénom 2",
                LastName = "Nom 2"
            };

            var book1 = new Book
            {
                Id = firstBookId,
                Title = "Book 1",
                Authors = new List<Author> { author1, author2 }
            };

            var book2 = new Book
            {
                Id = secondBookId,
                Title = "Book 2",
                Authors = new List<Author> { author1 }
            };

            this._context.Authors.Add(author1);
            this._context.Authors.Add(author2);
            this._context.Books.Add(book1);
            this._context.Books.Add(book2);

            this._context.SaveChanges();


        }
    }
}
