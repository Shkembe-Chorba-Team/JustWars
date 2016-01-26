namespace JustWars.Web.Models.BattleModels
{
    public class BattleReturnModel
    {
        public string WinnerId { get; set; }
        
        public User Winner { get; set; }

        public string LoserId { get; set; }

        public User Loser { get; set; }

        public int WinnerScore { get; set; }

        public int LoserScore { get; set; }

        public int WinnersGold { get; set; }
    }
}
