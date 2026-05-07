using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    // Inherits ALL properties from Match:
    //   MatchId, MatchDate, HomeTeamId, AwayTeamId, StadiumId, RefereeId,
    //   HomeGoals, AwayGoals, Attendance
    public class MatchViewModel : Match
    {
        // FK: Home_Team_ID  -> Teams.Team_Name
        public string HomeTeamName { get; set; }

        // FK: Away_Team_ID  -> Teams.Team_Name
        public string AwayTeamName { get; set; }

        // FK: Stadium_ID    -> Stadiums.Stadium_Name
        public string StadiumName  { get; set; }

        // FK: Referee_ID    -> Referees.Referee_Name
        public string RefereeName  { get; set; }
    }
}
