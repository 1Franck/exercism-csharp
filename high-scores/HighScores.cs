using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private List<int> scores;

    public HighScores(List<int> list) => scores = list;

    public List<int> Scores()
    {
        return scores;
    }

    public int Latest()
    {
        return scores.Last();
    }

    public int PersonalBest()
    {
        var localScores = scores;
        localScores.Sort();
        return localScores.Last();
    }

    public List<int> PersonalTopThree()
    {
        var localScores = scores;
        localScores.Sort();
        localScores.Reverse();
        List<int> topThree = new List<int>();
        if (localScores.Count > 0) topThree.Add(localScores[0]);
        if (localScores.Count > 1) topThree.Add(localScores[1]);
        if (localScores.Count > 2) topThree.Add(localScores[2]);
        
        return topThree;
    }
}