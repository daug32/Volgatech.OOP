using System.Text;

namespace RendererApplication.Extensions;

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