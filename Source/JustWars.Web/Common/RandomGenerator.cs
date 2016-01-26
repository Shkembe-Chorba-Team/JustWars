namespace JustWars.Common
{
    using System;

    public class RandomGenerator
    {
        public static int GenerateRandomNumber(int min, int max)
        {
            var random = new Random();
            var number = random.Next(min, max + 1);
            return number;
        }
    }
}
