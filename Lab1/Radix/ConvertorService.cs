namespace Lab1.Radix;

public class ConvertorService
{
    public const string AllowedDigits = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    public const char Minus = '-';

    public static bool IsNotationSupported( int notation ) => notation >= 2 && notation <= 36;

    public static bool CanCovert( string value ) => value.All( IsSymbolSupported );

    public static bool IsSymbolSupported( char symbol ) => AllowedDigits.Contains( symbol ) || symbol == Minus;

    public static string Convert( int sourceNotation, int destinationNotation, string value )
    {
        int dec = ToDecimal( sourceNotation, value );
        return ToNotation( destinationNotation, dec );
    }

    private static int ToDecimal( int notation, string value )
    {
        int result = 0;

        int startIndex = 0;
        int mulitpier = 1;
        if ( value.StartsWith( Minus ) )
        {
            startIndex = 1;
            mulitpier = -1;
        }

        for (int i = value.Length - 1; i >= startIndex; i-- )
        {
            char symbol = value[ i ];
            result += mulitpier * AllowedDigits.IndexOf( symbol );
            mulitpier *= notation;
        }

        return result;
    }

    private static string ToNotation( int notation, int value )
    {
        bool isNegative = value < 0;
        var result = new List<char>();

        while (value != 0 )
        {
            int a = Math.Abs( value % notation );
            result.Add( AllowedDigits[ a ] );
            value /= notation;
        }

        if ( isNegative )
        {
            result.Add( Minus );
        }

        result.Reverse();

        return String.Join( "", result );
    }
}
