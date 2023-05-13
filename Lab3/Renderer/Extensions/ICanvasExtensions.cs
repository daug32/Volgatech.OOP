using Renderer.Models.Canvases;
using Renderer.Models.Shapes;

namespace Renderer.Extensions;

public static class CanvasExtensions
{
    public static void RenderShape( this ICanvas canvas, IShape shape )
    {
        shape.RenderAt( canvas );
    }
}