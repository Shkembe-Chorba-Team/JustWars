namespace JustWars.Web
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Models;
    using Controllers;

    public partial class Battle : Page
    {
        private JustWarsDbContext dbcontext;
        private User user;
        private User oponent;

        public Battle()
        {
            this.dbcontext = new JustWarsDbContext();
            this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public IQueryable<User> GridViewUsers_GetData()
        {
            return this.dbcontext.Users
                .OrderBy(b => b.Wins)
                .Where(u => u.UserName != this.user.UserName);
        }
        
        protected void ShowUser(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument.ToString();
            this.oponent = this.dbcontext.Users.Find(id);
            if (oponent != null)
            {
                this.ShowUserField.Visible = true;
                this.UserName.InnerText = oponent.UserName;
                this.Id.Text = oponent.Id;
                this.Strength.Text = oponent.Strength.ToString();
                this.Defence.Text = oponent.Defence.ToString();
                this.Agility.Text = oponent.Agility.ToString();
                this.Stamina.Text = oponent.Stamina.ToString();
                this.Charisma.Text = oponent.Charisma.ToString();
            }
        }

        protected void FightUser(object sender, EventArgs e)
        {
            this.attackSelf.Visible = false;
            var id = this.Id.Text;

            if (id == this.user.Id)
            {
                this.attackSelf.Visible = true;
                return;
            }

            this.oponent = this.dbcontext.Users.Find(id);
            if (oponent != null)
            {
                var battle = new Models.Battle()
                {
                    FirstPlayer = this.user,
                    FirstPlayerId = this.user.Id,
                    SecondPlayer = this.oponent,
                    SecondPlayerId = this.oponent.Id
                };

                var battleResult = BattleController.PlayBattle(battle);
                if (battleResult.Winner.Id == this.user.Id)
                {
                    this.user.Gold += battleResult.WinnersGold;
                    this.gold.InnerHtml = battleResult.WinnersGold.ToString();
                    this.winMessage.Visible = true;
                    this.user.Wins++;
                    this.oponent.Losses++;
                }
                else
                {
                    this.oponent.Gold += battleResult.WinnersGold;
                    this.loseMessage.Visible = true;
                    this.oponent.Wins++;
                    this.user.Losses++;
                }

                this.dbcontext.Battles.Add(battle);
                this.dbcontext.SaveChanges();
            }
        }
    }
}
