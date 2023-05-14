using System.Numerics;

namespace Renderer.Models.Canvases;

public interface ICanvas
{
    int Width { get; }
    int Height { get; }

    void Write( StreamWriter writer );

    void Clear( char code = ' ' );

    void SetPixel( int x, int y, char code );

    char GetPixel( int x, int y );
    
    void DrawLine( Vector2 from, Vector2 to );
}