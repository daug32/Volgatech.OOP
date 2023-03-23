namespace Lab2.VectorParser;

internal class Program
{
    // Task 1.5
    public static int Main()
    {
        List<double> vector;

        try
        {
            vector = ConsoleIO.ReadNumbers();
        }
        catch ( Exception ex )
        {
            ConsoleIO.PrintException( ex );
            return 1;
        }

        LaboratoryTaskHandler.ProcessTask( vector );
        ConsoleIO.PrintNumbers( vector );

        return 0;
    }
}