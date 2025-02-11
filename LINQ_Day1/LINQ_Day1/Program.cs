using LINQ_Day1;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        PlayerManagement player = new PlayerManagement();
        List<Player> players = PlayerManagement.GetPlayers();
        player.DisplayPlayers(players);
        Console.WriteLine("-------Players who have played more than 5 matches-----");
        player.MethodMatchesGreaterthanFive(players);
        Console.WriteLine("-------Player names along with their team name-----");
        player.MethodPlayerData(players);
        Console.WriteLine("-------List of all individual scores-----");
        player.MethodAllScores(players);
        Console.WriteLine("-------Total Players-----");
        player.MethodTotalPlayers(players);
        Console.WriteLine("-------Player with the highest and lowest total score-----");
        player.MethodTotalHighestLowest(players);
        Console.WriteLine("-------Players sorted by total scores (descending) and then by name-----");
        player.MethodTotalThenby(players);
        Console.WriteLine("-------Group players by team and all player names under each team-----");
        player.MethodGroupByTeam(players);
        Console.WriteLine("-------Average score of all players is-----");
        player.MethodAvgScore(players);
        Console.WriteLine("-------Total number of matches played by all players combined-----");
        player.MethodTotalMatches(players);
        Console.WriteLine("-------Team with the highest total score among its players-----");
        player.MethodHighestinTeam(players);
    }
}