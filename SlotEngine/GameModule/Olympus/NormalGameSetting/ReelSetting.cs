namespace SlotEngine.GameModule.Olympus.NormalGameSetting
{
    /// <summary>
    /// 這是用來產生輪軸的相關設定
    /// 設定每個Symbol的出現次數
    /// </summary>
    public class ReelSetting
    {
        public List<Dictionary<string, int>> SymbolSettings { get; set; } = new();
    }
}
