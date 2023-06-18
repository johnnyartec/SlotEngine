using ConsoleClient.Task;

namespace ConsoleClient.Command
{
    internal class ReelShuffleCommand : ICommand
    {
        public void Execute()
        {
            var rs = new ReelShuffle();
            ReelShuffle.Shuffle();
        }
    }
}
