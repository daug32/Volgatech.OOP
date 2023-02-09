namespace Lab1.Radix;

public class Program
{
    private static readonly RadixSettingsBuilder _settingsBuilder = new();

    static void Main( string[] args )
    {
        if ( !RunTests() )
        {
            return;
        }

        RunTask( args );
    }

    private static bool RunTests()
    {
        try
        {
            ConvertorServiceTest.RunAll();
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"{ex.Message}\n{ex.StackTrace}" );
            return false;
        }

        return true;
    }

    private static void RunTask( string[] args )
    {
        try
        {
            _settingsBuilder.Build( args );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "An error occured while tried to parse arguments" );
            Console.WriteLine( ex.Message );
            PrintHelp();
            return;
        }

        try
        {
            _settingsBuilder.ThrowIfNotValid();
        }
        catch ( Exception ex )
        {
            Console.WriteLine( "An error occured while tried to check arguments validation" );
            Console.WriteLine( ex.Message );
            return;
        }

        RadixSettings settings = _settingsBuilder.Settings;
        string? converted = ConvertorService.Convert(
            settings.SourceNotation,
            settings.DestinationNotation,
            settings.Value );

        Console.WriteLine( converted );
    }

    private static void PrintHelp() => Console.WriteLine( RadixSettingsBuilder.GetHelp() );
}