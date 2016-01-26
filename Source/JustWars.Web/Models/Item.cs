namespace JustWars.Web.Models
{
    using System.Collections.Generic;

    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public uint Gold { get; set; }

        public int Strength { get; set; }

        public int Defence { get; set; }

        public int Stamina { get; set; }

        public int Agility { get; set; }

        public int Charisma { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
