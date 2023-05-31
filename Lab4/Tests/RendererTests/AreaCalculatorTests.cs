using System.Numerics;
using NUnit.Framework;
using Renderer.MathUtils;

namespace RendererTests;

public class AreaCalculatorTests
{
    [Test]
    public void CalculateForRectangle_WidthIS10AndHeightIs3_Returns30()
    {
        // Arrange
        var expected = 30;

        // Act
        float result = AreaCalculator.CalculateForRectangle( 10, 3 );

        // Assert
        Assert.AreEqual( expected, result );
    }

    [Test]
    public void CalculateForTriangle_RightTriangleWithHeight10AndWidth5_Returns25()
    {
        // Arrange
        var expected = 25;
        var vertices = new List<Vector2>()
        {
            new Vector2( 10, 0 ),
            new Vector2( 0, 0 ),
            new Vector2( 0, 5 ),
        };

        // Act
        var result = AreaCalculator.CalculateForTriangle( vertices );
        
        // Assert
        Assert.AreEqual( expected, result );
    }
}