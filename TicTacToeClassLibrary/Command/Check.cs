using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary.Command
{
    public abstract class Check
    {
        protected readonly Board _board;
        protected string firstChar;

        protected Check(Board board)
        {
            _board = board;
        }

        public abstract bool PerformCheck();
    }
}
