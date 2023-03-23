using System.Globalization;

namespace Lab2.VectorParser;

public static class ListParserUtil
{
    /// <exception cref="ArgumentException">Throws if line is not in correct format</exception>
    public static List<double> ParseListFromLine( string line )
    {
        try
        {
            return line
                .Split( " ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries )
                .Select( str => Double.Parse( str, CultureInfo.InvariantCulture ) )
                .ToList();
        }
        catch ( Exception ex )
        {
            throw new ArgumentException( $"Can't parse line. Line: {line}\nMessage: {ex.Message}" );
        }
    }
}