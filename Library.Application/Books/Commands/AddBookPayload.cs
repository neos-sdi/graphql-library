namespace Library.Application.Books.Commands
{
    using Library.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AddBookPayload
    {
        public Book Book { get;private  set; }

        public AddBookPayload(Book book)
        {
            Book = book;
        }
    }
}
