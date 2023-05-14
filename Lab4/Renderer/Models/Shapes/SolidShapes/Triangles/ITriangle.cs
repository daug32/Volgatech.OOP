using System.Numerics;

namespace Renderer.Models.Shapes.SolidShapes.Triangles;

public interface ITriangle : ISolidShape
{
    IReadOnlyList<Vector2> Vertices { get; }
}