using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    // Inherits ALL properties from Team:
    //   TeamId, TeamName, YearFounded, HomeKitColor, StadiumId
    public class TeamViewModel : Team
    {
        // FK: Stadium_ID -> Stadiums.Stadium_Name
        public string StadiumName { get; set; }
    }
}
