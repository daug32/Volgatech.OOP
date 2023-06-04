using NUnit.Framework;

namespace Date.Tests;

public class GregorianCalendarHandlerTests
{
    [TestCase( 1970, 1, 1, 0 )]
    [TestCase( 2023, 5, 13, 19490 )]
    [TestCase( 2070, 12, 31, 36889 )]
    public void DateToDays_CommonTests(
        int year,
        int month,
        int day,
        int expected )
    {
        // Act
        int result = GregorianCalendarHandler.DateToDays( year, month, day );
        
        // Assert
        Assert.AreEqual( expected, result );
    }

    [TestCase( 0, 1970, 1, 1 )]
    [TestCase( 19490, 2023, 5, 13 )]
    [TestCase( 36889, 2070, 12, 31 )]
    [TestCase( 36890, 2071, 1, 1 )]
    public void DaysToDate_CommonTests(
        int timestamp,
        int expectedYear,
        int expectedMonth, 
        int expectedDay )
    {
        // Act
        DateDto dateDto = GregorianCalendarHandler.DaysToDate( timestamp );
        
        // Assert
        Assert.AreEqual( expectedYear, dateDto.Year );
        Assert.AreEqual( expectedMonth, dateDto.Month );
        Assert.AreEqual( expectedDay, dateDto.Day );
    }

    [Test]
    public void DateToDays_YearIsLessThenMinimal_ThrowsArgumentException()
    {
        // Arrange
        int year = 1960;
        int month = 1;
        int day = 1;
        
        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>( () => GregorianCalendarHandler.DateToDays( year, month, day ) );
    }

    [TestCase( 1970, 1, 1, true )]
    [TestCase( 1970, 1, 31, true )]
    [TestCase( 2023, 2, 28, true )]
    [TestCase( 2024, 2, 29, true )]
    [TestCase( 9999, 3, 30, true )]
    [TestCase( 2023, 5, -5, false )]
    [TestCase( 1970, 1, 0, false )]
    [TestCase( 2023, 2, 29, false )]
    [TestCase( 1970, 1, 32, false )]
    public void DayExists_CommonTests(
        int year,
        int month,
        int day,
        bool expected )
    {
        // Act
        bool result = GregorianCalendarHandler.DateExists( year, month, day );
        
        // Assert
        Assert.AreEqual( expected, result );
    }

    [TestCase( 2023, 5, 15, 1 )]
    [TestCase( 2023, 5, 16, 2 )]
    [TestCase( 2023, 5, 17, 3 )]
    [TestCase( 1970, 1, 1, 4 )]
    [TestCase( 9999, 12, 31, 5 )]
    [TestCase( 2023, 5, 13, 6 )]
    [TestCase( 2023, 5, 7, 7 )]
    public void GetDayOfWeek_CommonTests(
        int year,
        int month,
        int day,
        int expectedDay )
    {
        // Act
        int result = GregorianCalendarHandler.GetWeekDay( year, month, day );
        
        // Assert
        Assert.AreEqual( expectedDay, result );
    }
}