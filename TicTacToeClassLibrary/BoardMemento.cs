using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class BoardMemento : IMemento
    {
        private string[,] _state;

        public BoardMemento(string[,] state)
        {
            _state = CopyState(state);
        }

        public string[,] GetState()
        {
            return _state;
        }

        private string[,] CopyState(string[,] state)
        {
            int rows = state.GetLength(0);
            int columns = state.GetLength(1);
            string[,] copy = new string[rows, columns];
            Array.Copy(state, copy, state.Length);
            return copy;
        }
    }
}
