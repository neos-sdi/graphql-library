namespace Library.Infrastructure.ExtendedTypes
{
    using HotChocolate.Types;

    using Library.Domain.Entities;

    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(x => x.Title).Use(next => async context =>
             {
                 await next(context);

                 if (context.Result is string t)
                 {
                     context.Result = t.ToUpperInvariant();
                 }
             });
        }
    }
}
