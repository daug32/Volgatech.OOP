namespace Dictionary.Repositories.Implementation;

public class MemoryRepository<T> : IRepository<T>
    where T : class
{
    private readonly List<T> _entities;

    public MemoryRepository( List<T>? entities = null )
    {
        _entities = entities ?? new List<T>();
    }

    public bool HasChanges { get; private set; }

    public List<T> GetAll()
    {
        return _entities;
    }

    public T? GetBy( Func<T, bool> predicate )
    {
        return _entities.FirstOrDefault( predicate );
    }

    public void Add( T entity )
    {
        HasChanges = true;
        _entities.Add( entity );
    }

    public void Add( List<T> entities )
    {
        HasChanges = true;
        _entities.AddRange( entities );
    }

    public void Clear()
    {
        HasChanges = false;
        _entities.Clear();
    }
}