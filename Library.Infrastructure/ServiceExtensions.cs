namespace Library.Infrastructure
{
    using HotChocolate.Execution.Configuration;

    using Library.Application.Interfaces;
    using Library.Application.Interfaces.Authors;
    using Library.Application.Interfaces.Books;
    using Library.Domain.Entities;
    using Library.Infrastructure.DataLoaders;
    using Library.Infrastructure.Repositories;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IRepository<Book>>(service => new Repository<Book>(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));

            services.AddTransient<IRepository<Author>>(service => new Repository<Author>(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));

            services.AddTransient<IRepository<Language>>(service => new Repository<Language>(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));

            services.AddTransient<IRepository<Publisher>>(service => new Repository<Publisher>(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));

            services.AddTransient<IRepository<Serie>>(service => new Repository<Serie>(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));

            return services;
        }

        public static IRequestExecutorBuilder AddDataLoaders(this IRequestExecutorBuilder builder)
        {
            builder.AddDataLoader<IBookByIdDataLoader, BookByIdDataLoader>();
            builder.AddDataLoader<IAuthorByIdDataLoader, AuthorByIdDataLoader>();

            return builder;
        }
    }
}
