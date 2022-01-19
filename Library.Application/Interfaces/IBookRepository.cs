namespace Library.Application.Interfaces
{
    using Library.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IBookRepository
    {
        Task<IQueryable<Book>> GetBooks();

    }
}
