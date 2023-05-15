using Renderer.Shapes;
using RendererApplication.UserInput.Models;

namespace RendererApplication.UserInput;

public interface IUserInterfaceHandler
{
    void PrintHelpMessage();
    UserResponse AskForShape();
    void PrintApplicationStartedMessage();
    void PrintApplicationCompletedMessage();
    void PrintCantParseShapeMessage();
    void PrintShapesNotEnteredMessage();
    void PrintShapeWithMinimalPerimeterInformation( IShape shape );
    void PrintShapeWithMaximalAreaInformation( IShape shape );
}