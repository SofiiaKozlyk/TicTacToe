using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class Board4 : Board
    {
        public Board4()
        {
            this.Lattice = new string[,] {
                { "01", "02", "03", "04" },
                { "05", "06", "07", "08" },
                { "09", "10", "11", "12" },
                { "13", "14", "15", "16" } };
        }
        
    }
}
