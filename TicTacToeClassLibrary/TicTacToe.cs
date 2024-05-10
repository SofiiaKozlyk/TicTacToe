using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class TicTacToe
    {
        public Board TicTacToeBoard { get; set; }
        public string CurrentPlayer { get; set; }
        public TicTacToe()
        {
            TicTacToeBoard = new Board3();
            CurrentPlayer = "x";
            TicTacToeBoard.Print();
        }
        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == "x" ? "o" : "x";
        }

        public void WriteSign(int position)
        {
            if(position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0))
            {
                TicTacToeBoard.WriteSign(position, CurrentPlayer);
                SwitchCurrentPlayer();
                TicTacToeBoard.Print();
            }
            else
            {
                throw new Exception("There is no cell with this position.");
            }
        }

        public void Play()
        {
            while (true)
            {
                WriteSign(int.Parse(Console.ReadLine()));
                if (IsRoundEnd())
                {
                    break;
                }
            }
        }

        public bool IsRoundEnd()
        {
            if (CheckWinning())
            {
                Console.WriteLine("Win");
                return true;
            }
            if (HasNoNumericElement())
            {
                Console.WriteLine("Game draw");
                return true;
            }

            return false;
        }
        public bool HasNoNumericElement()
        {
            foreach (var element in TicTacToeBoard.Lattice)
            {
                if (int.TryParse(element, out _))
                {
                    return false;
                }
            }

            return true; 
        }

        public bool CheckWinning()
        {
            bool allSame = true;

            for (int row = 0; row < TicTacToeBoard.Lattice.GetLength(0); row++)
            {
                string firstChar = TicTacToeBoard.Lattice[row, 0];

                allSame = true;

                for (int col = 1; col < TicTacToeBoard.Lattice.GetLength(1); col++)
                {
                    if (TicTacToeBoard.Lattice[row, col] != firstChar)
                    {
                        allSame = false;
                        break;
                    }
                }

                if (allSame)
                {
                    return true;
                }
            }

            for (int col = 0; col < TicTacToeBoard.Lattice.GetLength(1); col++)
            {
                string firstChar = TicTacToeBoard.Lattice[0, col]; 

                allSame = true;

                for (int row = 1; row < TicTacToeBoard.Lattice.GetLength(0); row++)
                {
                    if (TicTacToeBoard.Lattice[row, col] != firstChar)
                    {
                        allSame = false;
                        break; 
                    }
                }

                if (allSame)
                {
                    return true;
                }
            }

            int size = TicTacToeBoard.Lattice.GetLength(0); 

            // перший елемент головної діагоналі
            string mainDiagonalElement = TicTacToeBoard.Lattice[0, 0];
            // перший елемент побічної діагоналі
            string sideDiagonalElement = TicTacToeBoard.Lattice[0, size - 1]; 

            allSame = true;

            for (int i = 1; i < size; i++)
            {
                if (TicTacToeBoard.Lattice[i, i] != mainDiagonalElement)
                {
                    allSame = false;
                    break; 
                }
            }
            if (allSame)
            {
                return true;
            }

            allSame = true;
            
            for (int i = 1; i < size; i++)
            {
                if (TicTacToeBoard.Lattice[i, size - 1 - i] != sideDiagonalElement)
                {
                    allSame = false;
                    break; 
                }
            }
            if (allSame)
            {
                return true;
            }

            return false;
        }

    }
}
