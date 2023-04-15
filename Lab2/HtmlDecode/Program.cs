namespace Lab2.HtmlDecode;

internal class Program
{
    private const string ExitCode = "!q";
    private static readonly HtmlDecoder _htmlDecoder = new HtmlDecoder( ExitCode );

    // Task 2.5
    public static void Main()
    {
        Console.WriteLine( $"Enter encoded html. To complete writing type \"{ExitCode}\".\n" );
        _htmlDecoder.Decode( Console.In, Console.Out );
    }
}