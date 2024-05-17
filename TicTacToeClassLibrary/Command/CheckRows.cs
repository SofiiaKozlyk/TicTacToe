using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary.Command
{
    internal class CheckRows : Check
    {
        public CheckRows(Board board) : base(board){}

        public override bool PerformCheck()
        {
            for (int i = 0; i < _board.Lattice.GetLength(0); i++)
            {
                firstChar = _board.Lattice[i, 0];
                if (Enumerable.Range(1, _board.Lattice.GetLength(1) - 1)
                    .All(col => _board.Lattice[i, col] == firstChar))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
