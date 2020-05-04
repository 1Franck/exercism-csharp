using System;

public class Robot
{
    public string Name { get; private set; }

    public Robot()
    {
        this.Name = this.randomUid();
    }

    private string randomUid()
    {
        return randomChar().ToString() + randomChar().ToString() + 
               randomNumber().ToString() + randomNumber().ToString() + randomNumber().ToString();
    }

    private char randomChar()
    {
        Random r = new Random();
        int code = r.Next(65, 90);
        return (char) code;
    }

    private int randomNumber()
    {
        Random r = new Random();
        return r.Next(0, 9);
    }

    public void Reset()
    {
        this.Name = this.randomUid();
    }
}