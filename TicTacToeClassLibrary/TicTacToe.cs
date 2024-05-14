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
        private IBoardFactory _boardFactory;
        public Board TicTacToeBoard { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }
        public TicTacToe()
        {
            _boardFactory = new BoardFactory();
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

        private int lastRow;
        private int lastCol;

        public void WriteSign(int position)
        {
            if (position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0))
            {
                lastRow = (position - 1) / TicTacToeBoard.Lattice.GetLength(0);
                lastCol = (position - 1) % TicTacToeBoard.Lattice.GetLength(1);

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
            Board board = _boardFactory.Create(boardType);
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
            _mementos.Add(TicTacToeBoard.MakeSnapshot());
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
            if (CheckWinning(lastRow, lastCol))
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

        protected bool HasNoNumericElement()
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
        protected bool CheckWinning(int lastRow, int lastCol)
        {
            return CheckRow(lastRow) || CheckColumn(lastCol) ||
                   (lastRow == lastCol && CheckMainDiagonal()) ||
                   (lastRow + lastCol == TicTacToeBoard.Lattice.GetLength(0) - 1 && CheckSideDiagonal());
        }

        private bool CheckRow(int row)
        {
            string firstElement = TicTacToeBoard.Lattice[row, 0];
            for (int col = 1; col < TicTacToeBoard.Lattice.GetLength(1); col++)
            {
                if (TicTacToeBoard.Lattice[row, col] != firstElement)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckColumn(int col)
        {
            string firstElement = TicTacToeBoard.Lattice[0, col];
            for (int row = 1; row < TicTacToeBoard.Lattice.GetLength(0); row++)
            {
                if (TicTacToeBoard.Lattice[row, col] != firstElement)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckMainDiagonal()
        {
            string firstElement = TicTacToeBoard.Lattice[0, 0];
            for (int i = 1; i < TicTacToeBoard.Lattice.GetLength(0); i++)
            {
                if (TicTacToeBoard.Lattice[i, i] != firstElement)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckSideDiagonal()
        {
            string firstElement = TicTacToeBoard.Lattice[0, TicTacToeBoard.Lattice.GetLength(0) - 1];
            for (int i = 1; i < TicTacToeBoard.Lattice.GetLength(0); i++)
            {
                if (TicTacToeBoard.Lattice[i, TicTacToeBoard.Lattice.GetLength(0) - 1 - i] != firstElement)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

