namespace OOP.Lab1;

internal class Program
{
    private static readonly ReplaceSettingsBuilder _settingsBuilder = new();

    private static void Main( string[] args )
    {
        if ( !RunTests() )
        {
            return;
        }

        Run( args );
    }

    private static bool RunTests()
    {
        return ReplacerTests.RunAll();
    }

    private static void Run( string[] args )
    {
        try
        {
            _settingsBuilder.Build( args );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( ex.Message );
            PrintHelp();
            return;
        }

        ReplaceSettings settings = _settingsBuilder.Settings;

        using var inputFile = new StreamReader( settings.InputFilePath );
        using var outputFile = new StreamWriter( settings.OutputFilePath, false );

        Replacer.ReplaceInFile(
            inputFile,
            outputFile,
            settings.SearchString,
            settings.ReplaceString );
    }

    private static void PrintHelp()
    {
        Console.WriteLine( _settingsBuilder.GetHelp() );
    }
}