using Lab2.VectorParser;
using NUnit.Framework;

namespace Lab2.Tests.VectorParserTests;

public class ListParserUtilTests
{
    [Test]
    public void ParseListFromLine_StringWithDoubles_ListOfDoubles()
    {
        // Arrange
        var line = "12.0 32.9 -123.1";
        var expected = new List<double> { 12, 32.9, -123.1 };

        // Act
        List<double> result = ListParserUtil.ParseListFromLine( line );

        // Assert
        Assert.That( result, Has.Count.EqualTo(expected.Count));
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.That( result[i], Is.EqualTo(expected[i]));
        }
    }

    [Test]
    public void ParseListFromLine_StringWithIntegers_ListOfDoubles()
    {
        // Arrange
        var line = "1 2 -3";
        var expected = new List<double> { 1, 2, -3 };

        // Act
        List<double> result = ListParserUtil.ParseListFromLine( line );

        // Assert
        Assert.That( result, Has.Count.EqualTo(expected.Count));
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.That( result[i], Is.EqualTo(expected[i]));
        }
    }

    [Test]
    public void ParseListFromLine_StringWithDoublesAndIntegers_ListOfDoubles()
    {
        // Arrange
        var line = "1 2.232323 -3";
        var expected = new List<double> { 1, 2.232323, -3 };

        // Act
        List<double> result = ListParserUtil.ParseListFromLine( line );

        // Assert
        Assert.That( result, Has.Count.EqualTo( expected.Count ) );
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.That( result[i], Is.EqualTo( expected[i] ) );
        }
    }

    [Test]
    public void ParseListFromLine_StringWithLetters_Exception()
    {
        // Arrange
        var line = "1 asd 3";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => ListParserUtil.ParseListFromLine( line ) );
    }

    [Test]
    public void ParseListFromLine_EmptyString_EmptyList()
    {
        // Arrange
        var line = "";

        // Act
        List<double> result = ListParserUtil.ParseListFromLine( line );

        // Assert
        Assert.That( result, Is.Empty );
    }
}