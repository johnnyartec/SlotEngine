using SlotEngine.GameModule.GameSetting;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using SlotEngine.Services;

namespace SlotEngine.Helper
{
    /// <summary>
    /// 用來產生輪軸資料
    /// 要有連續個數
    /// 產生一組輪軸, 放在6個Reel?還是不同Reel的輪軸都不同?
    /// 
    /// 輪軸跟倍數產生方式分開
    /// 倍數產生在不影響原來中獎金額的位置
    /// 
    /// 要固定軸輪
    /// 每個Symbol要區分連續出現1-5個的機率
    /// 
    /// 假定一個輪軸有1000個Symbol
    /// 如何放置不同的Symbol
    /// 
    /// 1.真的Scatter放的位置, 前後4個位置都不能是Scatter
    /// 2.同一個Symbol可以連續出現, 用不同子Symbol來控制串連, 不同子Symbol也可控制連續出現的機率
    /// 3.Scatter如果同一個Reel已有出現, 要判斷是否會出現一個以上, 如果有的話, 要移掉, 放置時分散放
    /// </summary>
    public class ReelGenerator
    {
        public List<string> Generate()
        {
            ReelSetting reelSetting = GetReelSetting();

            Dictionary<string, int> allSymbolSet = GetAllSymbols(reelSetting);

            //將預計產生的Symbol打散到spreadSymbols List
            var spreadSymbols = GenerateSymbolList(allSymbolSet);

            //虛擬Symbol的數目
            var symbolSetCount = allSymbolSet.Sum(x => x.Value);
            Console.WriteLine($"SymbolSet Count = {symbolSetCount}");

            //產生儲存最終輪軸的List
            IRandomService rs = new RandomService();

            var shuffledSymbols = ShuffleHelper.Shuffle(spreadSymbols);
            foreach (string symbol in shuffledSymbols) {
                Console.Write(symbol + " ");
            }

            Console.WriteLine();
            var flatSymbols = ShuffleHelper.FlatSymbol(shuffledSymbols);

            foreach (string symbol in flatSymbols) {
                Console.Write(symbol + " ");
            }

            return flatSymbols;
        }

        /// <summary>
        /// 將Symbol Dictionary展開成Symbol List
        /// </summary>
        /// <param name="allSymbolSet"></param>
        private List<string> GenerateSymbolList(Dictionary<string, int> allSymbolSet)
        {
            List<string> spreadSymbols = new List<string>();

            foreach (var symbolSet in allSymbolSet.Keys)
            {
                for (var i = 0; i < allSymbolSet[symbolSet]; i++)
                {
                    spreadSymbols.Add(symbolSet);
                }

            }
            Console.WriteLine($"spreadSymbols Count = {spreadSymbols.Count}");

            return spreadSymbols;
        }

        /// <summary>
        /// 取得下一個合法的Index
        /// </summary>
        /// <param name="reels"></param>
        /// <param name="searchIndex"></param>
        /// <returns></returns>
        private static int GetNextSearchIndex(List<string> reels, int searchIndex)
        {
            if (searchIndex == reels.Count - 1)  //已經是最後一個
            {
                searchIndex = 0;  //移到最前面
            }
            else
            {
                searchIndex++;
            }

            return searchIndex;
        }

        /// <summary>
        /// 將ReelSetting裡各Symbol的設定攤平到一階的Dictionary
        /// </summary>
        /// <param name="reelSetting"></param>
        /// <returns></returns>
        private Dictionary<string, int> GetAllSymbols(ReelSetting reelSetting)
        {
            var allSymbol = new Dictionary<string, int>();

            foreach (var symbolSettings in reelSetting.SymbolSettings)
            {
                foreach (string key in symbolSettings.Keys)
                {
                    allSymbol.Add(key, symbolSettings[key]);
                }
            }

            return allSymbol;
        }

        /// <summary>
        /// 讀取檔案裡的設定
        /// </summary>
        /// <returns></returns>
        private static ReelSetting GetReelSetting()
        {
            var readReelSetting = new ReadReelSetting();

            var reelSetting = readReelSetting.ReadFile()!;
            return reelSetting;
        }
    }
}
