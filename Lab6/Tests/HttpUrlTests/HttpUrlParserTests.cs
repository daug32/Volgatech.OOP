using HttpUrlTask.Models;
using HttpUrlTask.Utils;
using NUnit.Framework;

namespace HttpUrlTests;

public class HttpUrlParserTests
{
    [TestCase(
        "http://test.subtest.com/some/some2/index.html",
        Protocol.Http, "test.subtest.com", 80, "/some/some2/index.html" )]
    [TestCase(
        "http://test.com/some/some2/index.html",
        Protocol.Http, "test.com", 80, "/some/some2/index.html" )]
    [TestCase(
        "http://test.com:5000/some/some2/index.html",
        Protocol.Http, "test.com", 5000, "/some/some2/index.html" )]
    [TestCase(
        "http://test.com/some/index.html",
        Protocol.Http, "test.com", 80, "/some/index.html" )]
    [TestCase(
        "http://test.com/index.html",
        Protocol.Http, "test.com", 80, "/index.html" )]
    [TestCase(
        "http://test.com",
        Protocol.Http, "test.com", 80, "" )]
    [TestCase(
        "http://test.com:8080",
        Protocol.Http, "test.com", 8080, "" )]
    [TestCase(
        "https://test.subtest.com/some/some2/index.html",
        Protocol.Https, "test.subtest.com", 443, "/some/some2/index.html" )]
    [TestCase(
        "some.test.com/some/some2/index.html",
        Protocol.Http, "some.test.com", 80, "/some/some2/index.html" )]
    [TestCase(
        "http://test.com/some",
        Protocol.Http, "test.com", 80, "/some" )]
    [TestCase(
        "https://to",
        Protocol.Https, "to", 443, "" )]
    [TestCase(
        "to",
        Protocol.Http, "to", 80, "" )]
    [TestCase(
        "test.com/",
        Protocol.Http, "test.com", 80, "/" )]
    [TestCase(
        "test.com/some",
        Protocol.Http, "test.com", 80, "/some" )]
    [TestCase(
        "test.com:5000",
        Protocol.Http, "test.com", 5000, "" )]
    [TestCase(
        "test.com:5000/some",
        Protocol.Http, "test.com", 5000, "/some" )]
    public void Parse_InputIsAValidUrlButDocument_ReturnsValidHttpUrl(
        string url,
        Protocol expectedProtocol,
        string expectedDomain,
        int expectedPort,
        string expectedSlug )
    {
        // Act
        HttpUrl result = HttpUrlParser.Parse( url );
        
        // Assert
        Assert.AreEqual( expectedProtocol, result.Protocol );
        Assert.AreEqual( expectedDomain, result.Domain );
        Assert.AreEqual( expectedPort, result.Port );
        Assert.AreEqual( expectedSlug, result.Document );
    }

    [TestCase( "https://https://test.some.com" )]
    [TestCase( "https://test.some.com./" )]
    [TestCase( "https://test.some.com." )]
    [TestCase( "test.com/some folder/index.html" )]
    [TestCase( "te st.com/index.html" )]
    [TestCase( "https://te st.com/index.html" )]
    [TestCase( "https://test.com/." )]
    public void Parse_InputIsNotAValidUrl_ThrowsUrlParsingException( string url ) 
    {
        // Act & Assert
        Assert.Throws<UrlParsingException>( () => HttpUrlParser.Parse( url ) );
    }
}