using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class Tournament
{   
    
    public class MatchResult
    {
        public string team1;
        public string team2;
        public string result;

        public MatchResult(string team1, string team2, string result)
        {
            this.team1 = team1;
            this.team2 = team2;
            this.result = result;
        }
    }

    public class Team
    {
        private string name;
        private int win = 0;
        private int tied = 0;
        private int defeat = 0;
        private int points = 0;
        private int matchCount = 0;

        public Team(string teamName) 
            => name = teamName;

        public void AddWin()
        {
            win++;
            matchCount++;
            points += 3;
        }
        
        public void AddTied()
        {
            tied++;
            matchCount++;
            points += 1;
        }
        
        public void AddDefeat()
        {
            defeat++;
            matchCount++;
        }

        public int GetPoints() 
            => points;

        public override string ToString() =>
            $"{name,-31}|{matchCount,3} |{win,3} |{tied,3} |{defeat,3} |{points,3}";
    }

    public class Teams
    {
        private Dictionary<string, Team> teams = new Dictionary<string, Team>();

        public void AddTeam(string name, Team team)
            => teams.Add(name, team);
        
        public bool HasTeam(string name)
            => teams.ContainsKey(name);

        public Team GetTeam(string name)
            => teams[name];

        public Dictionary<string, Team> GetAll()
            => teams;

        public void ProcessMatch(MatchResult m)
        {
            if (!HasTeam(m.team1))
                AddTeam(m.team1, new Team(m.team1));

            if (!HasTeam(m.team2))
                AddTeam(m.team2, new Team(m.team2));

            switch (m.result)
            {
                case "win":
                    GetTeam(m.team1).AddWin();
                    GetTeam(m.team2).AddDefeat();
                    break;
                case "loss":
                    GetTeam(m.team2).AddWin();
                    GetTeam(m.team1).AddDefeat();
                    break;
                case "draw":
                    GetTeam(m.team1).AddTied();
                    GetTeam(m.team2).AddTied();
                    break;
            }
        }
        
        public Dictionary<string, Team> GetAllByHighestPoints()
        {
            return (
                from team in teams
		        orderby team.Value.GetPoints() descending, team.Key 
		        select team
            ).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        }
    }

    public static void Tally(Stream inStream, Stream outStream)
    {
        StreamReader reader = new StreamReader(inStream);
        string[] lines = reader.ReadToEnd().Split("\n");
        reader.Close();

        Teams teams = new Teams();

        for (int i = 0; i < lines.Length; i++)
        {
            string[] lineParts = lines[i].Split(';');
            teams.ProcessMatch(new MatchResult(lineParts[0], lineParts[1], lineParts[2]));
        }
        
        List<string> report = new List<string>();
        report.Add("Team".PadRight(31) + "| MP |  W |  D |  L |  P");
        foreach (var team in teams.GetAllByHighestPoints())
        {
            report.Add(team.Value.ToString());
        }

        using (StreamWriter writer = new StreamWriter(outStream))  
        {  
            writer.Write(string.Join("\n", report));
            writer.Close();
        }
    }
}
