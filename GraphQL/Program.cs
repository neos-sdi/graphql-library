using GraphQL.Mutations;
using GraphQL.Queries;
using Library.Application.Books.Commands;
using Library.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services);
var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();

    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/graphql", true);
        return Task.CompletedTask;
    });
});

app.Run();

void ConfigureServices(IServiceCollection services)
{
    string connectionString = "server=localhost;user=sa;pwd=P@ssword;database=Library";
    //services.AddPooledDbContextFactory<LibraryDbContext>(options => options.UseSqlServer(connectionString));
    services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));

    services.AddGraphQLServer()
            .AddSorting()
            .AddQueryType()
            .AddMutationType()
            .AddTypeExtension<BookQueries>()
            .AddTypeExtension<BookMutations>()
            ;

}
