namespace JustWars.Web
{
    using System;
    using System.Web.UI;

    using Models;
    using Controllers;
    public partial class Battle : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var battle = new Models.Battle
            {
                FirstPlayer = new Models.User
                {
                    UserName = "Number1",
                    Agility = 6,
                    Stamina = 6,
                    Strength = 5,
                    Charisma = 5,
                    Defence = 5
                },
                SecondPlayer = new Models.User
                {
                    UserName = "Number2",
                    Agility = 5,
                    Stamina = 5,
                    Strength = 5,
                    Charisma = 5,
                    Defence = 5
                }
            };

            var winner = BattleController.GetWinner(battle);
            this.winnerLabel.Text = winner.UserName;
        }
    }
}