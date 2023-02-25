using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OOP.Lab1;

public class ReplaceSettingsBuilder
{
    public ReplaceSettings Settings { get; protected set; } = new();

    public void Build( string[] args )
    {
        try
        {
            ParseSettings( args );
        }
        catch ( Exception ex )
        {
            throw new ArgumentException( $"An error occured while tried to parse arguments. {ex.Message}" );
        }

        try
        {
            ThrowIfNotValid();
        }
        catch (Exception ex )
        {
            throw new ValidationException( $"An error occured while tried to check arguments validation. {ex.Message}" );
        }
    }

    private void ParseSettings( string[] args )
    {
        Settings.InputFilePath = Path.GetFullPath( args[ 0 ] );
        Settings.OutputFilePath = Path.GetFullPath( args[ 1 ] );

        if ( args.Length > 2 )
        {
            Settings.SearchString = args[ 2 ];
        }

        if ( args.Length > 3 )
        {
            Settings.ReplaceString = args[ 3 ];
        }
    }

    private void ThrowIfNotValid()
    {
        if ( Settings.InputFilePath == Settings.OutputFilePath )
        {
            throw new ArgumentException( "Input and output files can not be the same" );
        }

        if ( !File.Exists( Settings.InputFilePath ) )
        {
            throw new FileNotFoundException( $"Input file not found at {Settings.InputFilePath}" );
        }
    }

    public string GetHelp()
    {
        var message = new StringBuilder();

        message.AppendLine( "Positional arguments are used:" );
        message.AppendLine( "1) <input file>" );
        message.AppendLine( "2) <output file>" );
        message.AppendLine( "3) <search string>" );
        message.AppendLine( "4) <replace string>" );

        return message.ToString();
    }
}
