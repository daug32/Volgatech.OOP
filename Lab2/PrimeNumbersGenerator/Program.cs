namespace PrimeNumbersGenerator;

public class Program
{
    public static void Main()
    {
        PrimeNumbersGenerator
            .GeneratePrimeNumbers( 3 )
            .ForEach( Console.WriteLine );
    }
}