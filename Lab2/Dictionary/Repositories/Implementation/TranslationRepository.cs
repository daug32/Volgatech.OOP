using Dictionary.Models;

namespace Dictionary.Repositories.Implementation;

public class TranslationRepository : ITranslationRepository
{
    private readonly IRepository<Translation> _cacheRepository;
    private readonly IRepository<Translation> _databaseRepository;

    public TranslationRepository(
        IRepository<Translation> cacheRepository,
        IRepository<Translation> databaseRepository )
    {
        _cacheRepository = cacheRepository;
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
        return _cacheRepository
            .GetAll()
            .Union( _databaseRepository.GetAll() )
            .ToList();
    }

    public Translation? GetBy( Func<Translation, bool> predicate )
    {
        return _cacheRepository.GetBy( predicate ) ??
               _databaseRepository.GetBy( predicate );
    }

    public void Add( Translation entity )
    {
        HasChanges = true;
        _cacheRepository.Add( entity );
    }

    public void Add( List<Translation> entities )
    {
        HasChanges = true;
        _cacheRepository.Add( entities );
    }

    public void Commit()
    {
        foreach ( Translation translation in _cacheRepository.GetAll() )
        {
            _databaseRepository.Add( translation );
        }
        
        HasChanges = false;
        _cacheRepository.Clear();
    }

    public void Clear()
    {
        HasChanges = false;
        _cacheRepository.Clear();
        _databaseRepository.Clear();
    }
}