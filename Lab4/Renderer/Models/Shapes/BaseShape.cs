using System.Numerics;
using Renderer.Canvases;
using Renderer.Colors;
using Renderer.MathUtils;

namespace Renderer.Shapes;

public interface IShape
{
    float Area { get; }
    float Perimeter { get; }
    
    Color? OutlineColor { get; set; }
    ShapeType ShapeType { get; }
    
    Vector2 Translate { get; set; }
    
    void RenderAt( ICanvas canvas );
}

public abstract class BaseShape : IShape
{
    protected readonly List<Vector2> Vertices;

    protected BaseShape(
        List<Vector2> vertices,
        Color outlineColor )
    {
        Vertices = vertices;
        Translate = Vector2.Zero;
        
        OutlineColor = outlineColor;
    }

    public Vector2 Translate { get; set; }

    public Color? OutlineColor { get; set; }

    public virtual ShapeType ShapeType => ShapeType.Undefined;

    public abstract float Area { get; }

    public abstract float Perimeter { get; }

    public virtual void RenderAt( ICanvas canvas )
    {
        for ( var i = 0; i < Vertices.Count; i++ )
        {
            Vector2 from = CalculateDrawablePoint( Vertices[i] );
            Vector2 to = CalculateDrawablePoint( Vertices[( i + 1 ) % Vertices.Count] );

            canvas.DrawLine( from, to, OutlineColor );
        }
    }

    protected List<Vector2> CalculateDrawablePoints( IEnumerable<Vector2> points )
    {
        return PointsCalculator.CalculateDrawablePoints(
            points,
            Translate );
    }

    protected Vector2 CalculateDrawablePoint( Vector2 point )
    {
        return PointsCalculator.CalculateDrawablePoint(
            point,
            Translate );
    }
}