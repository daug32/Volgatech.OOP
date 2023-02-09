namespace Lab1.Radix;

public class ConvertorServiceTest
{
    public static void RunAll()
    {
        Equal( ConvertorService.Convert( 10, 2, "9" ), "1001" );
        Equal( ConvertorService.Convert( 10, 2, "10" ), "1010" );
        Equal( ConvertorService.Convert( 10, 9, "10" ), "11" );

        Equal( ConvertorService.Convert( 2, 10, "1001" ), "9" );
        Equal( ConvertorService.Convert( 2, 10, "1010" ), "10" );
        Equal( ConvertorService.Convert( 9, 10, "11" ), "10" );

        Equal( ConvertorService.Convert( 16, 10, "10" ), "16" );
        Equal( ConvertorService.Convert( 16, 10, "11" ), "17" );
        Equal( ConvertorService.Convert( 36, 10, "37" ), "115" );

        Equal( ConvertorService.Convert( 10, 16, "16" ), "10" );
        Equal( ConvertorService.Convert( 10, 16, "17" ), "11" );
        Equal( ConvertorService.Convert( 10, 36, "115" ), "37" );

        Equal( ConvertorService.Convert( 36, 2, "20" ), "1001000" );
        Equal( ConvertorService.Convert( 27, 2, "123" ), "1100010010" );
        Equal( ConvertorService.Convert( 2, 36, "1001000" ), "20" );
        Equal( ConvertorService.Convert( 2, 27, "1100010010" ), "123" );

        Equal( ConvertorService.Convert( 27, 2, "-123" ), "-1100010010" );
        Equal( ConvertorService.Convert( 2, 36, "-1001000" ), "-20" );
    }

    public static void Equal( string result, string expected )
    {
        if ( result != expected )
        {
            throw new Exception( $"Values are not equal. Result: {result}, expected: {expected}" );
        }
    }
}
