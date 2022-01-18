namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Book
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? LanguageId { get; set; }
        public Guid? PublisherId { get; set; }
        public Guid? SerieId { get; set; }
        public Author? Author { get; set; }
        public Language? Language { get; set; }
        public Publisher? Publisher { get; set; }
        public Serie? Serie { get; set; }
    }
}
