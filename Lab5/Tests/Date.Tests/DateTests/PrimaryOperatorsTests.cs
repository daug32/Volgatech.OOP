using Date.Models;
using NUnit.Framework;

namespace Date.Tests.DateTests;

public class PrimaryOperatorsTests
{
    [TestCase(
        1970, Month.January, 2,
        1970, Month.January, 1 )]
    [TestCase(
        9900, Month.January, 31,
        9900, Month.January, 30 )]
    [TestCase(
        1970, Month.February, 1,
        1970, Month.January, 31 )]
    [TestCase(
        2023, Month.March, 1,
        2023, Month.February, 28 )]
    [TestCase(
        1971, Month.January, 1,
        1970, Month.December, 31 )]
    public void IncrementOperator_SimpleTestsWithoutGettingOutOfPossibleDateRanges_PropertiesAreModify(
        int expectedYear,
        Month expectedMonth,
        int expectedDay,
        int inputYear,
        Month inputMonth,
        int inputDay )
    {
        // Arrange
        var date = new MyDate( inputYear, inputMonth, inputDay );

        // Act
        date++;

        // Assert
        Assert.AreEqual( expectedYear, date.Year );
        Assert.AreEqual( expectedMonth, date.Month );
        Assert.AreEqual( expectedDay, date.Day );
    }

    [Test]
    public void IncrementOperator_GetOutOfPossibleDateRanges_ThrowsArgumentException()
    {
        // Arrange
        var date = new MyDate( 9999, Month.December, 31 );

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => date++ );
    }

    [TestCase(
        1970, Month.January, 1,
        1970, Month.January, 2 )]
    [TestCase(
        9900, Month.January, 30,
        9900, Month.January, 31 )]
    [TestCase(
        1970, Month.January, 31,
        1970, Month.February, 1 )]
    [TestCase(
        2023, Month.February, 28,
        2023, Month.March, 1 )]
    [TestCase(
        1970, Month.December, 31,
        1971, Month.January, 1 )]
    public void DecrementOperator_SimpleTestsWithoutGettingOutOfPossibleDateRanges_PropertiesAreModify(
        int expectedYear,
        Month expectedMonth,
        int expectedDay,
        int inputYear,
        Month inputMonth,
        int inputDay )
    {
        // Arrange
        var date = new MyDate( inputYear, inputMonth, inputDay );

        // Act
        date--;

        // Assert
        Assert.AreEqual( expectedYear, date.Year );
        Assert.AreEqual( expectedMonth, date.Month );
        Assert.AreEqual( expectedDay, date.Day );
    }

    [Test]
    public void DecrementOperator_GetOutOfPossibleDateRanges_ThrowsArgumentException()
    {
        // Arrange
        var date = new MyDate( 1970, Month.January, 1 );

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => date-- );
    }

    [Test]
    public void PlusOperator_SimpleTestWithoutGettingOutOfPossibleDateRanges_PropertiesAreModify()
    {
        // Arrange
        var date = new MyDate( 2020, Month.August, 8 );
        var expected = new MyDate( 2021, Month.August, 8 );

        // Act
        date += 365;

        // Assert
        AssertUtils.AreDatesEqual( expected, date );
    }

    [Test]
    public void PlusOperator_GetOutOfPossibleDateRanges_ThrowsArgumentException()
    {
        // Arrange
        var date = new MyDate( 9999, Month.January, 1 );

        // Act
        Assert.Throws<ArgumentOutOfRangeException>( () => date += 365 );
    }

    [Test]
    public void MinusOperator_SimpleTestWithoutGettingOutOfPossibleDateRanges_PropertiesAreModify()
    {
        // Arrange
        var date = new MyDate( 2021, Month.January, 1 );
        var expected = new MyDate( 2020, Month.December, 31 );

        // Act
        date -= 1;

        // Assert
        AssertUtils.AreDatesEqual( expected, date );
    }

    [Test]
    public void MinusOperator_GetOutOfPossibleDateRanges_ThrowsArgumentException()
    {
        // Arrange
        var date = new MyDate( 1970, Month.January, 1 );

        // Act
        Assert.Throws<ArgumentOutOfRangeException>( () => date -= 1 );
    }
}