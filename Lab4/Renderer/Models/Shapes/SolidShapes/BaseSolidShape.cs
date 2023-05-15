using System.Numerics;
using Renderer.Colors;

namespace Renderer.Shapes.SolidShapes;

public interface ISolidShape : IShape
{
    Color? FillColor { get; set; }
}

public abstract class BaseSolidShape : BaseShape, ISolidShape
{
    protected BaseSolidShape( 
        List<Vector2> vertices,
        Color outlineColor,
        Color fillColor )
        : base( 
            vertices, 
            outlineColor )
    {
        FillColor = fillColor;
    }

    public Color? FillColor { get; set; }
}