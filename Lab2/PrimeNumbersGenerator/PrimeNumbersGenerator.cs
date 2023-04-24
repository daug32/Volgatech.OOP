namespace PrimeNumbersGenerator;

public class PrimeNumbersGenerator
{
    public const int MaxUpperBound = 100000000;
    public const int MinUpperBound = 2;

    public static List<int> GeneratePrimeNumbers( int upperBound )
    {
        if ( upperBound > MaxUpperBound || upperBound < MinUpperBound )
        {
            throw new ArgumentOutOfRangeException( nameof( upperBound ) );
        }

        var primes = new List<int>();
        var isComposite = new bool[upperBound + 1];

        for ( var i = 2; i <= upperBound; i++ )
        {
            if ( isComposite[i] )
            {
                continue;
            }

            primes.Add( i );

            if ( ( long )i * i > upperBound )
            {
                continue;
            }

            for ( int j = i * i; j <= upperBound; j += i )
            {
                isComposite[j] = true;
            }
        }

        return primes;
    }
}