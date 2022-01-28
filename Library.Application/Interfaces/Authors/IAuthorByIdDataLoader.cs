namespace Library.Application.Interfaces.Authors
{
    using GreenDonut;
    using Library.Domain.Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAuthorByIdDataLoader:IDataLoader<Guid, Author>
    {
    }
}
