using SlotEngine.GameModule.GameSetting;

namespace ConsoleClient.Command
{
    internal class ReadPayTableCommand : ICommand
    {
        void ICommand.Execute()
        {
            var readPayTable = new ReadPayTable();
            var payTable = readPayTable.ReadFile();
        }
    }
}
