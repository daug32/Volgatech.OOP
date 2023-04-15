using System.Text;

namespace Lab2.HtmlDecode;

public class HtmlDecoder
{
    private readonly string _exitCode;

    private readonly Dictionary<string, string> _encodedHtmlSymbols = new()
    {
        { "&quot;", "\"" },
        { "&apos;", "\'" },
        { "&lt;", "<" },
        { "&gt;", ">" },
        { "&amp;", "&" }
    };

    private const string EncodingEndSymbol = ";";
    private const string EncodingStartSymbol = "&";

    public HtmlDecoder( string exitCode = "!q" )
    {
        _exitCode = exitCode;
    }

    /// <summary>Read the text to the end or before entering the exit code</summary>
    public void Decode( TextReader reader, TextWriter writer )
    {
        var builder = new StringBuilder();

        string? line = reader.ReadLine();
        bool isEnd = line != null && line != _exitCode;

        while ( isEnd )
        {
            builder.Append( Decode( line ) );
            line = reader.ReadLine();

            isEnd = line != null && line != _exitCode;
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

    public string Decode( string line )
    {
        var builder = new StringBuilder();

        var endIndex = 0;
        var startIndex = 0;

        while ( endIndex < line.Length )
        {
            startIndex = GetIndexOfLastOccurrence( line, EncodingStartSymbol, endIndex );
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

            endIndex = line.IndexOf( EncodingEndSymbol, startIndex, StringComparison.Ordinal );
            if ( endIndex < 0 )
            {
                builder.Append( line.Substring( startIndex ) );
                return builder.ToString();
            }

            string code = line.Substring( startIndex, endIndex - startIndex + 1 );
            builder.Append( GetDecodedSymbol( code ) );

            endIndex++;
        }

        return builder.ToString();
    }

    private string GetDecodedSymbol( string code )
    {
        return _encodedHtmlSymbols.TryGetValue( code, out string result )
            ? result
            : code;
    }

    private int GetIndexOfLastOccurrence( string line, string targetOccurrence, int startIndex )
    {
        int index = line.IndexOf( targetOccurrence, startIndex, StringComparison.Ordinal );
        if ( index < 0 )
        {
            return index;
        }
        
        while ( index < line.Length )
        {
            bool startsWith = line
                .Substring( index )
                .StartsWith( targetOccurrence );
            if ( !startsWith )
            {
                return index - 1;
            }

            index += targetOccurrence.Length;
        }

        return startIndex;
    }
}