namespace TicTacToeClassLibrary.Boards
{
    internal sealed class Board4 : Board
    {
        public Board4()
        {
            Lattice = new string[,] 
            {
                { "01", "02", "03", "04" },
                { "05", "06", "07", "08" },
                { "09", "10", "11", "12" },
                { "13", "14", "15", "16" } 
            };
        }
    }
}
