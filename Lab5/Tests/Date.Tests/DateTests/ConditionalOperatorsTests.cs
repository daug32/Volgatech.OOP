using Date.Models;
using NUnit.Framework;

namespace Date.Tests.DateTests;

public class ConditionalOperatorsTests
{
    [TestCase( 
        1970, Month.January, 1,
        1970, Month.January, 2 )]
    [TestCase( 
        2070, Month.January, 1,
        2070, Month.December, 1 )]
    [TestCase( 
        2070, Month.January, 1,
        2071, Month.January, 1 )]
    public void LessThanOperator_FirstDateIsLessThanSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate < secondDate );
    }
    
    [TestCase( 
        1970, Month.January, 2,
        1970, Month.January, 1 )]
    [TestCase( 
        2070, Month.February, 1,
        2070, Month.January, 1 )]
    [TestCase( 
        2071, Month.January, 1,
        2070, Month.January, 1 )]
    public void LessThanOperator_FirstDateIsBiggerThanSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate < secondDate );
    }
    
    [TestCase( 
        1970, Month.January, 2,
        1970, Month.January, 1 )]
    [TestCase( 
        2070, Month.February, 1,
        2070, Month.January, 1 )]
    [TestCase( 
        2071, Month.January, 1,
        2070, Month.January, 1 )]
    public void MoreThanOperator_FirstDateIsBiggerThanSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate > secondDate );
    }

    [TestCase( 
        1970, Month.January, 1,
        1970, Month.January, 2 )]
    [TestCase( 
        2070, Month.January, 1,
        2070, Month.December, 1 )]
    [TestCase( 
        2070, Month.January, 1,
        2071, Month.January, 1 )]
    public void MoreThanOperator_FirstDateIsLessThanSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate > secondDate );
    }

    [TestCase( 
        1970, 1, 1,
        1970, 1, 1 )]
    [TestCase( 
        1970, Month.February, 13,
        1970, Month.February, 13 )]
    [TestCase( 
        9999, Month.December, 1,
        9999, Month.December, 1 )]
    public void EqualityOperator_FirstDateIsEqualToSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate == secondDate );
    }

    [TestCase( 
        1970, 1, 2,
        1970, 1, 1 )]
    [TestCase( 
        1970, Month.February, 13,
        1970, Month.April, 13 )]
    [TestCase( 
        9991, Month.December, 1,
        9999, Month.December, 1 )]
    public void EqualityOperator_FirstDateIsNotEqualToSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate == secondDate );
    }

    [TestCase( 
        1970, 1, 2,
        1970, 1, 1 )]
    [TestCase( 
        1970, Month.February, 13,
        1970, Month.April, 13 )]
    [TestCase( 
        9991, Month.December, 1,
        9999, Month.December, 1 )]
    public void InequalityOperator_FirstDateIsNotEqualToSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate != secondDate );
    }

    [TestCase( 
        1970, 1, 1,
        1970, 1, 1 )]
    [TestCase( 
        1970, Month.February, 13,
        1970, Month.February, 13 )]
    [TestCase( 
        9999, Month.December, 1,
        9999, Month.December, 1 )]
    public void EqualityOperator_FirstDateIsEqualToSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate != secondDate );
    }

    [TestCase( 
        1970, 1, 2,
        1970, 1, 1 )]
    [TestCase( 
        1970, Month.February, 13,
        1970, Month.February, 13 )]
    [TestCase( 
        9999, Month.December, 31,
        2000, Month.January, 1 )]
    public void NotLessThanOperator_FirstDateIsBiggerOrEqualThanSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate >= secondDate );
    }

    [TestCase( 
        1970, 1, 1,
        1970, 1, 2 )]
    [TestCase( 
        1970, Month.March, 13,
        1970, Month.December, 31 )]
    [TestCase( 
        2000, Month.January, 1 ,
        9999, Month.December, 31 )]
    public void NotLessThanOperator_FirstDateIsLessThanSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate >= secondDate );
    }

    [TestCase( 
        1970, 1, 1,
        1970, 1, 2 )]
    [TestCase( 
        1970, Month.December, 13,
        1970, Month.December, 13 )]
    [TestCase( 
        2000, Month.January, 1 ,
        9999, Month.December, 31 )]
    public void NotMoreThanOperator_FirstDateIsLessOrEqualThanSecondOne_ReturnsTrue(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsTrue( firstDate <= secondDate );
    }

    [TestCase( 
        1970, Month.January, 2,
        1970, Month.January, 1 )]
    [TestCase( 
        2070, Month.February, 1,
        2070, Month.January, 1 )]
    [TestCase( 
        2071, Month.January, 1,
        2070, Month.January, 1 )]
    public void NotMoreThanOperator_FirstDateIsBiggerThanSecondOne_ReturnsFalse(
        int firstYear,
        Month firstMonth,
        int firstDay,
        int secondYear,
        Month secondMonth,
        int secondDay )
    {
        // Arrange
        var firstDate = new MyDate( firstYear, firstMonth, firstDay );
        var secondDate = new MyDate( secondYear, secondMonth, secondDay );
        
        // Act & Assert
        Assert.IsFalse( firstDate <= secondDate );
    }
}