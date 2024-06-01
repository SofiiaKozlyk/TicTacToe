namespace TicTacToeClassLibrary.Boards
{
    internal sealed class Board3 : Board
    {
        public Board3()
        {
            Lattice = new string[,] 
            {
                { "1", "2", "3" },
                { "4", "5", "6" },
                { "7", "8", "9" } 
            };
        }
    }
}
