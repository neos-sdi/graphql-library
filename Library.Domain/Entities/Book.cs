namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;

    public class Book : IEntity
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? SerieId { get; set; }
        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public Language? Language { get; set; }
        public Publisher? Publisher { get; set; }
        public Serie? Serie { get; set; }

        //public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
