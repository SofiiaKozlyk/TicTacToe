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
            this._state = new string[state.GetLength(0), state.GetLength(1)];
            Array.Copy(state, this._state, state.Length);
        }
        public string[,] GetState()
        {
            return this._state;
        }
    }
}
