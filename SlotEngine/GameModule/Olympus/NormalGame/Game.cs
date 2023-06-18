using SlotEngine.GameModule.GameSetting;
using SlotEngine.GameModule.Olympus.NormalGameSetting;
using SlotEngine.Services;

namespace SlotEngine.GameModule.Olympus.NormalGame
{
    public class Game
    {
        private const int WinHeight = 5;
        private readonly GameReel _originalGameReel;
        private readonly PayTable _payTable;
        private readonly IRandomService _randomService;

        public bool Verbose {get;init; } = true;

        /// <summary>
        /// 產生一場game的結果
        /// </summary>
        /// <param name="randomService"></param>
        /// <param name="originalGameReel"></param>
        /// <param name="payTable"></param>
        public Game(IRandomService randomService, 
                    GameReel? originalGameReel,
                    PayTable? payTable){

            _originalGameReel = PrepareGameReel(originalGameReel);
            _payTable = PreparePayTable(payTable);
            _randomService = randomService;

        }

        /// <summary>
        /// 準備PayTable Object
        /// </summary>
        /// <param name="payTable"></param>
        /// <returns></returns>
        private PayTable PreparePayTable(PayTable? payTable)
        {
            PayTable result;

            if (payTable == null)
            {
                ReadPayTable readPayTable = new();
                result = readPayTable.ReadFile();
            }
            else
            {
                result = payTable;
            }
            return result;
        }

        /// <summary>
        /// 準備原始的GameReel Object
        /// </summary>
        /// <param name="originalGameReel"></param>
        /// <returns></returns>
        private GameReel PrepareGameReel(GameReel? originalGameReel)
        {
            GameReel result;
            if (originalGameReel == null)
            {
                ReadGameReel readGameReel = new();
                result = readGameReel.ReadFile();
            }
            else
            {
                result = originalGameReel;
            }
            return result;
        }

        /// <summary>
        /// 執行一次旋轉
        /// </summary>
        public GameResult Spin(decimal stake = 0)
        {
            var gameResult = new GameResult
            {
                Verbose = Verbose,
                Stake = stake
            };

            var gameReel = MakeGameReel(_originalGameReel, _originalGameReel);
            var isContinue = true;
            var runTimes = 0;

            while(isContinue){
                runTimes++;
                if(Verbose) Console.WriteLine("Run Times:" + runTimes);

                var gameRound = new GameRound
                {
                    Verbose = Verbose
                };

                if (runTimes == 1) gameResult.ReelPos = GenerateReelPos();

                var windowData = GetWindowData(gameReel, gameResult.ReelPos);
                gameRound.WindowData = windowData;

                var symbolCountCollection = CountSymbols(windowData);
                gameRound.WinningItems = CalculateWinningItems(symbolCountCollection, _payTable);

                var _ = CountRemovedSymbolInReels(gameRound.WinningItems, windowData);
                RemoveSymbolInReels(gameReel, gameResult.ReelPos, gameRound.WinningItems);

                gameReel = MakeGameReel(gameReel, _originalGameReel);
                isContinue = CheckIsContinue(gameRound);

                gameResult.GameRounds.Add(gameRound);
            }

            return gameResult;
        }

        private bool CheckIsContinue(GameRound gameRound)
        {
            bool isContinue = gameRound.WinningItems.Count > 0;
            if (Verbose) Console.WriteLine("Win?" + isContinue);

            return isContinue;
        }


        /// <summary>
        /// 把Reel的Symbol消除
        /// </summary>
        /// <param name="gameReel"></param>
        /// <param name="reelPos"></param>
        /// <param name="winningItems"></param>
        private void RemoveSymbolInReels(GameReel gameReel, List<int> reelPos, Dictionary<string, decimal> winningItems)
        {
            for(var reelIndex=0; reelIndex<gameReel.ReelSymbols.Count; reelIndex++)
            {
                var startPos = reelPos[reelIndex];

                for(int relativePos= WinHeight - 1; relativePos>=0; relativePos--)
                {
                    string symbol = gameReel.ReelSymbols[reelIndex][startPos + relativePos];

                    if (winningItems.ContainsKey(symbol))
                    {
                        gameReel.ReelSymbols[reelIndex].RemoveAt(startPos + relativePos);
                    }
                }
            }
        }

