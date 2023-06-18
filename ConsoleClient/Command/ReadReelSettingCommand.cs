using SlotEngine.GameModule.GameSetting;
using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace ConsoleClient.Command
{
    internal class ReadReelSettingCommand : ICommand
    {
        public void Execute()
        {
            ReadReelSetting readReelSetting = new ReadReelSetting();
            ReelSetting reelSetting = readReelSetting.ReadFile();
        }
    }
}
