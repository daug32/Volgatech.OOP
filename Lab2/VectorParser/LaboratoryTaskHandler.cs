namespace Lab2.VectorParser;

public class LaboratoryTaskHandler
{
    /// <summary>
    /// Multiply by max and divide by min. Min and max are values from source list 
    /// </summary>
    public static void ProcessTask( List<double> list )
    {
        double min = list.Min();
        double max = list.Max();

        for ( var i = 0; i < list.Count; i++ )
        {
            list[i] = list[i] * max / min;
        }
    }
}