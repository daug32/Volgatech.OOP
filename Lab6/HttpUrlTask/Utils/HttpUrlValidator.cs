using System.Text.RegularExpressions;
using HttpUrlTask.Models;

namespace HttpUrlTask.Utils;

public static class HttpUrlValidator
{
    public static void ValidateProtocolOrThrow( Protocol protocol )
    {
        if ( !Enum.IsDefined( protocol ) )
        {
            throw new ArgumentException( nameof( protocol ) );
        }
    }

    public static void ValidateDomainOrThrow( string domain )
    {
        if ( !Regex.IsMatch( domain, $"^{HttpUrlParser.DomainRegex}$" ) )
        {
            throw new ArgumentException( nameof( domain ) );
        }
    }

    public static void ValidateDocumentOrThrow( string document )
    {
        if ( !Regex.IsMatch( document, $"^{HttpUrlParser.DocumentRegex}$" ) )
        {
            throw new ArgumentException( nameof( document ) );
        }
    }

    public static void ValidatePortOrThrow( int port )
    {
        if ( port is < 0 or > ushort.MaxValue )
        {
            throw new ArgumentException( nameof( port ) );
        }
    }
}