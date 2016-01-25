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
        private DateTime expireDate;
        private int[] data = new int[2];

        protected void Page_Load(object sender, EventArgs e)
        {
            var db = new JustWarsDbContext();

            if (DateTime.Now > expireDate)
            {
                expireDate = DateTime.Now;
                data[0] = db.Battles.Count();
                data[1] = db.Users.Count();
            }

            this.BattlesNumber.InnerText = data[0].ToString();
            this.UsersNumber.InnerText = data[1].ToString();
        }
    }
}