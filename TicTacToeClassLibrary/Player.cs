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
            Console.WriteLine($"{Name}, Sign: {Sign}, Score: {Score}");
        }
    }
}
