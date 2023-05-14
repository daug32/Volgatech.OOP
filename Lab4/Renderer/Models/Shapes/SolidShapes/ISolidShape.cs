namespace Renderer.Models.Shapes.SolidShapes;

public interface ISolidShape : IShape
{
    char FillColor { get; set; }
}