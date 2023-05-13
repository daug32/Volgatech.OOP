using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes;

public interface IShape
{
    float Area { get; }
    float Perimeter { get; }
    
    void RenderAt( ICanvas canvas );
}