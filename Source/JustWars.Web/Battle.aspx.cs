﻿namespace JustWars.Web
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
        private User[] users;
        private User oponent;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dbcontext = new JustWarsDbContext();
            this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            this.users = this.dbcontext.Users.OrderBy(u => -u.Wins).ToArray();

            if (!Page.IsPostBack)
            {
                this.usersGrid.DataSource = this.users;
                this.usersGrid.DataBind();

                Session["UsersGrid"] = users;

                usersGrid.DataSource = Session["UsersGrid"];
                usersGrid.DataBind();
            }
        }

        protected void UsersGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.usersGrid.PageIndex = e.NewPageIndex;
            this.usersGrid.DataSource = this.users;
            this.usersGrid.DataBind();
        }

        protected void UsersGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            var sortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            this.users.OrderBy(sortExpression);
            usersGrid.DataSource = users;
            usersGrid.DataBind();
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "asc";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "asc"))
                    {
                        sortDirection = "desc";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
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
