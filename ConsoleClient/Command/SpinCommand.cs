using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGame;
using SlotEngine.Services;

namespace ConsoleClient.Command
{
    internal class SpinCommand : ICommand
    {
        public void Execute()
        {
            IRandomService randomService = new RandomService();
            Game g = new Game(randomService, null, null);
            GameResult gr = g.Spin(1);
            string result = JsonConvert.SerializeObject(gr);
            Console.WriteLine(result);
        }
    }
}
