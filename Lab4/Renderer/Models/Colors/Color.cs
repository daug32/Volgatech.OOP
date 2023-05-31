using System.Globalization;

namespace Renderer.Colors;

public class Color
{
    public int Code { get; }

    private Color( int code )
    {
        Code = code;
    }

    private Color( char symbol )
    {
        Code = symbol;
    }

    public static Color FromHex( string hex )
    {
        if ( !Int32.TryParse(
                hex,
                NumberStyles.HexNumber,
                null,
                out int result ) )
        {
            throw new ArgumentException( $"Can't parse {hex}. It is not a number" );
        }

        return new Color( result );
    }

    public static Color FromSymbol( char symbol )
    {
        return new Color( symbol );
    }

    public static Color FromInt( int code )
    {
        return new Color( code );
    }

    public override string ToString()
    {
        return Code.ToString();
    }
}