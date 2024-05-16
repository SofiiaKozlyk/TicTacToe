namespace TicTacToeClassLibrary;
public class Player
{
    public string Name { get; set; }
    public string Sign { get; set; }
    public int Score { get; set; }
    public Player(string name, string sign, int score)
    {
        Name = name;
        Sign = sign;
        Score = score;
    }
    public void PrintPlayerInfo()
    {
        Console.WriteLine($"{Name}: {Sign}, Score: {Score}");
    }
}
