using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary.Command
{
    public abstract class Check
    {
        protected readonly Board _board;
        protected string firstChar;

        protected Check(Board board)
        {
            _board = board;
        }

        public abstract bool PerformCheck();
    }
}
