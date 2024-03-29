﻿namespace Library.Infrastructure.DataLoaders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using GreenDonut;

    using Library.Domain.Entities;

    using Microsoft.EntityFrameworkCore;

    public class AuthorByIdDataLoader : BatchDataLoader<Guid, Author>
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

            return dbContext.Authors
                .Where(s => keys.Contains(s.Id))
                .ToDictionary(t => t.Id);
        }
    }
}
