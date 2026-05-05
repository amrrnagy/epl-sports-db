using System;

namespace EPL_DBMS.Models
{
    public class Match
    {
        public int      MatchId    { get; set; }
        public DateTime MatchDate  { get; set; }
        public int      HomeTeamId { get; set; }
        public int      AwayTeamId { get; set; }
        public int      StadiumId  { get; set; }
        public int      RefereeId  { get; set; }
        public int      HomeGoals  { get; set; }
        public int      AwayGoals  { get; set; }
        public int      Attendance { get; set; }
    }
}
