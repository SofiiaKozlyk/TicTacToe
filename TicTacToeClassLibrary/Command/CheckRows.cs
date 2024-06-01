using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary.Command
{
    internal class CheckRows : Check
    {
        public CheckRows(Board board) : base(board) { }

        public override bool PerformCheck()
        {
            int cellsForWin = _board.CellForWin == 0 ? _board.Lattice.GetLength(1) : _board.CellForWin;

            for (int i = 0; i < _board.Lattice.GetLength(0); i++)
                for (int j = 0; j < _board.Lattice.GetLength(1) - cellsForWin + 1; j++)
                {
                    firstChar = _board.Lattice[i, j];
                    if (Enumerable.Range(1, cellsForWin - 1)
                        .All(col => _board.Lattice[i, j + col] == firstChar))
                        return true;
                }

            return false;
        }
    }
}
