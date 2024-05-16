namespace TicTacToeClassLibrary
{
    public class TicTacToe
    {
        private readonly List<IMemento> _mementos;
        private readonly IBoardFactory _boardFactory;

        public Board TicTacToeBoard { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Player CurrentPlayer { get; set; }

        public TicTacToe()
        {
            _boardFactory = new BoardFactory();
            _mementos = new List<IMemento>();

            TicTacToeBoard = CreateBoard();
            InitializePlayers();
            CurrentPlayer = Player1;
            PrintGameInfo();
        }

        private Board CreateBoard()
        {
            Console.WriteLine("Please select a board type (3x3, 4x4)");
            string boardType = Console.ReadLine();
            return _boardFactory.Create(boardType);
        }

        private void InitializePlayers()
        {
            Console.WriteLine("Enter the name of the first player: ");
            Player1 = new Player(Console.ReadLine(), "x", 0);

            Console.WriteLine("Enter the name of the second player: ");
            Player2 = new Player(Console.ReadLine(), "o", 0);
        }

        public void SwitchCurrentPlayer() => CurrentPlayer = CurrentPlayer == Player1 ? Player2 : Player1;

        public void WriteSign(int position)
        {
            if (IsValidPosition(position))
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

        private bool IsValidPosition(int position) =>
            position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0);

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
                    if (WantsToPlayAgain())
                    {
                        RestartGame();
                        continue;
                    }
                    Console.Clear();
                    PrintPlayersInfo();
                    break;
                }
            }
        }

        private bool WantsToPlayAgain()
        {
            Console.WriteLine("Do you want to play again? (y/n)");
            return Console.ReadLine() == "y";
        }

        private void RestartGame()
        {
            TicTacToeBoard = CreateBoard();
            InitializePlayers();
            PrintGameInfo();
        }

        private void Save() => _mementos.Add(TicTacToeBoard.MakeSnapshot());

        private void Undo()
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
            PrintPlayersInfo();
            Console.WriteLine($"It's {CurrentPlayer.Name}'s turn. Please select an empty cell (u - Undo)");
            TicTacToeBoard.Print();
        }

        private void PrintPlayersInfo()
        {
            Player1.PrintPlayerInfo();
            Player2.PrintPlayerInfo();
        }

        private bool IsRoundEnd()
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

        private bool HasNoNumericElement() =>
            TicTacToeBoard.Lattice.Cast<string>().All(element => !int.TryParse(element, out _));

        private bool CheckWinning() =>
            CheckRows() || CheckCols() || CheckDiagonals();

        private bool CheckRows() => CheckLine(0, 1, true);

        private bool CheckCols() => CheckLine(0, 1, false);

        private bool CheckDiagonals() =>
            CheckDiagonal(0, 0, 1, 1, TicTacToeBoard.Lattice.GetLength(0)) ||
            CheckDiagonal(0, TicTacToeBoard.Lattice.GetLength(0) - 1, 1, -1, TicTacToeBoard.Lattice.GetLength(0));

        private bool CheckLine(int start, int step, bool checkRows)
        {
            for (int i = start; checkRows ? (i < TicTacToeBoard.Lattice.GetLength(0)) : (i < TicTacToeBoard.Lattice.GetLength(1)); i += step)
            {
                string firstChar = checkRows ? TicTacToeBoard.Lattice[i, 0] : TicTacToeBoard.Lattice[0, i];
                bool allSame = true;

                for (int j = 1; checkRows ? (j < TicTacToeBoard.Lattice.GetLength(1)) : (j < TicTacToeBoard.Lattice.GetLength(0)); j++)
                {
                    if (checkRows)
                    {
                        if (TicTacToeBoard.Lattice[i, j] != firstChar)
                        {
                            allSame = false;
                            break;
                        }
                    }
                    else
                    {
                        if (TicTacToeBoard.Lattice[j, i] != firstChar)
                        {
                            allSame = false;
                            break;
                        }
                    }
                }

                if (allSame)
                {
                    return true;
                }
            }

            return false;
        }

        private bool CheckDiagonal(int startX, int startY, int stepX, int stepY, int size)
        {
            string firstElement = TicTacToeBoard.Lattice[startX, startY];
            for (int i = 1; i < size; i++)
            {
                if (TicTacToeBoard.Lattice[startX + i * stepX, startY + i * stepY] != firstElement)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
