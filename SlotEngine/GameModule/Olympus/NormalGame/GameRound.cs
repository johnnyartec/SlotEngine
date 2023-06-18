using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace SlotEngine.GameModule.Olympus.NormalGame
{
    /// <summary>
    /// 一個回合的資料
    /// </summary>
    public class GameRound
    {
        /*
        private List<int> _reelPos = new();
        public List<int> ReelPos
        {
            get => _reelPos;
            set
            {
                _reelPos = value;
                if (Verbose)
                {
                    _reelPos.ForEach(pos => Console.WriteLine("pos=" + pos));
                }
            }
        }
        */
        private GameReel _windowData = new();
        //中獎的Symbol, 中獎個數
        private Dictionary<string, decimal> _winningItems = new();

        public bool Verbose{get;set;}
        public decimal Payout{get; private set;}


        public GameReel WindowData { 
            get => _windowData; 
            set{
                _windowData = value;
                if (Verbose)
                {
                    PrintReelWindow(_windowData);
                }
            }
        }

        public Dictionary<string, decimal> WinningItems {
            get => _winningItems; 
            set{
                _winningItems = value;
                Payout = _winningItems.Values.Sum();
                if (Verbose)
                {
                    PrintPayout(_winningItems);
                }
            }
        }

        private void PrintPayout(Dictionary<string, decimal> windowPayout)
        {
            foreach(var symbol in windowPayout.Keys)
            {
                Console.WriteLine($"Symbol {symbol} win {windowPayout[symbol]}");
            }
        }

        private void PrintReelWindow(GameReel reelWindow)
        {
            foreach(var reel in reelWindow.ReelSymbols)
            {
                reel.ForEach(symbol => Console.Write($" {symbol}"));
                Console.WriteLine();
            }
        }
    }
}
