namespace Library.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Publisher
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Book> PublishedBooks { get; set; } = new List<Book>();
    }
}
