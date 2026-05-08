namespace EPL_DBMS.ViewModels
{
    public class TeamStatViewModel
    {
        // Base Properties
        public int TeamStatId { get; set; }
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public decimal PossessionPercentage { get; set; }
        public int ShotsOnTarget { get; set; }
        public int Corners { get; set; }
        public int Fouls { get; set; }

        // Joined UI Properties
        public string TeamName { get; set; }
        public string MatchDisplay { get; set; }
    }
}