namespace TicTacToeClassLibrary
{
    public class Player
    {
        public string Name { get; private set; }
        public string Sign { get; private set; }
        public int Score { get; set; }

        public Player(string name, string sign, int score)
        {
            Name = name;
            Sign = sign;
            Score = score;
        }

        public void PrintPlayerInfo() =>
            Console.WriteLine($"{Name}, Sign: {Sign}, Score: {Score}");
    }
}
