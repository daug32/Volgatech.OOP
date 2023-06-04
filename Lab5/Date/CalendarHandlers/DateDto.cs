namespace Date.CalendarHandlers;

public readonly struct DateDto
{
    public readonly int Year;
    public readonly int Month;
    public readonly int Day;

    public DateDto( int year, int month, int day )
    {
        Year = year;
        Month = month;
        Day = day;
    }
}