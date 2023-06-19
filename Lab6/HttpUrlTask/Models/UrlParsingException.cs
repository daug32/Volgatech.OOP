namespace HttpUrlTask.Models;

public class UrlParsingException : Exception
{
    public UrlParsingException( string url )
        : base( $"An error occured while parsing url. Url: {url}" )
    {}
}