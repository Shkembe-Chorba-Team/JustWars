namespace JustWars.Web.Controllers
{
    using System;

    using Models;
    using JustWars.Common;

    public class BattleController
    {
        public static User GetWinner(Battle battle)
        {
            var firstPlayerWinCount = 0;
            var secondPlayerWinCount = 0;

            for (int i = 0; i < BattleConstants.NumberOfBattlesPerRound; i++)
            {
                var firstPlayerDamage = CalculateUserDamage(battle.FirstPlayer, battle.SecondPlayer);
                var secondPlayerDamage = CalculateUserDamage(battle.SecondPlayer, battle.FirstPlayer);
                if (firstPlayerDamage > secondPlayerDamage)
                {
                    firstPlayerWinCount++;
                    continue;
                }

                secondPlayerWinCount++;
            }

            if (firstPlayerWinCount > secondPlayerWinCount)
            {
                GoldController.AddGold(battle.FirstPlayer, firstPlayerWinCount);
                return battle.FirstPlayer;
            }

            GoldController.AddGold(battle.SecondPlayer, secondPlayerWinCount);
            return battle.SecondPlayer;
        }

        public static double CalculateUserDamage(User attacker, User defender)
        {
            double attack = CalculateUserAttack(attacker);
            double defence = CalculateUserDefence(defender);
            double modifier = CalculateModifier();
            double damage = (((2 * modifier + 100) / 2) * ((attack / defence * 2) / 10)  + 2);
            return Math.Round(damage, 2);
        }

        public static double CalculateUserAttack(User user)
        {
            double attack = (user.Strength * 4) + (user.Stamina * 3) + (user.Agility * 3);
            return attack;
        }

        public static double CalculateUserDefence(User user)
        {
            double defence = (user.Charisma * 4) + (user.Defence * 6) + 2;
            return defence;
        }

        public static double CalculateModifier()
        {
            double modifier = RandomGenerator.GenerateRandomNumber(BattleConstants.MinModifier, BattleConstants.MaxModifier);
            return modifier;
        }
    }
}