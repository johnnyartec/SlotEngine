using System.Security.Cryptography;

namespace SlotEngine.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _random;

        public RandomService()
        {
            // 產生一個 byte 陣列，作為種子
            byte[] seed = new byte[4];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(seed);
            }

            // 使用種子來初始化 Random 物件
            _random = new Random(BitConverter.ToInt32(seed, 0));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="count"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public List<int> GenerateRandomNumbers(int count, int minValue, int maxValue)
        {
            List<int> numbers = new List<int>();
            for (int i = 0; i < count; i++)
            {
                numbers.Add(_random.Next(minValue, maxValue + 1));
            }
            return numbers;
        }
    }
}
