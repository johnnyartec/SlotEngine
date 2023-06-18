namespace SlotEngine.GameModule.Olympus.NormalGame
{
    public class GameResult
    {
        private List<int> _reelPos = new();

        public string GameNo { get; set; } = string.Empty;
        public decimal Stake { get; set; }
        public decimal TotalWin  {
            get
            {
                return Stake * GameRounds.Sum(gr => gr.Payout);
            }
        }
        public int TotalRound => GameRounds.Count;
        public List<GameRound> GameRounds { get; set; } = new();

        public bool Verbose { get; set; } 
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
    }
}
