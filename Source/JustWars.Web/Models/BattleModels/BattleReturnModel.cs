namespace JustWars.Web.Models.BattleModels
{
    public class BattleReturnModel
    {
        public int WinnerId { get; set; }
        
        public User Winner { get; set; }

        public int LooserId { get; set; }

        public User Looser { get; set; }

        public int WinnerScore { get; set; }

        public int LooserScore { get; set; }

        public int WinnersGold { get; set; }
    }
}
