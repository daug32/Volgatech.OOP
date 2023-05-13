using System.Numerics;
using System.Text;
using RendererApplication.Extensions;
using RendererApplication.Models;
using RendererApplication.Models.Canvases;
using RendererApplication.Models.Shapes;

namespace RendererApplication;

public class RendererApplication
{
    private readonly ICCanvas _canvas;
    private readonly RendererSettings _rendererSettings;

    public RendererApplication( ICCanvas canvas, RendererSettings rendererSettings )
    {
        _canvas = canvas;
        _rendererSettings = rendererSettings;
    }

    public void Draw()
    {
        if ( _rendererSettings.NeedToUseFile )
        {
            DrawInFile( _rendererSettings.FilePath! );
            return;
        }
        
        DrawInConsole();
    }

    private void DrawInFile( string path )
    {
        using var writer = new StreamWriter( path );
        DrawRectangles( writer );
    }

    private void DrawInConsole( )
    {
        var defaultOutput = Console.Out;
        
        using StreamWriter writer = new StreamWriter( Console.OpenStandardOutput() );
        writer.AutoFlush = true;
        Console.SetOut(writer);
        
        DrawRectangles( writer );
        
        Console.SetOut( defaultOutput );
    }

    private void DrawRectangles( StreamWriter output )
    {
        var rect1 = new CRectangle( 10, 3, Vector2.Zero );
        rect1.RenderAt( '+', _canvas );
        
        var rect2 = new CRectangle( 3, 5, new Vector2( 8, 1 ) );
        rect2.RenderAt( '-', _canvas );

        ICRectangle intersection = rect1.GetIntersection( rect2 );
        intersection.RenderAt( '#', _canvas );
        
        _canvas.Write( output );
    }
}