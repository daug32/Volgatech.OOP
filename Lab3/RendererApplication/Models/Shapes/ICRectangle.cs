using System.Numerics;

namespace RendererApplication.Models.Shapes;

public interface ICRectangle
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Vector2 Move { get; set; }
    public Vector2 Scale { get; set; }

    public int Left { get; set; }
    public int Top { get; set; }
    public int Right { get; set; }
    public int Bottom { get; set; }

    public float Area { get; }
    public float Perimeter { get; }

    public ICRectangle GetIntersection( ICRectangle rectangle );
    bool DoesIntersect( ICRectangle rect );
}