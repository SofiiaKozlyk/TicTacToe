namespace TicTacToeClassLibrary.Command
{
    public class CheckWin
    {
        private readonly List<Check> _checks;

        public CheckWin(List<Check> checks)
        {
            _checks = checks ?? throw new ArgumentNullException(nameof(checks));
        }

        public bool Win()
        {
            return _checks.Any(check => check.PerformCheck());
        }
    }
}
