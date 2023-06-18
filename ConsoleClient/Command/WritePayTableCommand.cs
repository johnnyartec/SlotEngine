using SlotEngine.GameModule.GameSetting;

namespace ConsoleClient.Command
{
    internal class WritePayTableCommand : ICommand
    {
        public void Execute()
        {
            WritePayTable writePayTableSetting = new WritePayTable();
            writePayTableSetting.WriteFile();
        }
    }
}
