using System.Text;

namespace Lab1.Radix;

public class RadixSettingsBuilder
{
    public RadixSettings Settings { get; protected set; } = new();

    public void Build( string[] args )
    {
        Settings.SourceNotation = GetNotation( args[ 0 ] );
        Settings.DestinationNotation = GetNotation( args[ 1 ] );
        Settings.Value = args[ 2 ].Trim().ToUpper();
    }

    public void ThrowIfNotValid()
    {
        if ( !ConvertorService.IsNotationSupported( Settings.SourceNotation ) )
        {
            var message = $"Notation is out range of acceptable values: {Settings.SourceNotation}";
            throw new ArgumentOutOfRangeException( message );
        }

        if ( !ConvertorService.IsNotationSupported( Settings.DestinationNotation ) )
        {
            var message = $"Notation is out range of acceptable values: {Settings.DestinationNotation}";
            throw new ArgumentOutOfRangeException( message );
        }

        if ( String.IsNullOrWhiteSpace( Settings.Value ) )
        {
            throw new ArgumentException( "Value is null or whitespace" );
        }

        if ( !ConvertorService.CanCovert( Settings.Value ) )
        {
            throw new ArgumentException( $"Can't convert given value: {Settings.Value}" );
        }
    }

    public static string GetHelp()
    {
        var message = new StringBuilder();

        message.AppendLine( "Positional arguments are used:" );
        message.AppendLine( "1) <source notation>" );
        message.AppendLine( "2) <destination notation>" );
        message.AppendLine( "1) <value>" );

        return message.ToString();
    }

    private static int GetNotation( string stringNotation )
    {
        if ( !Int32.TryParse( stringNotation, out int notation ) )
        {
            throw new ArgumentException( $"Notation is not a number. Given notation: {stringNotation}" );
        }

        return notation;
    }
}
