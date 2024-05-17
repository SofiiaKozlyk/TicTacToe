using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary.Command
{
    public class CheckWin
    {
        private List<Check> Checks;
        public CheckWin(List<Check> checks) { 
            this.Checks = checks;
        }
        public bool Win()
        {
            foreach (Check check in Checks)
            {
                if (check.PerformCheck())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
