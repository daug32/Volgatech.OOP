using System.Numerics;
using Renderer.Colors;
using Renderer.Extensions;

namespace Renderer.Canvases.Implementation;

public class ConsoleCanvas : ICanvas
{
    private readonly Color _defaultBackgroundColor = Color.FromSymbol( ' ' );
    private readonly Color _defaultBorderColor = Color.FromSymbol( '@' );
    private readonly Color _defaultFillColor = Color.FromSymbol( '-' );
    
    private List<string> _buffer = null!;

    public ConsoleCanvas( int width, int height )
    {
        Resize( width, height );
    }

    public CanvasType CanvasType => CanvasType.Console;

    public Vector2 Size { get; private set; }

    public void Draw()
    {
        foreach ( string line in _buffer )
        {
            Console.WriteLine( line );
        }
    }

    public void Clear()
    {
        FillPolygon( Vector2.Zero, Size, _defaultBackgroundColor );
    }

    public void FillPolygon( Vector2 from, Vector2 to, Color? color )
    {
        color ??= _defaultFillColor;

        for ( var i = 0; i < _buffer.Count; i++ )
        {
            _buffer[i] = new string( ( char )color.Code, ( int )Size.X );
        }
    }

    public void SetPixel( Vector2 point, Color? color )
    {
        if ( !IsPointOnCanvas( point ) )
        {
            return;
        }

        var x = ( int )point.X;
        var y = ( int )point.Y;

        color ??= _defaultFillColor;

        _buffer[y] = _buffer[y].ReplaceAt( x, ( char )color.Code );
    }

    public char GetPixel( Vector2 point )
    {
        if ( !IsPointOnCanvas( point ) )
        {
            throw new ArgumentException( "Point at (x, y) does not exist" );
        }

        var y = ( int )point.Y;
        var x = ( int )point.X;

        return _buffer[y][x];
    }

    public void DrawLine(
        Vector2 from,
        Vector2 to,
        Color? color )
    {
        throw new NotImplementedException();
    }

    public void DrawCircle(
        Vector2 center,
        float radius,
        Color? color )
    {
        color ??= _defaultBorderColor;

        var previous = new Vector2();

        double thetaIncrement = 2 * Math.PI;

        for ( double theta = 0; theta <= 2 * Math.PI; theta += thetaIncrement )
        {
            var current = new Vector2(
                ( float )( radius * Math.Cos( theta ) ),
                ( float )( radius * Math.Sin( theta ) ) );

            DrawLine(
                previous,
                current,
                color );

            previous = current;
        }
    }

    public void FillCircle(
        Vector2 center,
        float radius,
        Color? fillColor )
    {
        throw new NotImplementedException();
    }

    private void Resize( int width, int height )
    {
        _buffer = new List<string>( height );

        for ( var y = 0; y < height; y++ )
        {
            var line = new string( ( char )_defaultBackgroundColor.Code, width );
            _buffer.Add( line );
        }

        Size = new Vector2( width, height );
    }

    private bool IsPointOnCanvas( Vector2 point )
    {
        return
            point.X >= 0
            && point.X <= Size.X
            && point.Y >= 0
            && point.Y <= Size.Y;
    }
}