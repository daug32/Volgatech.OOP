namespace Date.Models;

public class MyDate
{
    public static MyDate MinDate => new( GregorianCalendarHandler.MinSupportedYear, Month.January, 1 );
    public static MyDate MaxDate => new( GregorianCalendarHandler.MaxSupportedYear, Month.December, 31 );

    private int _daysFromMinDate;
    
    public MyDate( int year, Month month, int day )
    {
        _daysFromMinDate = GregorianCalendarHandler.DateToDays( year, ( int )month, day );
        UpdateProperties();
    }

    public MyDate( int daysFromMinDate )
    {
        ValidateTimestampOrThrow( daysFromMinDate );
        
        _daysFromMinDate = daysFromMinDate;
        UpdateProperties();
    }

    #region Properties

    private int _day;
    private int _year;
    private Month _month;
    private bool _hasChanges = true;
    
    public int Day
    {
        get
        {
            UpdateProperties();
            return _day;
        }
    }

    public Month Month
    {
        get
        {
            UpdateProperties();
            return _month;
        }
    }

    public int Year
    {
        get
        {
            UpdateProperties();
            return _year;
        }
    }

    public WeekDay GetWeekDay()
    {
        return ( WeekDay )GregorianCalendarHandler.GetWeekDay( Year, ( int )Month, Day );
    }

    private void UpdateProperties()
    {
        if ( !_hasChanges )
        {
            return;
        }

        DateDto dateDto = GregorianCalendarHandler.DaysToDate( _daysFromMinDate );
        _year = dateDto.Year;
        _month = ( Month )dateDto.Month;
        _day = dateDto.Day;

        _hasChanges = false;
    }
    
    #endregion

    public override string ToString()
    {
        return $"{Year}/{Month}/{Day}";
    }
    
    private void AddDays( int days )
    {
        ValidateTimestampOrThrow( _daysFromMinDate + days );
        _daysFromMinDate += days;
        _hasChanges = true;
    }

    private static void ValidateTimestampOrThrow( int timestamp )
    {
        if ( timestamp < MinDate._daysFromMinDate || timestamp > MaxDate._daysFromMinDate )
        {
            throw new ArgumentOutOfRangeException(
                $"Timestamp is out of range. Min: {MinDate._daysFromMinDate}, Max: {MaxDate._daysFromMinDate}" );
        }
    }
    
    #region Operators

    public static MyDate operator ++( MyDate a )
    {
        a.AddDays( 1 );
        return a;
    }

    public static MyDate operator +( MyDate a, int b )
    {
        return new MyDate( a._daysFromMinDate + b ); 
    }
    
    public static MyDate operator --( MyDate a )
    {
        a.AddDays( -1 );
        return a;
    }

    public static MyDate operator -( MyDate a, int b )
    {
        return new MyDate( a._daysFromMinDate - b );
    }
    
    public static bool operator >( MyDate a, MyDate b )
    {
        return a._daysFromMinDate > b._daysFromMinDate;
    }

    public static bool operator <( MyDate a, MyDate b )
    {
        return a._daysFromMinDate < b._daysFromMinDate;
    }

    public static bool operator ==( MyDate a, MyDate b )
    {
        return a._daysFromMinDate == b._daysFromMinDate;
    }

    public static bool operator !=( MyDate a, MyDate b )
    {
        return a._daysFromMinDate != b._daysFromMinDate;
    }
    
    public static bool operator <=( MyDate a, MyDate b )
    {
        return a._daysFromMinDate <= b._daysFromMinDate;
    }

    public static bool operator >=( MyDate a, MyDate b )
    {
        return a._daysFromMinDate >= b._daysFromMinDate;
    }
    
    #endregion Operators
}