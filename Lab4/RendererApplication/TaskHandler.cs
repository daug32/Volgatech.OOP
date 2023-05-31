using Renderer.Shapes;
using RendererApplication.UserInput;

namespace RendererApplication;

public class TaskHandler
{
    private readonly IUserInterfaceHandler _uiHandler;

    public TaskHandler( IUserInterfaceHandler uiHandler )
    {
        _uiHandler = uiHandler;
    }

    public void ProcessLaboratoryTask( List<IShape> shapes )
    {
        if ( !shapes.Any() )
        {
            _uiHandler.PrintShapesNotEnteredMessage();
            return;
        }
        
        IShape shapeWithMinimalPerimeter = FindShapeWithMinimalPerimeter( shapes );
        _uiHandler.PrintShapeWithMinimalPerimeterInformation( shapeWithMinimalPerimeter );

        IShape shapeWithMaximalArea = FindShapeWithMaximalArea( shapes );
        _uiHandler.PrintShapeWithMaximalAreaInformation( shapeWithMaximalArea );
    }

    private static IShape FindShapeWithMaximalArea( IEnumerable<IShape> shapes )
    {
        return shapes.MaxBy( shape => shape.Area )!;
    }

    private static IShape FindShapeWithMinimalPerimeter( IEnumerable<IShape> shapes )
    {
        return shapes.MinBy( shape => shape.Perimeter )!;
    }
}