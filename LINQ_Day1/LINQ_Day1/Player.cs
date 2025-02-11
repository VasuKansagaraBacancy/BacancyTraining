using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Day1
{
    public class Player
    {
        public int Id{get;private set;}
        public string Name{get;private set;}
        public string Team{ get;private set; }
        public int MatchesPlayed { get; private set; }
        public List<int> Scores { get; private set; }
        public Player(int  id,string name,string team,int matchesplayed,List<int> scores)
        {
            Id = id; 
            Name = name; 
            Team = team; 
            MatchesPlayed = matchesplayed;
            Scores = new List<int>(scores);
        }
    }
}