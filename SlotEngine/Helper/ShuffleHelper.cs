using SlotEngine.Services;

namespace SlotEngine.Helper
{
    public class ShuffleHelper
    {
        private static IRandomService RandomServices { get; set; } = new RandomService();

        public static List<string> Shuffle(List<string> list)
        {
            //var rng = new Random();
            var n = list.Count;

            // Fisher-Yates Shuffle Algorithm
            while (n > 1)
            {
                n--;
                //int k = rng.Next(n + 1);
                int k = RandomServices.GenerateRandomNumbers(1, 0, n+1)[0];
                string value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            // Check for consecutive symbols and swap if necessary
            for (var i = 1; i < list.Count; i++)
            {
                if (list[i].Substring(0, 1) == list[i - 1].Substring(0, 1))
                {
                    var j = i + 1;
                    while (j < list.Count && list[j].Substring(0, 1) == list[i].Substring(0, 1))
                    {
                        j++;
                    }
                    if (j < list.Count)
                    {
                        string temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }

            return list;
        }

        public static List<string> FlatSymbol(List<string> symbols)
        {
            var flatSymbols = new List<string>();
            foreach (var symbol in symbols) {
                var c = symbol[0];
                var count = int.Parse(symbol.Substring(1));
                flatSymbols.AddRange(Enumerable.Repeat(c.ToString(), count));
            }

            return flatSymbols;
        }
    }
}
