using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public interface IBoardFactory
    {
        public Board Create(string board);
    }
}
