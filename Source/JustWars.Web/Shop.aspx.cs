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
