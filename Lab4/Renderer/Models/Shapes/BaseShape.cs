using System.Numerics;
using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes.SolidShapes;

public abstract class BaseShape : IShape
{
    public Vector2 Scale { get; set; }
    
    public Vector2 Translate { get; set; }
    
    protected readonly List<Vector2> Vertices;

    protected BaseShape( List<Vector2> vertices )
    {
        Vertices = vertices;
        Scale = Vector2.One;
        Translate = Vector2.Zero;
    }

    public abstract float Area { get; }

    public abstract float Perimeter { get; }

    public char OutlineColor { get; set; }

    public virtual void RenderAt( ICanvas canvas )
    {
        for ( var i = 0; i < Vertices.Count; i++ )
        {
            Vector2 from = CalculateDrawableVector( Vertices[i] );
            Vector2 to = CalculateDrawableVector( Vertices[( i + 1 ) % Vertices.Count] );

            canvas.DrawLine( from, to );
        }
    }

    protected Vector2 CalculateDrawableVector( Vector2 point )
    {
        point += Translate;
        point *= Scale;

        return point;
    }
}