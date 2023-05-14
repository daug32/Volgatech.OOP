using Renderer.Extensions;

namespace Renderer.Models.Canvases.Implementation;

public class CCanvas : ICanvas
{
    private const char DefaultBackground = ' ';
    private List<string> _buffer = null!;

    public CCanvas( int width, int height )
    {
        Resize( width, height );
    }

    public int Width { get; private set; }

    public int Height { get; private set; }


    public void Write( StreamWriter writer )
    {
        foreach ( string line in _buffer )
        {
            writer.WriteLine( line );
        }
    }

    public void Clear( char code = DefaultBackground )
    {
        Fill( code );
    }

    public char GetPixel( int x, int y )
    {
        if ( !IsPointOnCanvas( x, y ) )
        {
            throw new ArgumentException( "Point at (x, y) does not exist" );
        }

        return _buffer[y][x];
    }

    public void SetPixel( int x, int y, char code )
    {
        if ( !IsPointOnCanvas( x, y ) )
        {
            return;
        }

        _buffer[y] = _buffer[y].ReplaceAt( x, code );
    }

    private void Fill( char code )
    {
        for ( var i = 0; i < _buffer.Count; i++ )
        {
            _buffer[i] = new string( code, Width );
        }
    }

    private void Resize( int width, int height )
    {
        _buffer = new List<string>( height );

        for ( var y = 0; y < height; y++ )
        {
            var line = new string( DefaultBackground, width );
            _buffer.Add( line );
        }
        
        Width = width;
        Height = height;
    }

    private bool IsPointOnCanvas( int x, int y )
    {
        return
            x >= 0
            && x <= Width
            && y >= 0
            && y <= Height;
    }
}