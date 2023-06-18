using ConsoleClient.Task;
using SlotEngine.Helper;

namespace ConsoleClient.Command
{
    internal class ReelGeneratorCommand : ICommand
    {
        public void Execute()
        {
            ReelGenerator rc = new ReelGenerator();
            rc.Generate();
        }
    }
}
