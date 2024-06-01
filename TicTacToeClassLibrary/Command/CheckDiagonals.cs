using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary.Command
{
    public class CheckDiagonals : Check
    {
        public CheckDiagonals(Board board) : base(board) { }

        public override bool PerformCheck()
        {
            int cellsForWin = _board.CellForWin == 0 ? _board.Lattice.GetLength(1) : _board.CellForWin;

            for (int i = 0; i < _board.Lattice.GetLength(0) - cellsForWin + 1; i++)
                for (int j = 0; j < _board.Lattice.GetLength(1) - cellsForWin + 1; j++)
                {
                    firstChar = _board.Lattice[i, j];
                    if (Enumerable.Range(1, cellsForWin - 1)
                        .All(col => _board.Lattice[i + col, j + col] == firstChar))
                        return true;
                }

            for (int i = 0; i < _board.Lattice.GetLength(0) - cellsForWin + 1; i++)
                for (int j = cellsForWin - 1; j < _board.Lattice.GetLength(1); j++)
                {
                    firstChar = _board.Lattice[i, j];
                    if (Enumerable.Range(1, cellsForWin - 1)
                        .All(col => _board.Lattice[i + col, j - col] == firstChar))
                        return true;
                }

            return false;
        }
    }
}
