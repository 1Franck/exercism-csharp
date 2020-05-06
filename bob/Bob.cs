using System;
using System.Linq;

public static class Bob
{
    public static string Response(string statement)
    {
        if (statement.Trim() == "")
        {
            return "Fine. Be that way!";
        }
        else if (statement.Trim().Last() == '?')
        {
            return (IsAllUpper(statement) ? "Calm down, I know what I'm doing!" : "Sure.");
        }
        else if (IsAllUpper(statement))
            return "Whoa, chill out!";

        return "Whatever.";
    }
    
    private static bool IsAllUpper(string input)
    {
        if (!input.Any(char.IsUpper))
        {
            return false;
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                return false;
        }
        return true;
    }
}