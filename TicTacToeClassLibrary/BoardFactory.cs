using TicTacToeClassLibrary.Boards;

namespace TicTacToeClassLibrary
{
    public class BoardFactory : IBoardFactory
    {
        public Board Create(string board)
        {
            switch (board)
            {
                case "5x5":
                case "3":
                    return new Board5();
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
