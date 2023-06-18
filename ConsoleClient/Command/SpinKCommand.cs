using Newtonsoft.Json;
using SlotEngine.GameModule.GameSetting;
using SlotEngine.GameModule.Olympus.NormalGame;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using SlotEngine.Services;
using System.Diagnostics;

namespace ConsoleClient.Command
{
    internal class SpinKCommand : ICommand
    {
        public void Execute()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            IRandomService randomService = new RandomService();

            ReadGameReel readGameReel = new();
            GameReel originalGameReel = readGameReel.ReadFile();

            ReadPayTable readPayTable = new();
            PayTable payTable = readPayTable.ReadFile();

            for(int i=0; i<1000; i++){
                Game g = new Game(randomService, originalGameReel, payTable)
                {
                    Verbose = false
                };
                GameResult gr = g.Spin(1);
                //string result = JsonConvert.SerializeObject(gr);
                //Console.WriteLine(result);
            }
            sw.Stop();
            Console.WriteLine($"執行時間：{sw.ElapsedMilliseconds} 毫秒");
        }
    }
}
