namespace Library.Infrastructure
{
    using Library.Application.Interfaces;
    using Library.Infrastructure.Repositories;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IBookRepository>(service => new BookRepository(
                service.GetRequiredService<IDbContextFactory<LibraryDbContext>>().CreateDbContext()));
            return services;
        }
    }
}
