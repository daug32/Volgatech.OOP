using System.Numerics;

namespace Renderer.Models.Shapes.SolidShapes;

public interface ICRectangle : ISolidShape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Vector2 Move { get; set; }
    public Vector2 Scale { get; set; }

    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public ICRectangle GetIntersection( ICRectangle rectangle );
    bool DoesIntersect( ICRectangle rect );
}