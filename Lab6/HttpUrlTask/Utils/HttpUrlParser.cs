using System.Text;
using System.Text.RegularExpressions;
using HttpUrlTask.Models;

namespace HttpUrlTask.Utils;

public class HttpUrlParser
{
    public const string ProtocolRegex = @"((?<protocol>\w+[\w\d\.\+\-]*):\/\/)";
    public const string DomainRegex = @"(?<domain>[\w\.]+[^\/\.\:])";
    public const string PortRegex = @"(?<port>[0-9]{1,16})";
    public const string DocumentRegex = @"(?<document>\/([\w]+\.{0,1}[\w]*)*){0,}";

    public const string UrlRegex = $"^{ProtocolRegex}{{0,1}}{DomainRegex}(\\:{PortRegex}){{0,1}}{DocumentRegex}$";

    public static HttpUrl Parse( string url )
    {
        Match regexMatch = Regex.Match( url, UrlRegex );
        if ( !regexMatch.Success )
        {
            throw new UrlParsingException( url );
        }

        Protocol protocol = ParseProtocol( regexMatch.Groups["protocol"], url );
        string domain = ParseDomain( regexMatch.Groups["domain"], url );
        int port = ParsePort( regexMatch.Groups["port"], protocol );
        string document = ParseDocument( regexMatch.Groups["document"] );

        return new HttpUrl(
            protocol,
            domain,
            port,
            document );
    }

    private static Protocol ParseProtocol( Group protocolGroup, string url )
    {
        if ( !protocolGroup.Success )
        {
            return Protocol.Http;
        }

        string protocolString = protocolGroup.Value;

        if ( !Enum.TryParse( protocolString, true, out Protocol protocol ) )
        {
            throw new UrlParsingException( url );
        }

        return protocol;
    }

    private static string ParseDomain( Group domainGroup, string url )
    {
        return domainGroup.Success
            ? domainGroup.Value
            : throw new UrlParsingException( url );
    }

    private static int ParsePort( Group portGroup, Protocol protocol )
    {
        return portGroup.Success
            ? Int16.Parse( portGroup.Value )
            : ( int )protocol;
    }

    private static string ParseDocument( Group documentGroup )
    {
        if ( !documentGroup.Success )
        {
            return "";
        }

        var result = new StringBuilder();
        for ( var i = 0; i < documentGroup.Captures.Count; i++ )
        {
            result.Append( documentGroup.Captures[i] );
        }

        return result.ToString();
    }
}