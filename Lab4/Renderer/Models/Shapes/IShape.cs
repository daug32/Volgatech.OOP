using System.Numerics;
using Renderer.Models.Canvases;

namespace Renderer.Models.Shapes;

public interface IShape
{
    float Area { get; }
    float Perimeter { get; }
    char OutlineColor { get; set; }

    Vector2 Scale { get; set; }
    Vector2 Translate { get; set; }
    
    void RenderAt( ICanvas canvas );
}