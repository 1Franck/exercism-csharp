using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        // if (year % 4 == 0)
        // {
        //     if (year % 100 == 0)
        //     {
        //         if (year % 400 == 0)
        //         {
        //             return true;
        //         }
        //         return false;
        //     }
        //     return true;
        // }
        // or
        return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        return DateTime.IsLeapYear(year);
    }
}