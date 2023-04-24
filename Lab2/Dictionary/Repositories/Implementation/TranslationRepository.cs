using Dictionary.Models;

namespace Dictionary.Repositories.Implementation;

public class TranslationRepository : ITranslationRepository
{
    private readonly IRepository<Translation> _cashedTranslationsRepository;
    private readonly IRepository<Translation> _databaseRepository;

    public TranslationRepository(
        IRepository<Translation> cashedTranslationsRepository,
        IRepository<Translation> databaseRepository )
    {
        _cashedTranslationsRepository = cashedTranslationsRepository;
        _databaseRepository = databaseRepository;
    }

    public bool HasChanges { get; private set; }

    public Translation? GetByEnglishPhrase( string englishPhrase )
    {
        return GetBy(
            translation =>
                String.Equals(
                    translation.EnglishPhrase,
                    englishPhrase,
                    StringComparison.OrdinalIgnoreCase ) );
    }

    public List<Translation> GetAll()
    {
        return _cashedTranslationsRepository
            .GetAll()
            .Union( _databaseRepository.GetAll() )
            .ToList();
    }

    public Translation? GetBy( Func<Translation, bool> predicate )
    {
        return _cashedTranslationsRepository.GetBy( predicate ) ??
               _databaseRepository.GetBy( predicate );
    }

    public void Add( Translation entity )
    {
        HasChanges = true;
        _cashedTranslationsRepository.Add( entity );
    }

    public void Add( List<Translation> entities )
    {
        HasChanges = true;
        _cashedTranslationsRepository.Add( entities );
    }

    public void Commit()
    {
        foreach ( Translation translation in _cashedTranslationsRepository.GetAll() )
        {
            _databaseRepository.Add( translation );
        }
        
        HasChanges = false;
        _cashedTranslationsRepository.Clear();
    }

    public void Clear()
    {
        HasChanges = false;
        _cashedTranslationsRepository.Clear();
        _databaseRepository.Clear();
    }
}