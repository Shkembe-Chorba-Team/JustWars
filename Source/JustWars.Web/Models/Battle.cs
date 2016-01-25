namespace JustWars.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Battle
    {
        public int Id { get; set; }

        public int FirstPlayerId { get; set; }

        public ApplicationUser FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }

        public ApplicationUser SecondPlayer { get; set; }

        public BattleStatus Status { get; set; }
    }
}
