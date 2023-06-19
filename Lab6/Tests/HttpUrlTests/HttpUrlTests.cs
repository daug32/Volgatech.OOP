using HttpUrlTask.Models;
using NUnit.Framework;

namespace HttpUrlTests;

public class HttpUrlTests
{
    [TestCase( Protocol.Http, "test", 80, "" )]
    [TestCase( Protocol.Http, "test.com", 80, "" )]
    [TestCase( Protocol.Https, "test.com", 5000, "/" )]
    [TestCase( Protocol.Http, "test.subdomain.com", 80, "/" )]
    [TestCase( Protocol.Http, "test.subdomain.com", 80, "/some/index.html" )]
    [TestCase( Protocol.Http, "test.com", 80, "/index.html" )]
    public void CreateByParts_InputDataIsValid_DoesntThrows(
        Protocol protocol,
        string domain,
        int port,
        string document )
    {
        Assert.DoesNotThrow( () => HttpUrl.Create( protocol, domain, port,
            document ) );
    }
    
    [TestCase( 9, "test.com", 80, "" )]
    [TestCase( 1000, "test.com", 80, "" )]
    [TestCase( Protocol.Http, "test.com.", 80, "/" )]
    [TestCase( Protocol.Http, "test.com/", 80, "/" )]
    [TestCase( Protocol.Http, "test.com", 80, "some" )]
    [TestCase( Protocol.Http, "test.com", -1, "" )]
    [TestCase( Protocol.Http, "test.com", 100_000, "" )]
    public void CreateByParts_InputDataIsInvalid_ThrowsArgumentException(
        Protocol protocol,
        string domain,
        int port,
        string document )
    {
        Assert.Throws<ArgumentException>( () => HttpUrl.Create( protocol, domain, port,
            document ) );
    }
    
    
    [TestCase( 
        Protocol.Http, "test", 80, "",
        "http://test:80" )]
    [TestCase( 
        Protocol.Http, "test.com", 80, "",
        "http://test.com:80" )]
    [TestCase( 
        Protocol.Https, "test.com", 5000, "/",
        "https://test.com:5000/" )]
    [TestCase( 
        Protocol.Http, "test.subdomain.com", 80, "/",
        "http://test.subdomain.com:80/" )]
    [TestCase( 
        Protocol.Http, "test.subdomain.com", 80, "/some/index.html",
        "http://test.subdomain.com:80/some/index.html" )]
    [TestCase( 
        Protocol.Http, "test.com", 80, "/index.html",
        "http://test.com:80/index.html" )]
    public void GetUrl_ReturnsValidUrl(
        Protocol protocol,
        string domain,
        int port,
        string document,
        string expectedUrl )
    {
        // Arrange
        var httpUrl = HttpUrl.Create(
            protocol,
            domain,
            port,
            document );
        
        // Act
        string url = httpUrl.Url;
        
        // Assert
        Assert.AreEqual( expectedUrl, url );
    }
}