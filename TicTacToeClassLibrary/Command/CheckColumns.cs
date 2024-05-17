using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary.Command
{
    public class CheckColumns : Check
    {
        public CheckColumns(Board board) : base(board) { }
        public override bool PerformCheck()
        {
            for (int i = 0; i < _board.Lattice.GetLength(1); i++)
            {
                firstChar = _board.Lattice[0, i];
                if (Enumerable.Range(1, _board.Lattice.GetLength(1) - 1)
                    .All(row => _board.Lattice[row, i] == firstChar))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
