using System.Numerics;

namespace Renderer.MathUtils;

public class PerimeterCalculator
{
    public static float CalculateForTriangle( List<Vector2> vertices )
    {
        float a = Vector2.Distance(vertices[0], vertices[1]);
        float b = Vector2.Distance(vertices[1], vertices[2]);
        float c = Vector2.Distance(vertices[2], vertices[0]);

        return a + b + c;
    }
}