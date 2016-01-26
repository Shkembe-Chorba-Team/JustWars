namespace JustWars.Web.Controllers
{
    using Common.Constants;
    using JustWars.Common;
    using Models;

    public class GoldController
    {
        public static int CalculateGoldToAdd(User user, int wins)
        {
            int modifier = RandomGenerator.GenerateRandomNumber(GoldConstants.MinGold, GoldConstants.MaxGold);
            int gold = 0;
            if (wins != 0)
            {
                gold = modifier / wins;
            }
            else
            {
                gold = modifier;
            }

            return gold;
        }

        public static int CalculateNextStatLevelPrice(User user)
        {
            var sum = (user.Agility + user.Charisma + user.Defence + user.Stamina + user.Strength);
            var price = sum * 3;

            if (price < GoldConstants.StartingStatPrice)
            {
                price = GoldConstants.StartingStatPrice;
            }

            return price;
        }
    }
}