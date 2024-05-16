namespace TicTacToeClassLibrary;
public abstract class Board
{
    public string[,] Lattice { get; set; }
    //метод виведення змісту
    protected void InitializeLattice(int sideSize)
    {
        Lattice = new string[sideSize, sideSize];
        int count = 1;
        for (int i = 0; i < sideSize; i++)
        {
            for (int j = 0; j < sideSize; j++)
            {
                Lattice[i, j] = count.ToString().PadLeft(2, '0');
                count++;
            }
        }
    }

    public void Print()
    {
        int sideSize = Lattice.GetLength(0);

        for (int i = 0; i < sideSize; i++)
        {
            for (int j = 0; j < sideSize; j++)
            {
                Console.Write(" " + Lattice[i, j].PadRight(3));
                if (j < sideSize - 1)
                {
                    Console.Write("|");
                }
            }
            Console.WriteLine();

            if (i < sideSize - 1)
            {
                for (int k = 0; k < sideSize * 4 - 1; k++)
                {
                    Console.Write("-");
                }
                Console.WriteLine();
            }
        }
    }



    public void WriteSign(int position, string sign)
    {
        int rowIndex = --position / Lattice.GetLength(0);
        int columnIndex = position % Lattice.GetLength(1);
        if (int.TryParse(Lattice[rowIndex, columnIndex], out _))
        {
            Lattice[rowIndex, columnIndex] = sign;
        }
        else
        {
            throw new Exception("The cell is already occupied. Please choose another.");
        }
    }
    public IMemento MakeSnapshot()
    {
        return new BoardMemento(Lattice);
    }
    public void Restore(IMemento memento)
    {
        if (memento is not BoardMemento)
        {
            throw new Exception("Unknown memento class " + memento.ToString());
        }

        Lattice = memento.GetState();
    }
}
