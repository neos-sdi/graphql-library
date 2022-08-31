namespace Library.Application.Interfaces.Books
{
    using GreenDonut;
    using Library.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBookByIdDataLoader : IDataLoader<Guid, Book>
    {
    }
}
