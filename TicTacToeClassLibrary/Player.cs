using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class Player
    {
        public string Name { get; set; }
        public string Sign { get; set; }
        public int Score { get; set; }
        public Player(string name, string sign, int score)
        {
            Name = name;
            Sign = sign;
            Score = score;
        }
        public void PrintPlayerInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Name);
            sb.Append(", Sign: ");
            sb.Append(Sign);
            sb.Append(", Score: ");
            sb.Append(Score);
            Console.WriteLine(sb.ToString());
        }
    }
}
