namespace JustWars.Common
{
    using System;

    public class RandomGenerator
    {
        public static Random random = new Random();

        public static int GenerateRandomNumber(int min, int max)
        {
            var number = random.Next(min, max + 1);
            return number;
        }
    }
}
