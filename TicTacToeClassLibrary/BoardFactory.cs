using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class BoardFactory : IBoardFactory
    {
        public Board Create(string board)
        {
            switch (board)
            {
                case "4x4":
                case "2":
                    return new Board4();
                case "3x3":                  
                default:
                    return new Board3();
            }
        }
    }
}
