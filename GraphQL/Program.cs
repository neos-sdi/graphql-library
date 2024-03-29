using GraphQL.Mutations;
using GraphQL.Queries;

using Library.Application;
using Library.Infrastructure;
using Library.Infrastructure.ExtendedTypes;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(p =>
{
    p.AddPolicy("cors", builder =>
    {
        builder.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});

ConfigureServices(builder.Services);
var app = builder.Build();
app.UseCors("cors");
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();

    //app.UseVoyager("/graphql", "/graphql-voyager");

    endpoints.MapGet("/", context =>
    {
        context.Response.Redirect("/graphql", true);
        return Task.CompletedTask;
    });
});

app.Run();

void ConfigureServices(IServiceCollection services)
{
    var connectionString = "server=localhost;user=sa;pwd=P@ssword;database=Library";
    services.AddPooledDbContextFactory<LibraryDbContext>(options => options.UseSqlServer(connectionString));

    services.AddApplication();
    services.AddInfrastructure();

    services.AddGraphQLServer()
            .AddSorting()
            .AddQueryType()
            .AddMutationType()
            .AddTypeExtension<BookQueries>()
            .AddTypeExtension<BookMutations>()
            .AddTypeExtension<AuthorQueries>()
            .AddType<BookType>()
            .AddDataLoaders()
            .AddProjections()
            .AddFiltering();

}
