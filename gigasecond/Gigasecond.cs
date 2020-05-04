using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        return moment.Add(new TimeSpan(0,0,0,1000000000));
    }
}