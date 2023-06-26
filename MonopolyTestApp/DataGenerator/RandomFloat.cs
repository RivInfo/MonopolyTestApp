namespace Test.DataGenerator;

public static class RandomFloat
{
    private static Random _random = new();
    
    public static float GetRandomFloat(float min, float max)
    {
        return Math.Clamp(_random.Next((int)min, (int)max) + (float)_random.NextDouble(), min, max);
    }
}