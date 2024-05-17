using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary.Command
{
    public class CheckDiagonals : Check
    {
        public CheckDiagonals(Board board) : base(board) {}

        public override bool PerformCheck()
        {
            firstChar = _board.Lattice[0, 0];
            if (Enumerable.Range(1, _board.Lattice.GetLength(0) - 1)
                          .All(i => _board.Lattice[i, i] == firstChar))
            {
                return true;
            }

            firstChar = _board.Lattice[0, _board.Lattice.GetLength(1) - 1];
            if (Enumerable.Range(1, _board.Lattice.GetLength(0) - 1)
                          .All(i => _board.Lattice[i, _board.Lattice.GetLength(1) - 1 - i] == firstChar))
            {
                return true;
            }

            return false;
        }
    }
}
