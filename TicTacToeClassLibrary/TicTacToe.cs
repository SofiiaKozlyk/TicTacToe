﻿using TicTacToeClassLibrary.Boards;
using TicTacToeClassLibrary.Command;

namespace TicTacToeClassLibrary
{
    public class TicTacToe
    {
        private List<IMemento> _mementos;
        private readonly IBoardFactory _boardFactory;

        public Board TicTacToeBoard { get; private set; }
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        public Player CurrentPlayer { get; private set; }

        public TicTacToe()
        {
            _boardFactory = new BoardFactory();
            TicTacToeBoard = CreateBoard();
            InitializePlayers();
            PrintGameInfo();
        }

        public void SwitchCurrentPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }

        public void WriteSign(int position)
        {
            if (position > 0 && position <= TicTacToeBoard.Lattice.GetLength(0) * TicTacToeBoard.Lattice.GetLength(0))
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

        public Board CreateBoard()
        {
            Console.WriteLine("Please select a board type (3x3, 4x4, 5x5):");

            string boardType = Console.ReadLine();
            Board board = _boardFactory.Create(boardType);
            _mementos = new List<IMemento>();

            return board;
        }

        public void InitializePlayers()
        {
            Console.WriteLine("Enter the name of the first player:");
            Player1 = new Player(Console.ReadLine(), "x", 0);

            Console.WriteLine("Enter the name of the second player:");
            Player2 = new Player(Console.ReadLine(), "o", 0);

            CurrentPlayer = Player1;
        }

        public void PrintPlayersInfo()
        {
            Player1.PrintPlayerInfo();
            Player2.PrintPlayerInfo();
        }

        public void Play()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (input.Equals("u"))
                {
                    Undo();
                    continue;
                }
                else
                {
                    try
                    {
                        WriteSign(int.Parse(input));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message + " Input correct value please:");
                    }
                }

                if (IsRoundEnd())
                {
                    Console.WriteLine("Do you want to play again? (y/n)");

                    if (Console.ReadLine() == "y")
                    {
                        TicTacToeBoard = CreateBoard();
                        PrintGameInfo();
                        continue;
                    }

                    Console.Clear();
                    PrintPlayersInfo();
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
            PrintPlayersInfo();
            Console.WriteLine($"It's {CurrentPlayer.Name}'s turn. Please select an empty cell (u - Undo)");
            TicTacToeBoard.Print();
        }

        public bool IsRoundEnd()
        {
            var checkers = new List<Check>
            {
                new CheckRows(TicTacToeBoard),
                new CheckColumns(TicTacToeBoard),
                new CheckDiagonals(TicTacToeBoard)
            };

            if (new CheckWin(checkers).Win())
            {
                Player winner = (CurrentPlayer == Player1) ? Player2 : Player1;
                winner.Score++;

                Console.WriteLine($"{winner.Name} wins.");

                return true;
            }

            if (HasNoNumericElement())
            {
                Console.WriteLine("Game draw.");

                return true;
            }

            return false;
        }

        protected bool HasNoNumericElement() =>
            !TicTacToeBoard.Lattice.Cast<string>().Any(element => int.TryParse(element, out _));
    }
}
