namespace SlotEngine.Services
{
    public interface IRandomService
    {
        List<int> GenerateRandomNumbers(int count, int minValue, int maxValue);
    }
}
