using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class TicTacToe
    {
        public Board TicTacToeBoard { get; set; }
        public string CurrentPlayer { get; set; }
        public TicTacToe()
        {
            TicTacToeBoard = new Board4();
            CurrentPlayer = "x";
            TicTacToeBoard.Print();
        }
        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == "x" ? "o" : "x";
        }

        public void WriteSign(int position)
        {
            if(position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0))
            {
                TicTacToeBoard.WriteSign(position, CurrentPlayer);
                SwitchCurrentPlayer();
                TicTacToeBoard.Print();
            }
            else
            {
                throw new Exception("There is no cell with this position");
            }
        }

    }
}
