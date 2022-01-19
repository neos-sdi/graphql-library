namespace GraphQL.Mutations
{
    using Library.Application.Books.Commands;
    using Library.Domain.Entities;
    using Library.Infrastructure;

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutations
    {
        public async Task<AddBookPayload> AddBookAsync(
        AddBookCommand input,
        [Service] LibraryDbContext context,
        CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = input.Title,
                Description = input.Description
            };

            context.Books.Add(book);
            await context.SaveChangesAsync();

            return new AddBookPayload(book);
        }
    }
}
