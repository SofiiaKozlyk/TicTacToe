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
        
    }
}
