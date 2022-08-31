namespace Library.Application.Interfaces.Publishers;
using System;

using GreenDonut;

using Library.Domain.Entities;

public interface IPublisherByIdDataLoader : IDataLoader<Guid, Publisher>
{
}
