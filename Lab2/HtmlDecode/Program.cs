namespace Lab2.HtmlDecode;

internal class Program
{
    // Task 2.5
    public static void Main()
    {
        Console.WriteLine( $"Enter encoded html. To complete writing type \"{HtmlDecoder.ExitCode}\".\n" );
        HtmlDecoder.DecodeFile( Console.In, Console.Out );
    }
}