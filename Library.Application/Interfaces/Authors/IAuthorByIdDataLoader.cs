namespace Library.Application.Interfaces.Authors
{
    using System;

    using GreenDonut;

    using Library.Domain.Entities;

    public interface IAuthorByIdDataLoader : IDataLoader<Guid, Author>
    {
    }
}
