using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
            throw new ArgumentException("First and Second Strand don't have the same length!");
        
        char[] first = firstStrand.ToCharArray();
        char[] second = secondStrand.ToCharArray();
        
        int diff = 0;
        for (int i = 0; i < first.Length; ++i)
        {
            if (second.Length < i || first[i] != second[i]) 
                ++diff;
        }
        return diff;
    }
}