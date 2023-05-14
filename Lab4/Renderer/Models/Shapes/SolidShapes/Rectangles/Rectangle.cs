using System.Numerics;

namespace Renderer.Models.Shapes.SolidShapes;

public class Rectangle : BaseShape, IRectangle
{
    public Rectangle(
        int width,
        int height )
        : base(
            new List<Vector2>
            {
                Vector2.Zero,
                new( width, 0 ),
                new( width, height ),
                new( 0, height )
            } )
    {
    }

    public int Width => ( int )( RightBottom.X - LeftTop.X );

    public int Height => ( int )( LeftTop.Y - RightBottom.Y );

    public Vector2 LeftTop => Vertices[3];

    public Vector2 RightBottom => Vertices[1];

    public char FillColor { get; set; } = Colors.Fill;

    public override float Area => Width * Height;

    public override float Perimeter => 2 * ( Width + Height );
}