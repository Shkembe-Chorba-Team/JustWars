namespace JustWars.Web.Models
{
    public class Battle
    {
        public int Id { get; set; }

        public int FirstPlayerId { get; set; }

        public User FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }

        public User SecondPlayer { get; set; }

        public BattleStatus Status { get; set; }
    }
}
