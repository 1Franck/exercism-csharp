using System;

public class SpaceAge
{
    private int humanYearInSeconds = 31557600;
    private int age;

    public SpaceAge(int seconds) => age = seconds;


    public double OnEarth()
    {
        return (double)age / (double)humanYearInSeconds;
    }

    public double OnMercury()
    {
        return (double)age / ((double)humanYearInSeconds *  0.2408467);
    }

    public double OnVenus()
    {
        return (double)age / ((double)humanYearInSeconds *  0.61519726);
    }

    public double OnMars()
    {
        return (double)age / ((double)humanYearInSeconds *  1.8808158);
    }

    public double OnJupiter()
    {
        return (double)age / ((double)humanYearInSeconds *  11.862615);
    }

    public double OnSaturn()
    {
        return (double)age / ((double)humanYearInSeconds *  29.447498);
    }

    public double OnUranus()
    {
        return (double)age / ((double)humanYearInSeconds *  84.016846);
    }

    public double OnNeptune()
    {
        return (double)age / ((double)humanYearInSeconds *  164.79132);
    }
}