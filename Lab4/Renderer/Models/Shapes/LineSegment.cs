using System.Numerics;
using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes;

public class LineSegment : IShape
{
    public LineSegment( Vector2 startPoint, Vector2 endPoint )
    {
        StartPoint = startPoint;
        EndPoint = endPoint;
    }

    public Vector2 StartPoint { get; set; }

    public Vector2 EndPoint { get; set; }

    public Vector2 Scale { get; set; }

    public Vector2 Translate { get; set; }

    public float Area { get; }

    public float Perimeter { get; }

    public char OutlineColor { get; set; }

    public void RenderAt( ICanvas canvas )
    {
        throw new NotImplementedException();
    }
}