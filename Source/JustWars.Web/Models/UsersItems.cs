using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWars.Web.Models
{
    public class UsersItems
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
