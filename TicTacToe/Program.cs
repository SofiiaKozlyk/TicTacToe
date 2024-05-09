using TicTacToeClassLibrary;

/*Board board = new Board4();
board.Print();*/
TicTacToe game = new TicTacToe();
while (true)
{
    game.WriteSign(int.Parse(Console.ReadLine()));
}