        /// <summary>
        /// 依windowPayout裡有的Symbol, 從reelWindow計算每個輪軸要消除的個數
        /// </summary>
        /// <param name="windowPayout"></param>
        /// <param name="reelWindow"></param>
        /// <returns></returns>
        private List<int> CountRemovedSymbolInReels(Dictionary<string, decimal> windowPayout, GameReel reelWindow)
        {
            List<int> trumbleCount = new();

            foreach(var reel in reelWindow.ReelSymbols)
            {
                var count = 0;
                foreach(var symbol in reel) {
                    if(windowPayout.ContainsKey(symbol))
                    {
                        count++;
                    }
                }
                trumbleCount.Add(count);
            }

            return trumbleCount;
        }

        /// <summary>
        /// 依PayTable, 找出有中的Symbol, 並計算Payout
        /// </summary>
        /// <param name="symbolCountCollection"></param>
        /// <param name="payTable"></param>
        /// <returns>中獎的Symbol與賠倍</returns>
        private Dictionary<string, decimal> CalculateWinningItems(Dictionary<string, int> symbolCountCollection, PayTable payTable)
        {
            Dictionary<string, decimal> payoutCollection = new Dictionary<string, decimal>();

            foreach(var symbol in symbolCountCollection.Keys)
            {
                var symbolCount = symbolCountCollection[symbol];
                var payout = payTable.Items[symbol].PayOut[symbolCount - 1]; 
                if(payout > 0){
                    payoutCollection.Add(symbol, payout);
                }
            }

            return payoutCollection;
        }

        /// <summary>
        /// 加總盤面上每個Symbol個數
        /// </summary>
        /// <param name="reelWindow"></param>
        /// <returns></returns>
        private Dictionary<string, int> CountSymbols(GameReel reelWindow)
        {
            Dictionary<string, int> result = new();

            foreach (var reel in reelWindow.ReelSymbols)
            {
                foreach(var symbol in reel)
                {
                    if (result.ContainsKey(symbol))
                    {
                        result[symbol]++;
                    }
                    else
                    {
                        result.Add(symbol, 1);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 依傳入的輪軸內容和停止位置取得盤面
        /// </summary>
        /// <param name="gameReel">輪軸內容</param>
        /// <param name="reelPos">停止位置</param>
        /// <returns>顯示給玩家看的輪軸內容</returns>
        private GameReel GetWindowData(GameReel gameReel, List<int> reelPos)
        {
            var reelIndex = 0;  //取第X個輪軸的資料
            var windowsData = new GameReel();

            foreach (var reel in gameReel.ReelSymbols)
            {
                var startPos = reelPos[reelIndex++];
                var range = reel.GetRange(startPos, WinHeight);
                windowsData.ReelSymbols.Add(range);
            }

            return windowsData;
        }

        /// <summary>
        /// 每次Spin時,都要重新產生, 讓盤面消除時有從尾部接續輪軸的效果
        /// 檢查currentGameReel的輪軸, 如果Symbol個數不夠時, 就要拿originalGameReel的內容添加上去, 避免消除後輪軸Symbol個數不足
        /// </summary>
        private GameReel MakeGameReel(GameReel currentGameReel, GameReel originalGameReel)
        {
            var cloneGameReel = new GameReel();

            for (int reelIndex = 0; reelIndex < currentGameReel.ReelSymbols.Count; reelIndex++)
            {
                var list1 = new List<string>(currentGameReel.ReelSymbols[reelIndex]);
                var list2 = new List<string>(originalGameReel.ReelSymbols[reelIndex]);
                //如果目前的輪軸所剩Symbol個數 < 原始輪軸Symbol個數+顯示視窗顯示Symbol個數
                //就加長該輪軸
                if (currentGameReel.ReelSymbols[reelIndex].Count < originalGameReel.ReelSymbols[reelIndex].Count + WinHeight)
                {
                    cloneGameReel.ReelSymbols.Add(list1.Concat(list2).ToList());
                    if (Verbose) Console.WriteLine($"Extend Reel{reelIndex}");
                }
                else
                {
                    cloneGameReel.ReelSymbols.Add(list1);
                }
            }

            PrintReelWindow(cloneGameReel);

            return cloneGameReel;
        }
        
        /// <summary>
        /// 產生輪軸停止的位置
        /// </summary>
        /// <returns></returns>
        private List<int> GenerateReelPos()
        {
            List<int> reelPos = new();

            foreach (var reel in _originalGameReel.ReelSymbols)
            {
                var oneReelPos = _randomService.GenerateRandomNumbers(1, 0, reel.Count)[0];

                reelPos.Add(oneReelPos);
            }

            return reelPos;
        }

        private void PrintReelWindow(GameReel gameReel)
        {
            if (Verbose)
            {
                foreach (var reel in gameReel.ReelSymbols)
                {
                    reel.ForEach(symbol => Console.Write($" {symbol}"));
                    Console.WriteLine();
                }
            }
        }
    }
}
