using System.Collections;

namespace MyListTask;

public class MyList<T> : IMyList<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public int Count { get; private set; }

    public IMyList<T> Copy()
    {
        var result = new MyList<T>();

        foreach ( T item in this )
        {
            result.Add( item );
        }

        return result;
    }

    public void Add( T item )
    {
        InsertLast( item );
    }

    public void InsertFirst( T item )
    {
        var newNode = new Node<T>( item );
        Count++;

        if ( _head == null )
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        newNode.Next = _head;
        _head.Prev = newNode;
        _head = newNode;
    }

    public void InsertLast( T item )
    {
        var newNode = new Node<T>( item );
        Count++;

        if ( _head == null )
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        newNode.Prev = _tail;
        _tail!.Next = newNode;
        _tail = newNode;
    }

    public void Insert( int index, T item )
    {
        if ( index == 0 )
        {
            InsertFirst( item );
            return;
        }

        if ( index == Count )
        {
            InsertLast( item );
            return;
        }
        
        ValidateIndexOrThrow( index );

        Node<T> current = GetNodeByIndex( index );
        var newNode = new Node<T>( item );
        
        // Update previous element
        current.Prev!.Next = newNode;
        newNode.Prev = current.Prev;
        
        // Update next element 
        current.Prev = newNode;
        newNode.Next = current;

        Count++;
    }

    public void RemoveLast()
    {
        _tail = _tail!.Prev;
        if ( _tail != null )
        {
            _tail.Next = null;
        }

        Count--;
    }

    public void RemoveFirst()
    {
        _head = _head?.Next;
        if ( _head != null )
        {
            _head.Prev = null;
        }

        Count--;
    }

    public void RemoveAt( int index )
    {
        ValidateIndexOrThrow( index );

        if ( index == 0 )
        {
            RemoveFirst();
            return;
        }

        if ( index == Count - 1 )
        {
            RemoveLast();
            return;
        }

        Node<T> current = GetNodeByIndex( index );
        current.Prev!.Next = current.Next;
        current.Next!.Prev = current.Prev;
        Count--;
    }

    public T this[ int index ]
    {
        get => GetNodeByIndex( index ).Data;
        set => GetNodeByIndex( index ).Data = value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = _head;
        while ( current != null )
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private Node<T> GetNodeByIndex( int index )
    {
        ValidateIndexOrThrow( index );

        Node<T> current;
        // This block is used to optimize iteration over list
        // If index is more near to the start, then iterate from the start
        // If index is more near to the end, then iterate from the end
        if ( index < ( float )Count / 2 )
        {
            current = _head!;
            var currentIndex = 0;

            while ( currentIndex != index )
            {
                current = current!.Next!;
                currentIndex++;
            }
        }
        else
        {
            current = _tail!;
            int currentIndex = Count - 1;

            while ( currentIndex != index )
            {
                current = current!.Prev!;
                currentIndex--;
            }
        }

        return current;
    }

    private void ValidateIndexOrThrow( int index )
    {
        if ( index < 0 || index >= Count )
        {
            throw new ArgumentOutOfRangeException( nameof( index ) );
        }
    }
}