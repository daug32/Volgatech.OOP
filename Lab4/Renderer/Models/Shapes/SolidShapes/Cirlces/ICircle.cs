using System.Numerics;
using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes.SolidShapes.Cirlces;

public interface ICircle : ISolidShape
{
    public Vector2 Center { get; }
    public float Radius { get; set; }
}

public class Circle : ICircle
{
    public Circle( Vector2 center, float radius )
    {
        Translate = center;
        Radius = radius;
        Scale = Vector2.One;
    }

    public Vector2 Center => Translate;
    public float Radius { get; set; }

    public Vector2 Scale { get; set; }

    public Vector2 Translate { get; set; }

    public char OutlineColor { get; set; }

    public char FillColor { get; set; }

    public float Area => ( float )( Math.PI * Radius * Radius );

    public float Perimeter => ( float )( Math.PI * Radius * 2 );

    public void RenderAt( ICanvas canvas )
    {
        throw new NotImplementedException();
    }
}