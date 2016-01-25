namespace JustWars.Web.Models
{
    using System.Collections.Generic;

    public class UsersItems
    {
        public int UserId { get; set; }
        public int ItemId { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
        public virtual ICollection<Item> Items { get; set; }
    }
}
