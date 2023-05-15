using System.Numerics;

namespace Renderer.MathUtils;

public class PerimeterCalculator
{
    public static float CalculateForTriangle( List<Vector2> vertices )
    {
        float a = Vector2.Distance( vertices[0], vertices[1] );
        float b = Vector2.Distance( vertices[1], vertices[2] );
        float c = Vector2.Distance( vertices[2], vertices[0] );

        return a + b + c;
    }

    public static float CalculateForLine( Vector2 from, Vector2 to )
    {
        return ( float )Math.Sqrt( Vector2.Distance( from, to ) );
    }

    public static float CalculateForCircle( float radius )
    {
        return ( float )( Math.PI * radius * 2 );
    }

    public static float CalculateForRectangle( int width, int height )
    {
        return 2 * ( width + height );
    }
}