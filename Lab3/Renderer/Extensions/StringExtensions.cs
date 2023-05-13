using System.Text;

namespace Renderer.Extensions;

public static class StringExtensions
{
    public static string ReplaceAt( this string source, int index, char symbol )
    {
        var builder = new StringBuilder( source );

        builder.Remove( index, 1 );
        builder.Insert( index, symbol );

        return builder.ToString();
    }
}