namespace EPL_DBMS.Models
{
    public class PlayerStat
    {
        public int PlayerStatId   { get; set; }
        public int MatchId        { get; set; }
        public int PlayerId       { get; set; }
        public int GoalsScored    { get; set; }
        public int Assists        { get; set; }
        public int YellowCards    { get; set; }
        public int RedCards       { get; set; }
        public int MinutesPlayed  { get; set; }
    }
}
