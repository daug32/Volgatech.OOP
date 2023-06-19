namespace MyListTask.Console;

public class Program
{
    public static void Main()
    {
        DemonstrateWorkWithNumbers();
        DemonstrateWorkWithStrings();
    }

    private static void DemonstrateWorkWithNumbers()
    {
        System.Console.WriteLine();
        System.Console.WriteLine( $"======= {nameof( DemonstrateWorkWithNumbers )} =======" );
        System.Console.WriteLine();
        
        var list = new MyList<int>
        {
            1, 2, 3, 4, 5, 6, 7, 8, 9
        };

        list.InsertFirst( 0 );
        list.InsertLast( 10 );
        list.Insert( 7, 7 );

        System.Console.WriteLine( $"Full int list:\n  {String.Join( ", ", list )}" );

        list[5] = 1000;
        System.Console.WriteLine( $"List after settings new value at 5th index:\n  {String.Join( ", ", list )}" );

        list.RemoveAt( 5 );
        System.Console.WriteLine( $"Items after remove element at 5th index:\n  {String.Join( ", ", list )}" );
    }

    private static void DemonstrateWorkWithStrings()
    {
        System.Console.WriteLine();
        System.Console.WriteLine( $"======= {nameof( DemonstrateWorkWithStrings )} =======" );
        System.Console.WriteLine();

        var list = new MyList<string>
        {
            "This is a demonstration"
        };

        list.InsertFirst( "Hello, world! " );
        list.InsertLast( " of MyList<string>" );

        System.Console.WriteLine( $"Full string list:\n  {String.Join( "", list )}" );

        list[1] = $"{list[1]}{list[2]}";
        list.RemoveAt( 2 );

        System.Console.WriteLine(
            $"String list after merging elements at 1st and 2nd indexes:\n  {String.Join( "", list )}" );
    }
}