using System.Numerics;

namespace Renderer.MathUtils;

public static class PointsCalculator
{
    public static List<Vector2> CalculateDrawablePoints(
        IEnumerable<Vector2> vertices,
        Vector2 translation,
        Vector2? scale = null )
    {
        return vertices
            .Select(
                vertex => CalculateDrawablePoint(
                    vertex,
                    translation,
                    scale ) )
            .ToList();
    }

    public static Vector2 CalculateDrawablePoint(
        Vector2 vertex,
        Vector2 translation,
        Vector2? scale = null )
    {
        Vector2 result = vertex + translation;
        if ( scale != null )
        {
            result *= scale.Value;
        }

        return result;
    }
}