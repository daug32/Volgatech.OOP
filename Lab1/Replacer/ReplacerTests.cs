namespace OOP.Lab1;

public class ReplacerTests
{
    public static bool RunAll()
    {
        try
        {
            Equal( Replacer.CustomReplace( "123456", "12", "  " ), "  3456" );
            Equal( Replacer.CustomReplace( "123456", "6", "  " ), "12345  " );
            Equal( Replacer.CustomReplace( "123456", "3", "  " ), "12  456" );

            Equal( Replacer.CustomReplace( "123456", "123456", "REPLACED" ), "REPLACED" );

            Equal( Replacer.CustomReplace( "123456", "123456", "" ), "" );

            Equal( Replacer.CustomReplace( "123456", "Test", "REPLACED" ), "123456" );
        }
        catch ( Exception ex )
        {
            Console.WriteLine( ex.Message );
            return false;
        }

        return true;
    }

    private static void Equal( string result, string expected )
    {
        if ( result != expected )
        {
            throw new Exception( $"Expected: \"{expected}\", but got \"{result}\"" );
        }
    }
}