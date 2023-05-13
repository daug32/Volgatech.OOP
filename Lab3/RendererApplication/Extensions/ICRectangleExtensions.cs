using RendererApplication.Models.Canvases;
using RendererApplication.Models.Shapes;

namespace RendererApplication.Extensions;

public static class ICRectangleExtensions
{
    public static void RenderAt( this ICRectangle rect, char color, ICCanvas canvas )
    {
        for ( int y = rect.Bottom; y < rect.Top; y++ )
        {
            for ( int x = rect.Left; x < rect.Right; x++ )
            {
                canvas.SetPixel( x, y, color );
            }
        }
    }   
}