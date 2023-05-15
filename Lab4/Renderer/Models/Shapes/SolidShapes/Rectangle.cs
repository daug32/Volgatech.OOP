using System.Net;
using System.Numerics;
using Renderer.Canvases;
using Renderer.Colors;
using Renderer.MathUtils;

namespace Renderer.Shapes.SolidShapes;

public interface IRectangle : ISolidShape
{
    int Width { get; }
    int Height { get; }
    Vector2 LeftTop { get; }
    Vector2 RightBottom { get; }
}

public class Rectangle : BaseSolidShape, IRectangle
{
    public Rectangle(
        Vector2 start,
        Vector2 size,
        Color outlineColor,
        Color fillColor )
        : base(
            new List<Vector2>
            {
                Vector2.Zero,
                size with { Y = 0 },
                size,
                size with { X = 0 }
            },
            outlineColor,
            fillColor )
    {
        Translate = start;
    }

    public int Width => ( int )( RightBottom.X - LeftTop.X );

    public int Height => ( int )( LeftTop.Y - RightBottom.Y );

    public Vector2 LeftTop => CalculateDrawablePoint( Vertices[3] );

    public Vector2 RightBottom => CalculateDrawablePoint( Vertices[1] );

    public override float Area => AreaCalculator.CalculateForRectangle( Width, Height );

    public override float Perimeter => PerimeterCalculator.CalculateForRectangle( Width, Height );
}