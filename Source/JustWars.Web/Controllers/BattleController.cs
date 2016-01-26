namespace JustWars.Web.Controllers
{
    using System;

    using Models;
    using Models.BattleModels;
    using JustWars.Common;

    public class BattleController
    {
        public static BattleReturnModel PlayBattle(Battle battle)
        {
            var battleReturn = new BattleReturnModel();
            var firstPlayerWinCount = 0;
            var secondPlayerWinCount = 0;

            for (int i = 0; i < battle.NumberOfRounds; i++)
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
                battleReturn.WinnersGold = GoldController.CalculateGoldToAdd(battle.FirstPlayer, firstPlayerWinCount);
                battle.Status = BattleStatus.WonByFirstPlayer;
                battleReturn.Winner = battle.FirstPlayer;
                battleReturn.WinnerId = battle.FirstPlayerId;
                battleReturn.Loser = battle.SecondPlayer;
                battleReturn.LoserId = battle.SecondPlayerId;
                battleReturn.WinnerScore = firstPlayerWinCount;
                battleReturn.LoserScore = secondPlayerWinCount;
                return battleReturn;
            }

            battleReturn.WinnersGold = GoldController.CalculateGoldToAdd(battle.SecondPlayer, secondPlayerWinCount);
            battle.Status = BattleStatus.WonBySecondPlayer;
            battleReturn.Winner = battle.SecondPlayer;
            battleReturn.WinnerId = battle.SecondPlayerId;
            battleReturn.Loser = battle.FirstPlayer;
            battleReturn.LoserId = battle.FirstPlayerId;
            battleReturn.WinnerScore = secondPlayerWinCount;
            battleReturn.LoserScore = firstPlayerWinCount;
            return battleReturn;
        }

        public static double CalculateUserDamage(User attacker, User defender)
        {
            double attack = CalculateUserAttack(attacker);
            double defence = CalculateUserDefence(defender);
            double modifier = CalculateModifier();
            double damage = (((2 * modifier + 100) / 20) * ((attack / defence) / 10)  + 2) * (10 / modifier);
            return Math.Round(damage, 2);
        }

        public static double CalculateUserAttack(User user)
        {
            double attack = (user.Strength * 2) + (user.Stamina * 1.5) + (user.Agility * 1.5);
            return attack;
        }

        public static double CalculateUserDefence(User user)
        {
            double defence = (user.Charisma * 2) + (user.Defence * 3) + 2;
            return defence;
        }

        public static double CalculateModifier()
        {
            double modifier = RandomGenerator.GenerateRandomNumber(BattleConstants.MinModifier, BattleConstants.MaxModifier);
            return modifier;
        }
    }
}