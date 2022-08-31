namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Serie : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Book> SeriesBooks { get; set; } = new List<Book>();
    }
}
