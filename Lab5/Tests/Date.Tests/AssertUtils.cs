using Date.Models;
using NUnit.Framework;

namespace Date.Tests;

public static class AssertUtils
{
    public static void AreDatesEqual( MyDate expected, MyDate result )
    {
        Assert.AreEqual( expected.Year, result.Year );
        Assert.AreEqual( expected.Month, result.Month );
        Assert.AreEqual( expected.Day, result.Day );
    }
}