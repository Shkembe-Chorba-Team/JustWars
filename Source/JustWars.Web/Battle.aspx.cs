namespace JustWars.Web
{
    using System;
    using System.Data;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Models;
    using Controllers;

    public partial class Battle : Page
    {
        private JustWarsDbContext dbcontext;
        private User user;
        private User[] users;
        private User selectedUser;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.dbcontext = new JustWarsDbContext();
                this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
                this.users = this.dbcontext.Users
                    .ToArray();

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
            //this.users.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            //dt.DefaultView.Sort = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            //usersGrid.DataSource = Session["UsersGrid"];
            //usersGrid.DataBind();
        }

        private string GetSortDirection(string column)
        {
            string sortDirection = "ASC";
            string sortExpression = ViewState["SortExpression"] as string;

            if (sortExpression != null)
            {
                if (sortExpression == column)
                {
                    string lastDirection = ViewState["SortDirection"] as string;
                    if ((lastDirection != null) && (lastDirection == "ASC"))
                    {
                        sortDirection = "DESC";
                    }
                }
            }

            ViewState["SortDirection"] = sortDirection;
            ViewState["SortExpression"] = column;

            return sortDirection;
        }

        protected void ShowUser(object sender, EventArgs e)
        {
            this.ShowUserField.Visible = true;
            //this.selectedUser = dbcontext.Users.FirstOrDefault(u => u.Id == this.gridViewId.text);
            this.UserName.InnerText = selectedUser.UserName;
            this.Strength.Text = selectedUser.Strength.ToString();
            this.Defence.Text = selectedUser.Defence.ToString();
            this.Agility.Text = selectedUser.Agility.ToString();
            this.Stamina.Text = selectedUser.Stamina.ToString();
            this.Charisma.Text = selectedUser.Charisma.ToString();
        }
    }
}
