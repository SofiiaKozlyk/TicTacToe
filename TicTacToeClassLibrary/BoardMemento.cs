namespace TicTacToeClassLibrary;
public class BoardMemento : IMemento
{
    private readonly string[,] _state;
    public BoardMemento(string[,] state)
    {
        _state = new string[state.GetLength(0), state.GetLength(1)];
        Array.Copy(state, _state, state.Length);
    }
    public string[,] GetState()
    {
        return _state;
    }
}
