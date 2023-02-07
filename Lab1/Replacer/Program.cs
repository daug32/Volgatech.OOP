using System.Text;

namespace OOP.Lab1;

class Program
{
    static void Main( string[] args )
    {
        var settings = new ReplaceSettings();

        try
        {
            settings = BuildSettings( args );
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
            ThrowIfNotValid( settings );
        }
        catch (Exception ex )
        {
            Console.WriteLine( "An error occured while tried to check arguments validation" );
            Console.WriteLine( ex.Message );
            return;
        }

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
        var message = new StringBuilder();
        
        message.AppendLine( "Positional arguments are used:" );
        message.AppendLine( "1) <input file>" );
        message.AppendLine( "2) <output file>" );
        message.AppendLine( "3) <search string>" );
        message.AppendLine( "4) <replace string>" );

        Console.WriteLine( message );
    }

    public static ReplaceSettings BuildSettings( string[] args )
    {
        var settings = new ReplaceSettings
        {
            InputFilePath = Path.GetFullPath( args[ 0 ] ),
            OutputFilePath = Path.GetFullPath( args[ 1 ] ),
            SearchString = args[ 2 ],
            RepalceString = args[ 3 ]
        };

        return settings;
    }

    private static void ThrowIfNotValid( ReplaceSettings settings )
    {
        if (!File.Exists( settings.InputFilePath ) )
        {
            throw new FileNotFoundException( $"Input file not found at {settings.InputFilePath}" );
        }
    }
}