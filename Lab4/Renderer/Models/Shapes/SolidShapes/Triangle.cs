using System.Numerics;
using Renderer.Colors;
using Renderer.MathUtils;

namespace Renderer.Shapes.SolidShapes;

public interface ITriangle : ISolidShape
{
    IReadOnlyList<Vector2> Vertices { get; }
}

public class Triangle : BaseSolidShape, ITriangle
{
    public Triangle(
        Vector2 a,
        Vector2 b,
        Vector2 c,
        Color outlineColor,
        Color fillColor )
        : base( 
            new List<Vector2> { a, b, c },
            outlineColor,
            fillColor )
    {
    }

    IReadOnlyList<Vector2> ITriangle.Vertices => CalculateDrawablePoints( Vertices );

    public override float Area => AreaCalculator.CalculateForTriangle( Vertices );

    public override float Perimeter => PerimeterCalculator.CalculateForTriangle( Vertices );
}