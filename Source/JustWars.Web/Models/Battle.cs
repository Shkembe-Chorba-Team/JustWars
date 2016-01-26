namespace JustWars.Web.Models
{
    public class Battle
    {
        public int Id { get; set; }

        public string FirstPlayerId { get; set; }

        public User FirstPlayer { get; set; }

        public string SecondPlayerId { get; set; }

        public User SecondPlayer { get; set; }

        public BattleStatus Status { get; set; }

        public int NumberOfRounds { get; set; }
    }
}
