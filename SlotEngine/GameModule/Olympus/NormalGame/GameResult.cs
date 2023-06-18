namespace SlotEngine.GameModule.Olympus.NormalGame
{
    public class GameResult
    {
        public string GameNo { get; set; } = string.Empty;
        public decimal Stake { get; set; }
        public decimal TotalWin  {
            get
            {
                return Stake * GameRounds.Sum(gr => gr.Payout);
            }
        }
        public decimal TotalRound => GameRounds.Count;
        public List<GameRound> GameRounds { get; set; } = new();

    }
}
