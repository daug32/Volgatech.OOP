namespace MyListTask;

public interface IMyList<T> : IEnumerable<T>
{
    int Count { get; }
    
    void Add( T item );
    void InsertFirst( T item );
    void InsertLast( T item );
    void Insert( int index, T item );

    void RemoveLast();
    void RemoveFirst();
    void RemoveAt( int index );

    IMyList<T> Copy();
    
    T this[ int i ] { get; set; }
}