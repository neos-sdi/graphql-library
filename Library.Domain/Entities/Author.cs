namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Author : IEntity
    {
        public Guid Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public ICollection<Book> WrittenBooks { get; set; } = new List<Book>();

        //public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
