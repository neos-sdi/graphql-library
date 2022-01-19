namespace Library.Infrastructure.Extensions
{
    using HotChocolate.Types;
    using HotChocolate.Types.Descriptors;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;

    public class UseLibraryDbAttribute : UseDbContextAttribute
    {
        public UseLibraryDbAttribute([CallerLineNumber] int order = 0)
            :base(typeof(LibraryDbContext))
        {
            Order = order;
        }
    }
}
