namespace TicTacToeClassLibrary.Boards
{
    public abstract class Board
    {
        public string[,] Lattice { get; set; }
        public int CellForWin { get; set; } = 0;

        //метод виведення змісту
        public void Print()
        {
            const char horizontalLine = '─';
            const char verticalLine = '│';
            const char crossLine = '┼';

            int sideSize = Lattice.GetLength(0);
            int symbolSize = Lattice[Lattice.GetLength(0) - 1, Lattice.GetLength(1) - 1].Length;

            Console.WriteLine();

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    Console.Write(Lattice[i, j].PadRight(symbolSize+1).PadLeft(symbolSize+2));
                    if (j != sideSize - 1)
                        Console.Write(verticalLine);
                }
                Console.WriteLine();

                if (i != sideSize - 1)
                    for (int j = 0; j < sideSize; j++)
                    {
                        Console.Write(new string(horizontalLine, symbolSize + 2));
                        if (j != sideSize - 1)
                            Console.Write(crossLine);
                    }
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public void WriteSign(int position, string sign)
        {
            int rowIndex = --position / Lattice.GetLength(0);
            int columnIndex = position % Lattice.GetLength(1);

            if (int.TryParse(Lattice[rowIndex, columnIndex], out _))
                Lattice[rowIndex, columnIndex] = sign;
            else
                throw new Exception("The cell is already occupied. Please choose another.");
        }

        public IMemento MakeSnapshot()
        {
            return new BoardMemento(Lattice);
        }

        public void Restore(IMemento memento)
        {
            if (memento is not BoardMemento)
                throw new Exception("Unknown memento class " + memento.ToString());

            Lattice = memento.GetState();
        }
    }
}
