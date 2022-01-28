namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Language : IEntity
    {
        public Guid Id { get; set; }
        public string? Label { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
