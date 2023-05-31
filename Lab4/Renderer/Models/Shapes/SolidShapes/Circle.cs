using System.Numerics;
using Renderer.Canvases;
using Renderer.Colors;
using Renderer.MathUtils;

namespace Renderer.Shapes.SolidShapes;

public interface ICircle : ISolidShape
{
    Vector2 Center { get; }
    float Radius { get; set; }
}

public class Circle : ICircle
{
    public Circle(
        Vector2 center,
        float radius,
        Color outlineColor,
        Color fillColor )
    {
        Translate = center;
        Radius = radius;

        OutlineColor = outlineColor;
        FillColor = fillColor;
    }

    public Vector2 Center => Translate;

    public float Radius { get; set; }

    public Vector2 Translate { get; set; }

    public Color? OutlineColor { get; set; }

    public Color? FillColor { get; set; }

    public ShapeType ShapeType => ShapeType.Circle;

    public float Area => AreaCalculator.CalculateForCircle( Radius );

    public float Perimeter => PerimeterCalculator.CalculateForCircle( Radius );

    public void RenderAt( ICanvas canvas )
    {
        canvas.FillCircle( Center, Radius, FillColor );
        canvas.DrawCircle( Center, Radius, OutlineColor );
    }

    public override string ToString()
    {
        return $"Circle shape. Center: {Center}, Radius: {Radius}, Translate: {Translate}";
    }
}