namespace JustWars.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Web.Controllers;
    using Web.Models;

    [TestClass]
    public class BattleLogicTests
    {
        [TestMethod]
        public void UserShouldHaveValidAttack()
        {
            var user = new User
            {
                Agility = 5,
                Stamina = 5,
                Strength = 5
            };

            var attack = BattleController.CalculateUserAttack(user);
            Assert.AreEqual(25, attack);
        }

        [TestMethod]
        public void UserShouldHaveValidDefence()
        {
            var user = new User
            {
                Charisma = 5,
                Defence = 5
            };

            var defence = BattleController.CalculateUserDefence(user);
            Assert.AreEqual(27, defence);
        }

        [TestMethod]
        public void StrongerUserShouldHaveMoreDamage()
        {
            var weakUser = new User
            {
                Agility = 5,
                Stamina = 5,
                Strength = 5,
                Charisma = 5,
                Defence = 5
            };

            var strongUser = new User
            {
                Agility = 10,
                Stamina = 10,
                Strength = 10,
                Charisma = 10,
                Defence = 10
            };

            var strongerUserDamage = BattleController.CalculateUserDamage(strongUser, weakUser);
            var weakerUserDamage = BattleController.CalculateUserDamage(weakUser, strongUser);
            Assert.IsTrue(strongerUserDamage > weakerUserDamage);
        }

        [TestMethod]
        public void StrongUserShouldDefeatWeakUserInBattle()
        {
            var weakUser = new User
            {
                Agility = 5,
                Stamina = 5,
                Strength = 5,
                Charisma = 5,
                Defence = 5
            };

            var strongUser = new User
            {
                Agility = 10,
                Stamina = 10,
                Strength = 10,
                Charisma = 10,
                Defence = 10
            };

            var battle = new Battle
            {
                FirstPlayer = strongUser,
                SecondPlayer = weakUser
            };

            var baattleReturn = BattleController.PlayBattle(battle);

            Assert.AreEqual(strongUser, baattleReturn.Winner);
        }
    }
}
