namespace Library.Infrastructure.DataLoaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenDonut;

    using Library.Application.Interfaces.Books;
    using Library.Domain.Entities;

    using Microsoft.EntityFrameworkCore;

    public class BookByIdDataLoader : BatchDataLoader<Guid, Book>, IBookByIdDataLoader
    {
        private readonly IDbContextFactory<LibraryDbContext> _dbContextFactory;


        public BookByIdDataLoader(
        IDbContextFactory<LibraryDbContext> dbContextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options)
        : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory ??
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Book>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
        {
            await using var dbContext =
                await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.Books
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
