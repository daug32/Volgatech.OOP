using System.Numerics;

namespace Renderer.Models.Shapes.SolidShapes;

public interface IRectangle : ISolidShape
{
    public int Width { get; }
    public int Height { get; }
    
    public Vector2 LeftTop { get; }
    
    public Vector2 RightBottom { get; }
}