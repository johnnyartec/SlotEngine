namespace ConsoleClient.Command
{
    internal static class CommandFactory
    {
        private static Dictionary<string, ICommand> CommandMapping { get; set; } = new Dictionary<string, ICommand>()
        {
            {"WP", new WritePayTableCommand() },
            {"RP", new ReadPayTableCommand() },
            {"WRS", new WriteReelSettingCommand()},
            {"RRS", new ReadReelSettingCommand() },
            {"WGR", new WriteGameReelCommand() },
            {"RGR", new ReadGameReelCommand() },
            {"GEN", new ReelGeneratorCommand() },
            {"SF", new ReelShuffleCommand() },
            {"SPIN", new SpinCommand() },
            {"SPINK", new SpinKCommand() }
        };



        public static ICommand Create(string command)
        {
            if (!CommandMapping.ContainsKey(command)) {
                throw new ArgumentException($"Invalid Command:{command}");
            }

            return CommandMapping[command];

        }
        
    }
}
