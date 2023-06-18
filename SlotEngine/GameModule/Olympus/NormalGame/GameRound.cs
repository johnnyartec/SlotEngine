using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace SlotEngine.GameModule.Olympus.NormalGame
{
    /// <summary>
    /// 一個回合的資料
    /// </summary>
    public class GameRound
    {
        private List<int> _reelPos = new();

        private GameReel _gamePane = new();
        //中獎的Symbol, 中獎個數
        private Dictionary<string, decimal> _hitResult = new();

        public bool Verbose{get;set;}
        public decimal Payout{get; private set;}
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

        public GameReel GamePane { 
            get => _gamePane; 
            set{
                _gamePane = value;
                if (Verbose)
                {
                    PrintReelWindow(_gamePane);
                }
            }
        }

        public Dictionary<string, decimal> HitResult {
            get => _hitResult; 
            set{
                _hitResult = value;
                Payout = _hitResult.Values.Sum();
                if (Verbose)
                {
                    PrintPayout(_hitResult);
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
