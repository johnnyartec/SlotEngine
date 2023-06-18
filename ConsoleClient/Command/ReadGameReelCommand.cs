using SlotEngine.GameModule.GameSetting;
using SlotEngine.GameModule.Olympus.NormalGameSetting;

namespace ConsoleClient.Command
{
    internal class ReadGameReelCommand : ICommand
    {
        public void Execute()
        {
            ReadGameReel readGameReel = new ReadGameReel();
            GameReel gameReel = readGameReel.ReadFile();
        }
    }
}
