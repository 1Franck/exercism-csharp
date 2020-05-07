using System;
using System.Collections.Generic;
using System.Linq;

public static class MatchingBrackets
{
    public static bool IsPaired(string input)
    {
        Dictionary<char, char> brackets = new Dictionary<char, char>
        {
            {'}', '{'},
            {']', '['},
            {')', '('},
        };

        char[] chars = input.ToCharArray();
        List<char> openBracketsQueue = new List<char>();
        
        for (int i = 0; i < chars.Length; ++i)
        {
            if (brackets.ContainsValue(chars[i]))
            {
                openBracketsQueue.Add(chars[i]);
            }
            else if (brackets.ContainsKey(chars[i]))
            {
                brackets.TryGetValue(chars[i], out char openBracket);
                if (openBracketsQueue.Count == 0 || openBracketsQueue.Last() != openBracket)
                {
                    return false;
                }
                openBracketsQueue.RemoveAt(
                    openBracketsQueue.LastIndexOf(openBracketsQueue.Last())
                );
            }
        }

        return (openBracketsQueue.Count == 0);
    }
}
