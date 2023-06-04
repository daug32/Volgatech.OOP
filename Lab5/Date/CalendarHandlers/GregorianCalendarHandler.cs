namespace Date.CalendarHandlers;

public static class GregorianCalendarHandler
{
    public const int MinSupportedYear = 1970;
    public const int MaxSupportedYear = 9999;

    private static readonly Dictionary<int, int> _daysPerMonth = new()
    {
        { 1, 31 },
        { 2, 28 },
        { 3, 31 },
        { 4, 30 },
        { 5, 31 },
        { 6, 30 },
        { 7, 31 },
        { 8, 31 },
        { 9, 30 },
        { 10, 31 },
        { 11, 30 },
        { 12, 31 }
    };

    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static int DateToDays( int year, int month, int day )
    {
        ValidateDateOrThrow( year, month, day );

        int days = day;

        // Calculate the number of days from 1 January 1070.
        for ( int y = MinSupportedYear; y < year; y++ )
        {
            days += IsLeapYear( y )
                ? 366
                : 365;
        }

        // Add days for the current year.
        for ( var m = 1; m < month; m++ )
        {
            days += _daysPerMonth[m];
        }

        // If year is a leap year 
        if ( IsLeapYear( year ) && month > 2 )
        {
            days += 1;
        }

        // Return the total number of days 
        return days - 1;
    }

    public static DateDto DaysToDate( int days )
    {
        int year = MinSupportedYear;
        var month = 1;
        var day = 1;

        // Calculate year
        int daysInYear = IsLeapYear( year )
            ? 366
            : 365;

        while ( days > daysInYear )
        {
            days -= daysInYear;
            year++;

            daysInYear = IsLeapYear( year )
                ? 366
                : 365;
        }

        // Calculate month
        for ( var i = 1; i <= 12; i++ )
        {
            int daysInCurrentMonth = GetDaysInMonth( year, i );

            if ( days < daysInCurrentMonth )
            {
                break;
            }

            days -= daysInCurrentMonth;
            month++;
        }

        if ( month > 12 )
        {
            year++;
            month -= 12;
        }

        // Calculate day
        day += days;

        return new DateDto( year, month, day );
    }

    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public static int GetWeekDay( int year, int month, int day )
    {
        ValidateDateOrThrow( year, month, day );
        
        if (month < 3) {
            month += 12;
            year--;
        }
        
        int yearOfCentury = year % 100;
        int century = year / 100;

        int weekDay = ( day
                        + 13 * ( month + 1 ) / 5
                        + yearOfCentury
                        + yearOfCentury / 4
                        + century / 4
                        + 5 * century
                        - 1 )
                      % 7;

        // 0 equality is used because Zeller's formula requires Sunday to be the 0s day of a week
        return weekDay == 0
            ? 7
            : weekDay;
    }

    public static bool DateExists( int year, int month, int day )
    {
        if ( year is < MinSupportedYear or > MaxSupportedYear )
        {
            return false;
        }

        if ( month is < 1 or > 12 )
        {
            return false;
        }

        if ( day < 1 )
        {
            return false;
        }

        int daysInMonth = GetDaysInMonth( year, month );
        if ( day > daysInMonth )
        {
            return false;
        }

        return true;
    }

    private static int GetDaysInMonth( int year, int month )
    {
        int daysInMonth = _daysPerMonth[month];
        if ( month == 2 && IsLeapYear( year ) )
        {
            daysInMonth++;
        }

        return daysInMonth;
    }

    private static bool IsLeapYear( int year )
    {
        return year % 4 == 0 && ( year % 100 != 0 || year % 400 == 0 );
    }

    private static void ValidateDateOrThrow( int year, int month, int day )
    {
        if ( !DateExists( year, month, day ) )
        {
            throw new ArgumentOutOfRangeException( $"Given date ({year}/{month}/{day}) doesn't exist" );
        }
    }
}