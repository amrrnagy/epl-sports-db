namespace EPL_DBMS.Models
{
    public class TeamStat
    {
        public int     TeamStatId            { get; set; }
        public int     MatchId               { get; set; }
        public int     TeamId                { get; set; }
        public decimal PossessionPercentage  { get; set; }
        public int     ShotsOnTarget         { get; set; }
        public int     Corners               { get; set; }
        public int     Fouls                 { get; set; }
    }
}
