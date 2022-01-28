namespace Library.Infrastructure.ExtendedTypes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using HotChocolate;
    using HotChocolate.Types;

    using Library.Application.Interfaces.Authors;
    using Library.Domain.Entities;

    using Microsoft.EntityFrameworkCore;

    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(b => b.Authors)
                .ResolveWith<AuthorsResolver>(r => r.GetAuthorsAsync(default!, default!, default!))
                .UseDbContext<LibraryDbContext>();


        }

        private class AuthorsResolver
        {
            public async Task<IEnumerable<Author>> GetAuthorsAsync(
                [Parent] Book book,
                [ScopedService] LibraryDbContext context,
                IAuthorByIdDataLoader dataLoader)
            {
                var ids = await context.Books.Where(b => b.Id == book.Id).SelectMany(b => b.Authors.Select(a => a.Id)).ToListAsync();

                return await dataLoader.LoadAsync(ids);
            }
        }
    }
}
