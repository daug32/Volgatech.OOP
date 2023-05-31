using System.Numerics;
using Renderer.Colors;
using Renderer.MathUtils;

namespace Renderer.Shapes;

public interface ILine : IShape
{
    Vector2 StartPoint { get; }
    Vector2 EndPoint { get; }
}

public class Line : BaseShape, ILine
{
    public Line(
        Vector2 startPoint,
        Vector2 endPoint,
        Color outlineColor )
        : base(
            new List<Vector2> { startPoint, endPoint },
            outlineColor )
    {
        OutlineColor = outlineColor;
    }

    public Vector2 StartPoint => CalculateDrawablePoint( Vertices[0] );

    public Vector2 EndPoint => CalculateDrawablePoint( Vertices[1] );

    public override float Area => 0;

    public override float Perimeter => PerimeterCalculator.CalculateForLine( StartPoint, EndPoint );

    public override ShapeType ShapeType => ShapeType.Line;

    public override string ToString()
    {
        return $"Shape line. Start point: {StartPoint}, End point: {EndPoint}";
    }
}