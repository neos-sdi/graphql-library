namespace Library.Application.Interfaces.Series;
using System;

using GreenDonut;

using Library.Domain.Entities;

public interface ISerieByIdDataLoader : IDataLoader<Guid, Serie>
{
}
