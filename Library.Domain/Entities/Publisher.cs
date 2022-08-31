namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Publisher : IEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Book> PublishedBooks { get; set; } = new List<Book>();
    }
}
