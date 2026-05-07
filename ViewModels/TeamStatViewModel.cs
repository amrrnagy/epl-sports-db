using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    public class TeamStatViewModel : TeamStat
    {
        public string TeamName { get; set; }
        public string MatchDisplay { get; set; } 
    }
}