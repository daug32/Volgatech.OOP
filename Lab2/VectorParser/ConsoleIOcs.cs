using System.Globalization;

namespace Lab2.VectorParser;

public static class ConsoleIO
{
    public static void PrintException( Exception ex )
    {
        Console.WriteLine( ex.Message );
    }
    
    public static List<double> ReadNumbers()
    {
        string line = Console.ReadLine()!;
        return ListParserUtil.ParseListFromLine( line );
    }
    
    public static void PrintNumbers( List<double> list )
    {
        foreach ( double value in list )
        {
            Console.Write( $"{value} ", CultureInfo.InvariantCulture );
        }
    }
}