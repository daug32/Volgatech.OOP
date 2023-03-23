using Lab2.HtmlDecode;
using NUnit.Framework;

namespace HtmlDecodeTests;

public class HtmlDecoderTests
{
    [Test]
    public void Decode_LineWithoutSpecialSymbols_SameLine()
    {
        // Arrange
        var input = "Text";
        var expected = "Text";

        // Act
        string result = HtmlDecoder.Decode( input );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [TestCase( "&lt;main&gt; test breakers &lt;/main&gt;", "<main> test breakers </main>" )]
    [TestCase( "test ampersand &amp;amp;", "test ampersand &amp;" )]
    [TestCase( "test apostrophe&apos;s symbol", "test apostrophe's symbol" )]
    [TestCase( "test &quot;double quotes&quot;", "test \"double quotes\"" )]
    [TestCase( "test encoding symbol & for reading to end", "test encoding symbol & for reading to end" )]
    public void Decode_LineWithEncodedSpecialSymbols_DecodedLine( string input, string expected )
    {
        // Act
        string result = HtmlDecoder.Decode( input );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [Test]
    public void Decode_LineWithDecodedSymbols_SameLine()
    {
        // Arrange
        var input = "<main> text </main>";
        var expected = "<main> text </main>";

        // Act
        string result = HtmlDecoder.Decode( input );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [Test]
    public void Decode_EmptyLine_EmptyLine()
    {
        // Arrange
        var input = String.Empty;

        // Act
        string result = HtmlDecoder.Decode( input );

        // Assert
        Assert.AreEqual( 0, result.Length );
    }

    [TestCase( "&lt;h1&gt;Header&lt;/h1&gt;", "<h1>Header</h1>" )]
    [TestCase( "&lt;h1&gt;Header&lt;/h1&gt;!q", "<h1>Header</h1>!q" )]
    [TestCase( 
@"&lt;html&gt;
    &lt;head&gt;
        &lt;title&gt;Document title&lt;/title&gt;
    &lt;/head&gt;
    &lt;body&gt;
        &lt;h1&gt;Header&lt;/h1&gt;
    &lt;/body&gt;
&lt;/html&gt;
!q",

@"<html>
    <head>
        <title>Document title</title>
    </head>
    <body>
        <h1>Header</h1>
    </body>
</html>" )]
    [TestCase( 
@"&lt;html&gt;
    &lt;head&gt;
        &lt;title&gt;Document title&lt;/title&gt;
    &lt;/head&gt;
    &lt;body&gt;
        &lt;h1&gt;Header&lt;/h1&gt;
    &lt;/body&gt;
&lt;/html&gt;",

@"<html>
    <head>
        <title>Document title</title>
    </head>
    <body>
        <h1>Header</h1>
    </body>
</html>" )]
    public void DecodeFile_EncodedHtml_DecodedHtml( string input, string expected )
    {
        // Act
        string result;
        using ( TextReader reader = new StringReader( input ) )
        {
            using ( TextWriter writer = new StringWriter() )
            {
                HtmlDecoder.DecodeFile( reader, writer );
                result = writer.ToString()!;
            }
        }

        // Assert
        Assert.AreEqual( expected, result );
    }
}