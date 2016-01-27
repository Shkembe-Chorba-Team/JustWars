namespace JustWars.Web
{
    using System;
    using System.Linq;
    using System.Linq.Dynamic;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Models;

    public partial class Shop : Page
    {
        private JustWarsDbContext dbcontext;
        private User user;
        private Item[] items;
        private Item selectedItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dbcontext = new JustWarsDbContext();
            this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
            this.items = this.dbcontext.Items.ToArray();
            this.gold.InnerText = user.Gold.ToString();

            this.ShopItemsGrid.DataSource = this.items;
            this.ShopItemsGrid.DataBind();

            Session["ItemsGrid"] = items;

            ShopItemsGrid.DataSource = Session["ItemsGrid"];
            ShopItemsGrid.DataBind();
            return;
        }

        protected void ShopItemsGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.ShopItemsGrid.PageIndex = e.NewPageIndex;
            this.ShopItemsGrid.DataSource = this.items;
            this.ShopItemsGrid.DataBind();
        }

        protected void ShopItemsGrid_Sorting(object sender, GridViewSortEventArgs e)
        {
            var sortExpression = e.SortExpression + " " + GetSortDirection(e.SortExpression);
            this.items.OrderBy(sortExpression);
            ShopItemsGrid.DataSource = Session["ItemsGrid"];
            ShopItemsGrid.DataBind();
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

        protected void BuyItem(object sender, CommandEventArgs e)
        {
            var id = e.CommandArgument.ToString();
            this.selectedItem = this.dbcontext.Items.Find(id);

            if (this.user.Gold >= this.selectedItem.Gold)
            {
                this.user.Items.Add(this.selectedItem);
                this.user.Gold -= (int)this.selectedItem.Gold;
                this.dbcontext.SaveChanges();
            }
            else
            {
                this.error.Visible = true;
            }
        }
    }
}
