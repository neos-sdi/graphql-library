namespace Library.Application.Interfaces.Languages;
using System;

using GreenDonut;

using Library.Domain.Entities;

public interface ILanguageByIdLoader : IDataLoader<Guid, Language>
{
}
