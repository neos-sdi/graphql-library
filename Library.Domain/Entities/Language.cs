namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Language
    {
        public Guid Id { get; set; }
        public string? Label { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
