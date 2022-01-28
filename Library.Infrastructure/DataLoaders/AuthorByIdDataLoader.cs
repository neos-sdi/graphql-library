namespace Library.Infrastructure.DataLoaders
{
    using GreenDonut;
    using Library.Application.Interfaces.Authors;
    using Library.Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AuthorByIdDataLoader : BatchDataLoader<Guid, Author>, IAuthorByIdDataLoader
    {
        private readonly IDbContextFactory<LibraryDbContext> _dbContextFactory;

        public AuthorByIdDataLoader(
        IDbContextFactory<LibraryDbContext> dbContextFactory,
        IBatchScheduler batchScheduler,
        DataLoaderOptions options)
        : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory ??
                                throw new ArgumentNullException(nameof(dbContextFactory));
        }

        protected override async Task<IReadOnlyDictionary<Guid, Author>> LoadBatchAsync(
        IReadOnlyList<Guid> keys,
        CancellationToken cancellationToken)
        {
            await using var dbContext =
                await _dbContextFactory.CreateDbContextAsync(cancellationToken);

            return await dbContext.Authors
                .Where(s => keys.Contains(s.Id))
                .ToDictionaryAsync(t => t.Id, cancellationToken);
        }
    }
}
