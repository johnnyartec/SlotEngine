using SlotEngine.GameModule.GameSetting;

namespace ConsoleClient.Command
{
    internal class WriteGameReelCommand : ICommand
    {
        public void Execute()
        {
            WriteGameReel writeGameReel = new WriteGameReel();
            writeGameReel.WriteFile();
        }
    }
}
