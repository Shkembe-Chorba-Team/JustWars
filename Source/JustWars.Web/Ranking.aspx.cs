using JustWars.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JustWars.Web
{
    public partial class Ranking : System.Web.UI.Page
    {
        private JustWarsDbContext dbcontext;

        public Ranking()
        {
            this.dbcontext = new JustWarsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }


        public IQueryable<User> GridViewUsers_GetData()
        {
            return this.dbcontext.Users
                        .OrderByDescending(b => b.Wins)
                        .ThenByDescending(b => b.Gold);
        }
    }
}