using SlotEngine.Helper;

namespace ConsoleClient.Task
{
    /// <summary>
    /// 
    /// </summary>
    public class ReelShuffle
    {
        public static void Shuffle()
        {
            var symbols = new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };

            var shuffledSymbols = ShuffleHelper.Shuffle(symbols);

            Console.WriteLine("Shuffled symbols:");
            foreach (var symbol in shuffledSymbols) {
                Console.Write(symbol + " ");
            }
        }
    }
}
