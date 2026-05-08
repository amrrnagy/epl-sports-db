namespace EPL_DBMS.ViewModels
{
    public class PlayerStatViewModel
    {
        // Base Properties
        public int PlayerStatId { get; set; }
        public int MatchId { get; set; }
        public int PlayerId { get; set; }
        public int GoalsScored { get; set; }
        public int Assists { get; set; }
        public int YellowCards { get; set; }
        public int RedCards { get; set; }
        public int MinutesPlayed { get; set; }

        // Joined UI Properties
        public string PlayerName { get; set; }
        public string MatchDisplay { get; set; }
    }
}