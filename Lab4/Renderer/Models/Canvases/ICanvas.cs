using System.Numerics;
using Renderer.Colors;

namespace Renderer.Canvases;

public interface ICanvas
{
    Vector2 Size { get; }
    CanvasType CanvasType { get; }

    void Draw();
    void Clear();

    void SetPixel( Vector2 point, Color? color );
    char GetPixel( Vector2 point );
    void FillPolygon( Vector2 from, Vector2 to, Color? color );
    void DrawLine( Vector2 from, Vector2 to, Color? color );
    void DrawCircle( Vector2 center, float radius, Color? color );
    void FillCircle( Vector2 center, float radius, Color? color );
}