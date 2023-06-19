using HttpUrlTask.Utils;

namespace HttpUrlTask.Models;

public class HttpUrl
{
    public string Url => $"{Protocol.ToString().ToLower()}://{Domain}:{Port}{Document}";

    public readonly Protocol Protocol;
    public readonly int Port;
    public readonly string Domain;
    public readonly string Document;

    public static HttpUrl Create( string url )
    {
        return HttpUrlParser.Parse( url );
    }

    public static HttpUrl Create(
        Protocol protocol,
        string domain,
        int port,
        string document )
    {
        HttpUrlValidator.ValidateProtocolOrThrow( protocol );
        HttpUrlValidator.ValidateDomainOrThrow( domain );
        HttpUrlValidator.ValidatePortOrThrow( port );
        HttpUrlValidator.ValidateDocumentOrThrow( document );
        
        return new HttpUrl(
            protocol,
            domain,
            port,
            document );
    }

    internal HttpUrl(
        Protocol protocol,
        string domain,
        int port,
        string document )
    {
        Protocol = protocol;
        Domain = domain;
        Port = port;
        Document = document;
    }
}