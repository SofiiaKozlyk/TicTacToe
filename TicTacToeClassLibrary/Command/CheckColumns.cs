using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary.Command
{
    public class CheckColumns : Check
    {
        public CheckColumns(Board board) : base(board) { }

        public override bool PerformCheck()
        {
            int cellsForWin = _board.CellForWin == 0 ? _board.Lattice.GetLength(1) : _board.CellForWin;

            for (int i = 0; i < _board.Lattice.GetLength(1); i++)
                for (int j = 0; j < _board.Lattice.GetLength(0) - cellsForWin + 1; j++)
                {
                    firstChar = _board.Lattice[j, i];
                    if (Enumerable.Range(1, cellsForWin - 1)
                        .All(row => _board.Lattice[j + row, i] == firstChar))
                        return true;
                }          

            return false;
        }
    }
}
