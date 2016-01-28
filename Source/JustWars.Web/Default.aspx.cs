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
        private static DateTime expires;
        private static int[] data = new int[3]; 

        public _Default()
        {
            this.dbcontext = new JustWarsDbContext();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sener, EventArgs e)
        {
            if (expires < DateTime.Now)
            {
                var battles = this.dbcontext.Battles;
                data[0] = this.dbcontext.Battles.Count();
                data[1] = this.dbcontext.Users.Count();
                data[2] = this.dbcontext.Items.Count();
                expires = DateTime.Now.AddMinutes(10);
            }

            this.BattlesNumber.Text = data[0].ToString();
            this.UsersNumber.Text = data[1].ToString();
            this.ItemsNumber.Text = data[2].ToString();
        }
    }
}