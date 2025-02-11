using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day1
{
    public class PlayerManagement
    {
        public static List<Player> GetPlayers()
        {
            return new List<Player> {
            new Player(1, "Virat Kohli", "India", 8, new List<int> { 45, 67, 198, 102, 56, 178, 195, 110 }),
            new Player(2, "Sachin Tendulkar", "India", 7, new List<int> { 40, 55, 60, 95, 110, 75, 88 }),
            new Player(3, "MS Dhoni", "India", 6, new List<int> { 38, 60, 72, 91, 85, 77 }),
            new Player(4, "Rohit Sharma", "India", 9, new List<int> { 50, 80, 60, 105, 115, 98, 75, 66, 77 }),
            new Player(5, "Steve Smith", "Australia", 5, new List<int> { 55, 90, 75, 88, 120 }),
            new Player(6, "David Warner", "Australia", 8, new List<int> { 45, 65, 75, 92, 110, 135, 125, 140 }),
            new Player(7, "Joe Root", "England", 6, new List<int> { 55, 90, 105, 77, 99, 122 }),
            new Player(8, "Kane Williamson", "New Zealand", 9, new List<int> { 40, 55, 88, 72, 60, 100, 77, 85, 90 }),
            new Player(9, "Ben Stokes", "England", 3, new List<int> { 35, 45, 60}),
            new Player(10, "Chris Gayle", "West Indies", 5, new List<int> { 30, 55, 75, 92, 105 }),
            new Player(11, "AB de Villiers", "South Africa", 8, new List<int> { 45, 80, 90, 110, 125, 140, 135, 99 }),
            new Player(12, "Glenn Maxwell", "Australia", 2, new List<int> { 50, 75 }),
            new Player(13, "Jacques Kallis", "South Africa", 9, new List<int> { 55, 70, 90, 110, 130, 125, 100, 95, 85 }),
            new Player(14, "Muttiah Muralitharan", "Sri Lanka", 7, new List<int> { 35, 45, 65, 75, 85, 95, 105 }),
            new Player(15, "Rashid Khan", "Afghanistan", 4, new List<int> { 20, 30, 45, 60 }),
            new Player(16, "Lasith Malinga", "Sri Lanka", 6, new List<int> { 40, 55, 70, 85, 90, 102 }),
            new Player(17, "Jasprit Bumrah", "India", 5, new List<int> { 35, 50, 75, 100, 115 }),
            new Player(18, "Yuvraj Singh", "India", 8, new List<int> { 25, 45, 65, 85, 110, 120, 135, 140 }),
            new Player(19, "Anil Kumble", "India", 7, new List<int> { 40, 55, 75, 105, 120, 135, 99 }),
            new Player(20, "Rahul Dravid", "India", 9, new List<int> { 45, 65, 85, 100, 120, 135, 140, 99, 110 })
            };
        }
        public void DisplayPlayers(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            foreach (var player in players)
            {
                if (player == null)
                    continue;
                Console.WriteLine($"Id: {player.Id}, Name: {player.Name}, Country: {player.Team}, Matches: {player.MatchesPlayed}");
                Console.WriteLine("Scores: " + (player.Scores != null ? string.Join(", ", player.Scores) : "No scores available"));
                Console.WriteLine("-----------------------------");
            }
        }
        public void MethodMatchesGreaterthanFive(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }
            List<Player> matchesgreaterthanfive = players.Where(p => p != null && p.MatchesPlayed > 5).ToList();
            DisplayPlayers(matchesgreaterthanfive);
        }
        public void QueryMatchesGreaterthanFive(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }

            List<Player> matchesgreaterthanfive = (from p in players
                                                   where p != null && p.MatchesPlayed > 5
                                                   select p).ToList();
            DisplayPlayers(matchesgreaterthanfive);
        }
        public void MethodPlayerData(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }
            var playerdata = players
                .Where(p => p != null)
                .Select(p => (p.Name ?? "Unknown", p.Team ?? "Unknown"));
            foreach (var player in playerdata)
            {
                Console.WriteLine($"Name: {player.Item1}\nTeam: {player.Item2}\n----------");
            }
        }
        public void QueryPlayerData(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }
            var playerdata = from p in players
                             where p != null
                             select (p.Name ?? "Unknown", p.Team ?? "Unknown");
            foreach (var player in playerdata)
            {
                Console.WriteLine($"Name: {player.Item1}\nTeam: {player.Item2}\n----------");
            }
        }
        public void MethodAllScores(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }
            var allscores = players
                .Where(p => p != null && p.Scores != null)
                .SelectMany(p => p.Scores);
            Console.WriteLine(allscores.Any() ? string.Join(", ", allscores) : "No scores available.");
        }
        public void QueryAllScores(List<Player> players)
        {
            if (players == null)
            {
                Console.WriteLine("Player list is null.");
                return;
            }
            var allscores = from p in players
                            where p != null && p.Scores != null
                            from score in p.Scores
                            select score;
            Console.WriteLine(allscores.Any() ? string.Join(", ", allscores) : "No scores available.");
        }
        public void MethodTotalPlayers(List<Player> players)
        {
            Console.WriteLine($"Total number of players: {(players != null ? players.Count : 0)}");
        }
        public void QueryTotalPlayers(List<Player> players)
        {
            int totalPlayers = players != null ? (from player in players select player).Count() : 0;
            Console.WriteLine($"Total number of players: {totalPlayers}");
        }
        public void MethodTotalHighestLowest(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var validPlayers = players
                .Where(p => p != null && p.Scores != null && p.Scores.Any())
                .ToList();
            if (validPlayers.Count == 0)
            {
                Console.WriteLine("No players with valid scores.");
                return;
            }
            var highestScorer = validPlayers.OrderByDescending(p => p.Scores.Sum()).FirstOrDefault()?.Name ?? "Unknown";
            var lowestScorer = validPlayers.OrderBy(p => p.Scores.Sum()).FirstOrDefault()?.Name ?? "Unknown";
            Console.WriteLine($"Highest Scorer: {highestScorer}");
            Console.WriteLine($"Lowest Scorer: {lowestScorer}");
        }
        public void QueryTotalHighestLowest(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var validPlayers = players
                .Where(p => p != null && p.Scores != null && p.Scores.Any())
                .ToList();
            if (validPlayers.Count == 0)
            {
                Console.WriteLine("No players with valid scores.");
                return;
            }
            var highestScorer = (from p in validPlayers
                                 orderby p.Scores.Sum() descending
                                 select p.Name ?? "Unknown").FirstOrDefault();
            var lowestScorer = (from p in validPlayers
                                orderby p.Scores.Sum()
                                select p.Name ?? "Unknown").FirstOrDefault();
            Console.WriteLine($"Highest Scorer: {highestScorer}");
            Console.WriteLine($"Lowest Scorer: {lowestScorer}");
        }
        public void MethodTotalThenby(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var sortedPlayers = players
                .Where(p => p != null && p.Scores != null) 
                .OrderByDescending(p => p.Scores.Any() ? p.Scores.Sum() : 0) 
                .ThenBy(p => p.Name ?? "Unknown"); 
            Console.WriteLine("\nPlayers sorted by total scores:");
            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Name ?? "Unknown"} - {(player.Scores.Any() ? player.Scores.Sum() : 0)} Runs");
            }
        }
        public void QueryTotalThenby(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var sortedPlayers = from p in players
                                where p != null && p.Scores != null
                                orderby (p.Scores.Any() ? p.Scores.Sum() : 0) descending, p.Name ?? "Unknown"
                                select p;
            Console.WriteLine("\nPlayers sorted by total scores:");
            foreach (var player in sortedPlayers)
            {
                Console.WriteLine($"{player.Name ?? "Unknown"} - {(player.Scores.Any() ? player.Scores.Sum() : 0)} Runs");
            }
        }
        public void MethodGroupByTeam(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var groupedByTeam = players
                .Where(p => p != null) 
                .GroupBy(p => p.Team ?? "Unknown Team") 
                .Select(g => new { Team = g.Key, Players = g.Select(p => p.Name ?? "Unknown Player") });
            foreach (var group in groupedByTeam)
            {
                Console.WriteLine(group.Team + ": " + string.Join(", ", group.Players));
            }
        }
        public void QueryGroupByTeam(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var groupedByTeam = from p in players
                                where p != null 
                                group p by p.Team ?? "Unknown Team" into teamGroup 
                                select new { Team = teamGroup.Key, Players = teamGroup.Select(p => p.Name ?? "Unknown Player") }; 
            foreach (var group in groupedByTeam)
            {
                Console.WriteLine(group.Team + ": " + string.Join(", ", group.Players));
            }
        }
        public void MethodAvgScore(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var validScores = players
                .Where(p => p != null && p.Scores != null) 
                .Select(p => p.Scores.Any() ? p.Scores.Sum() : 0) 
                .ToList();
            if (validScores.Count == 0)
            {
                Console.WriteLine("No valid scores available.");
                return;
            }
            double avgScore = validScores.Average();
            Console.WriteLine($"The average total score is: {avgScore}");
        }
        public void QueryAvgScore(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No players available.");
                return;
            }
            var validScores = from p in players
                              where p != null && p.Scores != null 
                              select p.Scores.Any() ? p.Scores.Sum() : 0;
            var scoreList = validScores.ToList();
            if (scoreList.Count == 0)
            {
                Console.WriteLine("No valid scores available.");
                return;
            }
            double avgScore = scoreList.Average();
            Console.WriteLine($"The average total score is: {avgScore}");
        }
        public void MethodTotalMatches(List<Player> players)
        {
            int totalMatches = players?.Where(p => p != null)?.Sum(p => p.MatchesPlayed) ?? 0;
            Console.WriteLine($"The total matches played by players is: {totalMatches}");
        }
        public void QueryTotalMatches(List<Player> players)
        {
            int totalMatches = (players?.Where(p => p != null).Select(p => p.MatchesPlayed).Sum()) ?? 0;
            Console.WriteLine($"The total matches played by players is: {totalMatches}");
        }
        public void MethodHighestinTeam(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No player data available.");
                return;
            }
            var bestinteam = players
                             .Where(p => p != null && p.Team != null) 
                             .GroupBy(p => p.Team)
                             .Select(g => new
                             {
                                 Team = g.Key,
                                 TotalScore = g.Sum(p => (p.Scores ?? new List<int>()).Sum())
                             })
                             .OrderByDescending(g => g.TotalScore)
                             .FirstOrDefault(); 
            if (bestinteam == null)
            {
                Console.WriteLine("No team data available.");
            }
            else
            {
                Console.WriteLine($"Team with the highest total score: {bestinteam.Team} ({bestinteam.TotalScore} Runs)");
            }
        }
        public void QueryHighestinTeam(List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                Console.WriteLine("No player data available.");
                return;
            }
            var bestinteam = (from p in players
                              where p != null && p.Team != null
                              group p by p.Team into teamGroup
                              select new
                              {
                                  Team = teamGroup.Key,
                                  TotalScore = teamGroup.Sum(p => (p.Scores ?? new List<int>()).Sum()) 
                              })
                              .OrderByDescending(g => g.TotalScore)
                              .FirstOrDefault(); 
            if (bestinteam == null)
            {
                Console.WriteLine("No team data available.");
            }
            else
            {
                Console.WriteLine($"Team with the highest total score: {bestinteam.Team} ({bestinteam.TotalScore} Runs)");
            }
        }
    }
}