using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public abstract class Board
    {
        public string[,] Lattice { get; set; }
        //метод виведення змісту
        public void Print() 
        {
            int sideSize = this.Lattice.GetLength(0);

            for (int i = 0; i < sideSize; i++)
            {
                for (int j = 0; j < sideSize; j++)
                {
                    Console.Write(this.Lattice[i, j]);
                    Console.Write(" | ");
                }
                Console.WriteLine();

                for (int k = 0; k < sideSize; k++)
                {
                    for (int l = 0; l < sideSize; l++)
                    {
                        Console.Write("-");
                    }
                    Console.Write(" ");
                }
                Console.WriteLine();
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
            if (!(memento is BoardMemento))
            {
                throw new Exception("Unknown memento class " + memento.ToString());
            }

            Lattice = memento.GetState();
        }
    }
}
