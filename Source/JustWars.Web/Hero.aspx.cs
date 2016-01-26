using JustWars.Web.Controllers;
using JustWars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustWars.Web
{
    public partial class Hero : System.Web.UI.Page
    {
        private JustWarsDbContext dbcontext;
        private User user;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dbcontext = new JustWarsDbContext();
            this.UserName.InnerText = this.User.Identity.Name;
            this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Strength.Text = user.Strength.ToString();
            this.Defence.Text = user.Defence.ToString();
            this.Agility.Text = user.Agility.ToString();
            this.Stamina.Text = user.Stamina.ToString();
            this.Charisma.Text = user.Charisma.ToString();
            this.NextStatPrice.Text = GoldController.CalculateNextStatLevelPrice(this.user).ToString();
            this.Gold.Text = user.Gold.ToString();
        }

        public void UpdateStat(object sender, CommandEventArgs e)
        {
            var statPrice = GoldController.CalculateNextStatLevelPrice(this.user);

            if (statPrice <= this.user.Gold)
            {
                switch (e.CommandArgument.ToString())
                {
                    case "Strength":
                        ++this.user.Strength;
                        break;
                    case "Defence":
                        ++this.user.Defence;
                        break;
                    case "Agility":
                        ++this.user.Agility;
                        break;
                    case "Charisma":
                        ++this.user.Charisma;
                        break;
                    case "Stamina":
                        ++this.user.Stamina;
                        break;
                }

                this.user.Gold -= statPrice;

                this.dbcontext.SaveChanges();
            }
        }
    }
}