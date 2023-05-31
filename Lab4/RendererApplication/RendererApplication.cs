using Renderer.Shapes;
using RendererApplication.UserInput;
using RendererApplication.UserInput.Models;

namespace RendererApplication;

public class RendererApplication
{
    private readonly IUserInterfaceHandler _uiHandler;
    private readonly TaskHandler _taskHandler;

    public RendererApplication( IUserInterfaceHandler uiHandler, TaskHandler taskHandler )
    {
        _uiHandler = uiHandler;
        _taskHandler = taskHandler;
    }

    public void Start()
    {
        _uiHandler.PrintApplicationStartedMessage();

        var shapes = new List<IShape>();

        while ( true )
        {
            UserResponse userShapeResponse = _uiHandler.AskForShape();
            if ( userShapeResponse.UserAction == UserAction.Exit )
            {
                break;
            }

            if ( userShapeResponse.UserAction == UserAction.NeedHelp )
            {
                _uiHandler.PrintHelpMessage();
                continue;
            }

            if ( !TryParseShape( userShapeResponse.Input!, out IShape shape ) )
            {
                _uiHandler.PrintCantParseShapeMessage();
                continue;
            }
            
            shapes.Add( shape );
        }

        _taskHandler.ProcessLaboratoryTask( shapes );

        _uiHandler.PrintApplicationCompletedMessage();
    }

    private static bool TryParseShape( string stringShape, out IShape shape )
    {
        try
        {
            shape = UserInputShapeParser.Parse( stringShape );
            return true;
        }
        catch ( Exception )
        {
            shape = null;
            return false;
        }
    }
}