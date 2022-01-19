namespace Library.Application.Books.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public record AddBookCommand(string Title, string? Description);
    
}
