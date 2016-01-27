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
        private Item selectedItem;

        public Shop()
        {
            this.dbcontext = new JustWarsDbContext();
            this.user = this.dbcontext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.gold.InnerText = user.Gold.ToString();
        }

        public IQueryable<Item> GridViewItems_GetData()
        {
            return this.dbcontext.Items
                        .OrderBy(b => b.Gold);
        }

        protected void BuyItem(object sender, CommandEventArgs e)
        {
            var id = int.Parse(e.CommandArgument.ToString());
            this.selectedItem = this.dbcontext.Items.Find(id);

            if (this.user.Gold < this.selectedItem.Gold)
            {
                this.error.InnerText = "You don't have enough gold!";
                this.error.Visible = true;
            }
            else if (this.user.Items.Contains(this.selectedItem))
            {
                this.error.InnerText = "You already have this item!";
                this.error.Visible = true;
            }
            else
            {
                this.error.Visible = false;
                this.success.Visible = true;
                this.success.InnerText = "You successfully bought " + selectedItem.Name;
                this.user.Items.Add(this.selectedItem);
                this.user.Gold -= (int)this.selectedItem.Gold;
                this.dbcontext.SaveChanges();
            }
        }
    }
}
