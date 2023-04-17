using Dictionary.Services;

namespace Dictionary.Repositories.Implementation;

public class FileRepository<T> : IRepository<T>
    where T : class
{
    private readonly ISerializer<T> _serializer;
    private readonly string _source;

    public FileRepository(
        string source,
        ISerializer<T> serializer )
    {
        _serializer = serializer;
        _source = source;
    }

    public bool HasChanges { get; private set; }

    public List<T> GetAll()
    {
        var entities = new List<T>();

        using var reader = new StreamReader( _source );

        while ( !reader.EndOfStream )
        {
            T entity = _serializer.Deserialize( reader.ReadLine()! );
            entities.Add( entity );
        }

        return entities;
    }

    public T? GetBy( Func<T, bool> predicate )
    {
        using var reader = new StreamReader( _source );

        while ( !reader.EndOfStream )
        {
            T entity = _serializer.Deserialize( reader.ReadLine()! );
            if ( predicate( entity ) )
            {
                return entity;
            }
        }

        return null;
    }

    public void Add( T entity )
    {
        using var writer = new StreamWriter( _source, true );
        Add( entity, writer );
    }

    public void Add( List<T> entities )
    {
        using var writer = new StreamWriter( _source, true );

        foreach ( T entity in entities )
        {
            Add( entity, writer );
        }
    }

    public void Clear()
    {
        HasChanges = false;
        File.Delete( _source );
    }

    private void Add( T entity, StreamWriter writer )
    {
        HasChanges = true;
        writer.WriteLine( _serializer.Serialize( entity ) );
    }
}