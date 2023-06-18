namespace SlotEngine.GameModule.Olympus.NormalGameSetting
{
    public class PayTableItem
    {
        public string SymbolNo { get; set; } = string.Empty;
        public string SymbolType { get; set; } = string.Empty;
        public List<decimal> PayOut{get;init;} = new();
    }
}
