using System.Text;

namespace Lab2.HtmlDecode;

public static class HtmlDecoder
{
    public static string ExitCode = "!q";

    private static readonly Dictionary<string, string> _encodedHtmlSymbols = new()
    {
        { "&quot;", "\"" },
        { "&apos;", "\'" },
        { "&lt;", "<" },
        { "&gt;", ">" },
        { "&amp;", "&" }
    };

    private static readonly string _encodingEndSymbol = ";";
    private static readonly string _encodingStartSymbol = "&";

    /// <summary>Read the text to the end or before entering the exit code</summary>
    public static void DecodeFile( TextReader reader, TextWriter writer )
    {
        var builder = new StringBuilder();

        string? line = reader.ReadLine();
        bool isEnd = line != null && line != ExitCode;

        while ( isEnd )
        {
            builder.Append( Decode( line ) );
            line = reader.ReadLine();

            isEnd = line != null && line != ExitCode;
            
            if ( isEnd )
            {
                builder.Append( Environment.NewLine );
            }
        }

        if ( builder.Length > 0 )
        {
            writer.Write( builder.ToString() );
        }
    }

    public static string Decode( string line )
    {
        var builder = new StringBuilder();

        var endIndex = 0;
        var startIndex = 0;

        while ( endIndex < line.Length )
        {
            startIndex = line.IndexOf( _encodingStartSymbol, endIndex, StringComparison.Ordinal );
            if ( startIndex < 0 )
            {
                builder.Append( line.Substring( endIndex ) );
                return builder.ToString();
            }

            int length = startIndex - endIndex;
            if ( length > 0 )
            {
                builder.Append( line.Substring( endIndex, startIndex - endIndex ) );
            }

            endIndex = line.IndexOf( _encodingEndSymbol, startIndex, StringComparison.Ordinal );
            if ( endIndex < 0 )
            {
                builder.Append( line.Substring( startIndex ) );
                return builder.ToString();
            }

            string code = line.Substring( startIndex, endIndex - startIndex + 1 );
            builder.Append( _encodedHtmlSymbols[code] );

            endIndex++;
        }

        return builder.ToString();
    }
}