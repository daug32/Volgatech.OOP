using Dictionary.Models;

namespace Dictionary.Repositories;

public interface ITranslationRepository : IRepository<Translation>
{
    Translation? GetByEnglishPhrase( string englishPhrase );
    void Commit();
}