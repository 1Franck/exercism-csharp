using System;

public class Clock: IEquatable<Clock>
{
    private int time { get; }
    
    public Clock(int hours, int minutes)
    {
        time = (60 * hours + minutes) % (24 * 60);
		while (time < 0)
			time += 24 * 60;
    }

    public override string ToString()
    {
        int hoursTotal = (time - (time % 60)) / 60;
        int minutes = (time - (hoursTotal * 60)) % 60;
        hoursTotal += (time - (hoursTotal * 60)) / 60;
        int hours = hoursTotal % 24;
        return string.Format("{0:D2}:{1:D2}", hours, minutes);
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(0, time + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(0, time - minutesToSubtract);
    }
    
    public bool Equals(Clock other)
    {
        return (other.time == this.time);
    }
}
