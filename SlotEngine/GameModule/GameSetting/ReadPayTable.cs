using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace SlotEngine.GameModule.GameSetting
{
    public class ReadPayTable
    {
        public PayTable ReadFile()
        {
            string jsonFromFile = File.ReadAllText(@"config\paytable.json");

            var payTable = JsonConvert.DeserializeObject<PayTable>(jsonFromFile)!;

            return payTable;
        }
    }
}
