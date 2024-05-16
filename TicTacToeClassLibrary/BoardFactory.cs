namespace TicTacToeClassLibrary;
public class BoardFactory : IBoardFactory
{
    public Board Create(string board)
    {
        switch (board)
        {
            case "4x4":
                return new Board4();
            case "3x3":
            default:
                return new Board3();
        }
    }
}
