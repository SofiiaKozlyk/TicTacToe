using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary
{
    public interface IBoardFactory
    {
        public Board Create(string board);
    }
}
