using System.Numerics;
using NUnit.Framework;
using Renderer.Models.Shapes.SolidShapes.Triangles;

namespace RendererTests;

public class CTriangleTests
{
    [Test]
    public void Area_RegularTriangleWithAllSidesEqualTo3_AreaShouldBeAlmost4()
    {
        // Arrange
        float side = 3;
        
        var a = Vector2.Zero;
        var b = new Vector2( 0.5f * side, 0.87f * side );
        var c = new Vector2( side, 0 );
            
        var triangle = new Triangle( a, b, c );
        
        // Act
        float area = triangle.Area;

        // Assert 
        Assert.AreEqual( 3.89f, area, 0.01 );
    }
}