using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeClassLibrary
{
    public class TicTacToe
    {
        private List<IMemento> _mementos;
        private ICreateBoard _createBoard;
        public Board TicTacToeBoard { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public TicTacToe()
        {
            _createBoard = new CreateBoard();
            TicTacToeBoard = Create();
            Console.WriteLine("Enter the name of the first player: ");
            Player1 = new Player(Console.ReadLine(), "x", 0);
            Console.WriteLine("Enter the name of the second player: ");
            Player2 = new Player(Console.ReadLine(), "o", 0);
            CurrentPlayer = Player1;
            PrintGameInfo();
        }
        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;
        }

        public void WriteSign(int position)
        {
            if(position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0))
            {
                Save();
                TicTacToeBoard.WriteSign(position, CurrentPlayer.Sign);
                SwitchCurrentPlayer();
                PrintGameInfo();
            }
            else
            {
                throw new Exception("There is no cell with this position.");
            }
        }

        public Board Create()
        {
            Console.WriteLine("Please select a board type (3x3, 4x4)");
            string boardType = Console.ReadLine();
            Board board = _createBoard.Create(boardType);
            _mementos = new List<IMemento>();
            return board;
        }

        public void Play()
        {
            while (true)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "u":
                        Undo();
                        break;
                    default:
                        try
                        {
                            WriteSign(int.Parse(input));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message + " Press any key to continue...");
                        }
                        break;
                }
                if (IsRoundEnd())
                {
                    Console.WriteLine("Do you want to play again? (y/n)");
                    if (Console.ReadLine() == "y")
                    {
                        TicTacToeBoard = Create();
                        PrintGameInfo();
                        continue;
                    }
                    Console.Clear();
                    Player1.PrintPlayerInfo();
                    Player2.PrintPlayerInfo();
                    break;
                }
            }
        }

        public void Save()
        {
            _mementos.Add(TicTacToeBoard.makeSnapshot());
        }
        public void Undo()
        {
            if (_mementos.Count == 0)
            {
                Console.WriteLine("Undo: No previous content saved.");
                return;
            }
            var memento = _mementos.Last();
            _mementos.Remove(memento);
            TicTacToeBoard.Restore(memento);
            SwitchCurrentPlayer();
            PrintGameInfo();
        }

        public void PrintGameInfo()
        {
            Console.Clear();
            Player1.PrintPlayerInfo();
            Player2.PrintPlayerInfo();
            Console.WriteLine($"It's {CurrentPlayer.Name}'s turn. Please select an empty cell (u - Undo)");
            TicTacToeBoard.Print();
        }

        public bool IsRoundEnd()
        {
            if (CheckWinning())
            {
                Player winner = CurrentPlayer == Player1 ? Player2 : Player1;
                winner.Score++;
                Console.WriteLine($"{winner.Name} wins");
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
            if(CheckRows() || CheckCols() || CheckDiagonals())
            {
                return true;
            }

            return false;
        }

        public bool CheckRows()
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
            return false;
        }
        public bool CheckCols()
        {
            bool allSame = true;

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

            return false;
        }
        public bool CheckDiagonals()
        {
            bool allSame = true;

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
