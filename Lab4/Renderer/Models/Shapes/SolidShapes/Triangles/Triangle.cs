using System.Numerics;
using Renderer.MathUtils;
using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes.SolidShapes.Triangles;

public class Triangle : BaseShape, ITriangle
{
    public Triangle( 
        Vector2 a,
        Vector2 b,
        Vector2 c )
        : base( new List<Vector2> { a, b, c } )
    {
    }

    IReadOnlyList<Vector2> ITriangle.Vertices => base.Vertices;

    public char FillColor { get; set; } = Colors.Fill;

    public override float Area => AreaCalculator.CalculateForTriangle( Vertices );

    public override float Perimeter => PerimeterCalculator.CalculateForTriangle( Vertices );
}