using System.Numerics;
using NUnit.Framework;
using Renderer.Colors;
using Renderer.Shapes;
using Renderer.Shapes.SolidShapes;
using RendererApplication.UserInput;

namespace RendererApplicationTests;

public class UserInputShapeParserTest
{
    [Test]
    public void Parse_InputValidRectangleData_ReturnsSameCircle()
    {
        // Arrange
        IShape expected = new Rectangle(
            Vector2.Zero,
            new Vector2( 10, 3 ),
            Color.FromHex( "fff" ),
            Color.FromInt( 0 ) );

        var input = "rectangle 0 0 10 3 fff 0";

        // Act
        IShape result = UserInputShapeParser.Parse( input );

        // Assert
        AssertShapes( expected, result );
    }

    [Test]
    public void Parse_InputValidRectangleDataWithUppercaseShapeType_ReturnsSameCircle()
    {
        // Arrange
        IShape expected = new Rectangle(
            Vector2.Zero,
            new Vector2( 10, 3 ),
            Color.FromHex( "fff" ),
            Color.FromInt( 0 ) );

        var input = "RECTANGLE 0 0 10 3 fff 0";

        // Act
        IShape result = UserInputShapeParser.Parse( input );

        // Assert
        AssertShapes( expected, result );
    }

    [Test]
    public void Parse_InputEmptyString_ThrowsArgumentException()
    {
        // Arrange
        var input = "";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => UserInputShapeParser.Parse( input ) );
    }

    [Test]
    public void Parse_InputUnsupportedShape_ThrowsArgumentException()
    {
        // Arrange
        var input = "unsupportedShapeType 0 0 10 3 fff 0";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => UserInputShapeParser.Parse( input ) );
    }

    [Test]
    public void Parse_InputRectangleWithoutDefiningFillColor_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        var input = "rectangle 0 0 10 3 fff";

        // Act & Assert
        Assert.Throws<IndexOutOfRangeException>( () => UserInputShapeParser.Parse( input ) );
    }

    [Test]
    public void Parse_InputTriangleDataWithoutThirdVertex_ThrowsFormatException()
    {
        // Arrange
        var input = "triangle 0 0 10 10 fff fff";

        // Act & Assert
        Assert.Throws<FormatException>( () => UserInputShapeParser.Parse( input ) );
    }

    [Test]
    public void Parse_InputValidTriangleData_ReturnsSameTriangle()
    {
        // Arrange
        var expected = new Triangle(
            new Vector2( 0, 10 ),
            new Vector2( 0, 0 ),
            new Vector2( 10, 100 ),
            Color.FromHex( "fff" ),
            Color.FromHex( "fff" ) );

        var input = "triangle 0 10 0 0 10 100 fff fff";

        // Act
        IShape result = UserInputShapeParser.Parse( input );

        // Assert
        AssertShapes( expected, result );
    }

    [Test]
    public void Parse_InputValidCircleData_ReturnsSameCircle()
    {
        // Arrange
        var expected = new Circle(
            new Vector2( -10, 123 ),
            33,
            Color.FromHex( "0fb" ),
            Color.FromHex( "000" ) );

        var input = "circle -10 123 33 0fb 000";

        // Act
        IShape result = UserInputShapeParser.Parse( input );

        // Assert
        AssertShapes( expected, result );
    }

    private static void AssertShapes( IShape expected, IShape result )
    {
        Assert.AreEqual( expected.ShapeType, result.ShapeType );
        Assert.AreEqual( expected.Area, result.Area );
        Assert.AreEqual( expected.Perimeter, result.Perimeter );
    }
}