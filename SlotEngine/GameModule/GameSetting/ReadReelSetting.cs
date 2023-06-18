using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace SlotEngine.GameModule.GameSetting
{
    public class ReadReelSetting
    {
        public ReelSetting ReadFile()
        {
            string jsonFromFile = File.ReadAllText(@"config\reelsetting.json");

            var reelSetting = JsonConvert.DeserializeObject<ReelSetting>(jsonFromFile)!;

            return reelSetting;
        }
    }
}
