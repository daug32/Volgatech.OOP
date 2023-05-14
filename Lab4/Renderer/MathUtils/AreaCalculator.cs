using System.Numerics;

namespace Renderer.MathUtils;

public class AreaCalculator
{
    public static float CalculateForTriangle( List<Vector2> triangleVertices )
    {
        float a = Vector2.Distance( triangleVertices[0], triangleVertices[1] );
        float b = Vector2.Distance( triangleVertices[1], triangleVertices[2] );
        float c = Vector2.Distance( triangleVertices[2], triangleVertices[0] );
        float s = ( a + b + c ) / 2;

        return ( float )Math.Sqrt( s * ( s - a ) * ( s - b ) * ( s - c ) );
    }
}