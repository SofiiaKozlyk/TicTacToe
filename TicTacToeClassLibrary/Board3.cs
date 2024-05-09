using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class Board3 : Board
    {
        public Board3()
        {
            this.Lattice = new string[,] { 
                { "1", "2", "3" }, 
                { "4", "5", "6" }, 
                { "7", "8", "9" } };
        }
        public override void Print()
        {
            for(int i = 0; i < this.Lattice.GetLength(0); i++)
            {
                for(int j = 0; j < this.Lattice.GetLength(1); j++)
                {
                    Console.Write(this.Lattice[i, j]);
                    Console.Write(" | ");
                }
                Console.WriteLine("\n--- --- ---");
            }
        }
    }
}
