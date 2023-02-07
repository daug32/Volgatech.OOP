using System.Text;

namespace OOP.Lab1;

class Program
{
    private static ReplaceSettingsBuilder _settingsBuilder = new();

    static void Main( string[] args )
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
        catch (Exception ex )
        {
            Console.WriteLine( "An error occured while tried to check arguments validation" );
            Console.WriteLine( ex.Message );
            return;
        }

        ReplaceSettings settings = _settingsBuilder.Settings;

        using var inputFile = new StreamReader( settings.InputFilePath );
        using var outputFile = new StreamWriter( settings.OutputFilePath, false );

        ReplaceInFile(
            inputFile,
            outputFile,
            settings.SearchString,
            settings.RepalceString );
    }

    public static void ReplaceInFile(
        StreamReader reader,
        StreamWriter writer,
        string search,
        string replace )
    {
        while ( !reader.EndOfStream )
        {
            string line = reader.ReadLine()!;
            line = line.Replace( search, replace );
            writer.WriteLine( line );
        }
    }

    private static void PrintHelp()
    {
        Console.WriteLine( _settingsBuilder.GetHelp() );
    }
}