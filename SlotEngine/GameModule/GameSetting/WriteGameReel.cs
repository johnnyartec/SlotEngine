using Newtonsoft.Json;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using SlotEngine.Helper;

namespace SlotEngine.GameModule.GameSetting
{
    public class WriteGameReel
    {
        public void WriteFile()
        {
            GameReel gameReel = PrepareData();

            // 將 Paytable 物件轉換成 JSON 格式的字串
            var json = JsonConvert.SerializeObject(gameReel, Formatting.Indented);

            // 將 JSON 字串寫入到檔案中
            var path = @"config\gamereel.json";
            File.WriteAllText(path, json);

            Console.WriteLine($"GameReel has been saved to {path}");
        }

        private GameReel PrepareData()
        {
            //產生6個輪軸的Reel資料
            GameReel gameReel = new GameReel();
            ReelGenerator reelGenerator = new ReelGenerator();

            for(int i=0; i< 6; i++){
                List<string> oneReel = reelGenerator.Generate();
                gameReel.ReelSymbols.Add(oneReel);
            }
            return gameReel;
        }
    }
}
