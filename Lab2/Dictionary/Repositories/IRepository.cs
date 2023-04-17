namespace Dictionary.Repositories;

public interface IRepository<T>
    where T : class
{
    bool HasChanges { get; }
    List<T> GetAll();
    T? GetBy( Func<T, bool> predicate );
    void Add( T entity );
    void Add( List<T> entities );
    void Clear();
}