using Date.Models;
using NUnit.Framework;

namespace Date.Tests.DateTests;

public class PrimaryTests
{
    [TestCase( 1000, Month.April, 1 )]
    [TestCase( 1969, Month.December, 31 )]
    public void CtorDate_DateIsLessThanMinimalDate_ThrowArgumentException( int year, Month month, int day )
    {
        Assert.Throws<ArgumentOutOfRangeException>( () => new MyDate( year, month, day ) );
    }

    [TestCase( 10000, Month.January, 1 )]
    [TestCase( Int32.MaxValue, Month.February, 1 )]
    public void CtorDate_DateIsBiggerThanMaximalDate_ThrowsArgumentException( int year, Month month, int day )
    {
        Assert.Throws<ArgumentOutOfRangeException>( () => new MyDate( year, month, day ) );
    }

    [TestCase( 1970, Month.January, 1 )]
    [TestCase( 9999, Month.December, 31 )]
    [TestCase( 2023, Month.May, 13 )]
    public void CtorDate_DateIsLessThanMaximalAndBiggerThanMinimal_DoesntThrow(
        int year,
        Month month,
        int day )
    {
        // Act & Assert
        Assert.DoesNotThrow( () => new MyDate( year, month, day ) );
    }

    [TestCase( 0, 1970, Month.January, 1 )]
    [TestCase( 1, 1970, Month.January, 2 )]
    [TestCase( 365, 1971, Month.January, 1 )]
    public void CtorTimestamp_CommonTests(
        int timestamp,
        int expectedYear,
        Month expectedMonth,
        int expectedDay )
    {
        // Arrange
        var expected = new MyDate( expectedYear, expectedMonth, expectedDay );

        // Act
        var result = new MyDate( timestamp );

        // Assert
        AssertUtils.AreDatesEqual( expected, result );
    }

    [TestCase( Int32.MinValue )]
    [TestCase( -1 )]
    [TestCase( 3_000_000 )]
    [TestCase( Int32.MaxValue )]
    public void CtorTimestamp_TimestampIsOutOfRange_ThrowsArgumentOutOfRangeException( int timestamp )
    {
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => new MyDate( timestamp ) );
    }

    [TestCase( 2023, Month.August, 7, WeekDay.Monday )]
    [TestCase( 2023, Month.April, 4, WeekDay.Tuesday )]
    [TestCase( 2023, Month.June, 7, WeekDay.Wednesday )]
    [TestCase( 2024, Month.February, 29, WeekDay.Thursday )]
    [TestCase( 2023, Month.June, 9, WeekDay.Friday )]
    [TestCase( 2023, Month.June, 10, WeekDay.Saturday )]
    [TestCase( 2023, Month.June, 11, WeekDay.Sunday )]
    public void GetWeekDayTests( 
        int year, 
        Month month, 
        int day,
        WeekDay expectedWeekDay )
    {
        // Arrange
        var date = new MyDate( year, month, day );
        
        // Act
        WeekDay result = date.GetWeekDay();
            
        // Assert
        Assert.AreEqual( expectedWeekDay, result );
    }
}