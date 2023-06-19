namespace MyListTask;

internal class Node<T>
{
    public T Data { get; set; }
    public Node<T>? Prev { get; set; }
    public Node<T>? Next { get; set; }

    public Node( 
        T data,
        Node<T> prev = null,
        Node<T> next = null )
    {
        Data = data;
        Prev = prev;
        Next = next;
    }
}