using SlotEngine.GameModule.GameSetting;

namespace ConsoleClient.Command
{
    internal class WriteReelSettingCommand : ICommand
    {
        public void Execute()
        {
            WriteReelSetting writeReelSetting = new WriteReelSetting();
            writeReelSetting.WriteFile();
        }
    }
}
