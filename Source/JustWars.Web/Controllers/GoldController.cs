namespace JustWars.Web.Controllers
{
    using Common.Constants;
    using JustWars.Common;
    using Models;

    public class GoldController
    {
        public static void AddGold(User user, int wins)
        {
            var gold = CalculateGoldToAdd(wins);
            // TODO: add gold to user
        }

        private static uint CalculateGoldToAdd(int wins)
        {
            int modifier = RandomGenerator.GenerateRandomNumber(GoldConstants.MinGold, GoldConstants.MaxGold);
            int gold = modifier / wins;
            return (uint)gold;
        }
    }
}