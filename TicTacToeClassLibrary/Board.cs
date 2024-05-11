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
        public abstract void Print();
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
