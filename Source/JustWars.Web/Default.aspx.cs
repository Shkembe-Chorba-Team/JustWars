using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using JustWars.Web.Models;

namespace JustWars.Web
{
    public partial class _Default : Page
    {
        private JustWarsDbContext dbcontext;

        public _Default()
        {
            this.dbcontext = new JustWarsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sener, EventArgs e)
        {
            this.BattlesNumber.Text = this.dbcontext.Battles.Count().ToString();
            this.UsersNumber.Text = this.dbcontext.Users.Count().ToString();
            this.ItemsNumber.Text = this.dbcontext.Items.Count().ToString();
        }
    }
}