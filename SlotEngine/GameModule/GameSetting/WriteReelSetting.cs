using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using Formatting = Newtonsoft.Json.Formatting;

namespace SlotEngine.GameModule.GameSetting
{
    public class WriteReelSetting
    {
        public void WriteFile()
        {
            var reelSetting = PrepareReelSetting();

            // 將 Paytable 物件轉換成 JSON 格式的字串
            var json = JsonConvert.SerializeObject(reelSetting, Formatting.Indented);

            // 將 JSON 字串寫入到檔案中
            const string path = @"config\reelsetting.json";
            File.WriteAllText(path, json);

            Console.WriteLine($"ReelSetting has been saved to {path}");
        }

        private static ReelSetting PrepareReelSetting()
        {
            ReelSetting reelSetting = new ReelSetting();

            Dictionary<string, int> reelSettingItem = new()
            {
                {"A1", 60},
                {"A2", 25},
                {"A3", 10},
                {"A4", 3},
                {"A5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"B1", 65},
                {"B2", 30},
                {"B3", 15},
                {"B4", 3},
                {"B5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"C1", 70},
                {"C2", 35},
                {"C3", 15},
                {"C4", 3},
                {"C5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"D1", 75},
                {"D2", 40},
                {"D3", 18},
                {"D4", 3},
                {"D5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"E1", 80},
                {"E2", 45},
                {"E3", 18},
                {"E4", 3},
                {"E5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"F1", 90},
                {"F2", 50},
                {"F3", 18},
                {"F4", 3},
                {"F5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"G1", 100},
                {"G2", 52},
                {"G3", 20},
                {"G4", 3},
                {"G5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            reelSettingItem = new Dictionary<string, int>
            {
                {"H1", 150},
                {"H2", 60},
                {"H3", 20},
                {"H4", 3},
                {"H5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);


            reelSettingItem = new Dictionary<string, int>
            {
                {"I1", 200},
                {"I2", 70},
                {"I3", 20},
                {"I4", 3},
                {"I5", 1}
            };
            reelSetting.SymbolSettings.Add(reelSettingItem);

            return reelSetting;
        }
    }
}
