namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Serie
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }

        public ICollection<Book> SeriesBooks { get; set; } = new List<Book>();
    }
}
