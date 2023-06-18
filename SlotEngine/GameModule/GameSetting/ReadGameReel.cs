using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace SlotEngine.GameModule.GameSetting
{
    public class ReadGameReel
    {
        public GameReel ReadFile()
        {
            string jsonFromFile = File.ReadAllText(@"config\gamereel.json");

            var gameReel = JsonConvert.DeserializeObject<GameReel>(jsonFromFile)!;

            return gameReel;
        }
    }
}
