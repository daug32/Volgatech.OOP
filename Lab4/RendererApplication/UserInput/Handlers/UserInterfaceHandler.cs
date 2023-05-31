using System.Text;
using Renderer.Shapes;
using Renderer.Shapes.SolidShapes;
using RendererApplication.UserInput.Models;

namespace RendererApplication.UserInput;

public class UserInterfaceHandler : IUserInterfaceHandler
{
    private readonly string _exitCommand = "exit";

    private readonly string _helpCommand = "help";
    private readonly TextReader _reader;
    private readonly TextWriter _writer;

    public UserInterfaceHandler( TextWriter writer, TextReader reader )
    {
        _writer = writer;
        _reader = reader;
    }

    public void PrintHelpMessage()
    {
        string message = @$"Commands:
1) Exit: type '{_exitCommand}' to exit from application
2) Help: type '{_helpCommand}' to get this message
3) Or enter shape data in the following format to get info about it
* Rectangle:
    <Vector: start rendering point>
    <Vector: shape size>
    <Color: outline color>
    <Color: fill color>
Example: '0 0 10 3 fff 0'

* Triangle:
    <Vector: 1st triangle vertex>
    <Vector: 2nd triangle vertex>
    <Vector: 3d triangle vertex>
    <Color: outline color>
    <Color: fill color>

* Circle: 
    <Vector: circle's center>
    <Float: circle's radius>
    <Color: outline color>
    <Color: fill color>

* Line: 
    <Vector: start point>
    <Vector: end point>
    <Color: outline color>

Notes:
1) 'Vector' should be written in '<Float: X coordinate> <Float: Y coordinate>' format. Example: '1.3 -30'
2) 'Color' should be written in hex format (1, 3 or 6 hex symbols). Example: '1', 'fff', 'a1b2c3'
3) 'Float'. Example '323.33'";

        _writer.WriteLine( message );
    }

    public UserResponse AskForShape()
    {
        _writer.WriteLine( $"Enter shape information or any other command. Print '{_helpCommand}' to see them all" );

        return GetUserResponse();
    }

    public void PrintApplicationStartedMessage()
    {
        _writer.WriteLine( "Renderer application started." );
    }

    public void PrintApplicationCompletedMessage()
    {
        _writer.WriteLine( "Renderer application completed." );
    }

    public void PrintCantParseShapeMessage()
    {
        _writer.WriteLine( "Can't parse shape." );
    }

    public void PrintShapesNotEnteredMessage()
    {
        _writer.WriteLine( "No shapes were entered." );
    }

    public void PrintShapeWithMinimalPerimeterInformation( IShape shape )
    {
        _writer.WriteLine( "Shape with minimal perimeter:" );
        PrintShapeInformation( shape );
    }

    public void PrintShapeWithMaximalAreaInformation( IShape shape )
    {
        _writer.WriteLine( "Shape with maximal area:" );
        PrintShapeInformation( shape );
    }

    private void PrintShapeInformation( IShape shape )
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine( $"Area: {shape.Area}, Perimeter: {shape.Perimeter}" );

        stringBuilder.Append( $"Outline color: {shape.OutlineColor}" );
        if ( shape is ISolidShape solidShape )
        {
            stringBuilder.Append( $", Fill color {solidShape.FillColor}" );
        }

        stringBuilder.AppendLine();

        stringBuilder.AppendLine( shape.ToString() );

        _writer.WriteLine( stringBuilder.ToString() );
    }

    private UserResponse GetUserResponse()
    {
        string response = _reader.ReadLine()?.Trim() ?? String.Empty;

        return BuildUserResponse( response );
    }

    private UserResponse BuildUserResponse( string response )
    {
        if ( CompareStrings( response, _exitCommand ) )
        {
            return new UserResponse( UserAction.Exit );
        }

        if ( CompareStrings( response, _helpCommand ) )
        {
            return new UserResponse( UserAction.NeedHelp );
        }

        return new UserResponse( UserAction.GetShapeInfo, response );
    }

    private bool CompareStrings( string a, string b )
    {
        int compareResult = String.Compare(
            a,
            b,
            StringComparison.OrdinalIgnoreCase );

        return compareResult == 0;
    }
}