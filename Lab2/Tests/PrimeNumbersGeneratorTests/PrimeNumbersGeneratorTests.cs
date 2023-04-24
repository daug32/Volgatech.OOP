using NUnit.Framework;

namespace PrimeNumbersGeneratorTests;

public class PrimeNumbersGeneratorTests
{
    [Test]
    public void Get10FirstPrimeNumbersIn30Diapason()
    {
        // Arrange
        var expected = new List<int>
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29
        };

        // Act
        List<int> result = PrimeNumbersGenerator.PrimeNumbersGenerator.GeneratePrimeNumbers( 30 );

        // Assert
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.That( result[i], Is.EqualTo( expected[i] ) );
        }
    }

    [Test]
    public void GetLast10PrimeNumbersIn100MillionsDiapason()
    {
        // Arrange
        var expected = new List<int>
        {
            99999787,
            99999821,
            99999827,
            99999839,
            99999847,
            99999931,
            99999941,
            99999959,
            99999971,
            99999989
        };

        // Act
        List<int> result = PrimeNumbersGenerator.PrimeNumbersGenerator.GeneratePrimeNumbers( 100000000 );

        // Assert
        for ( var i = 0; i < expected.Count; i++ )
        {
            Assert.That( result[result.Count - 1 - i], Is.EqualTo( expected[expected.Count - 1 - i] ) );
        }
    }
}