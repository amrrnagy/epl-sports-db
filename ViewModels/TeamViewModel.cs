namespace EPL_DBMS.ViewModels
{
    public class TeamViewModel
    {
        // Base Properties
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int YearFounded { get; set; }
        public string HomeKitColor { get; set; }
        public int StadiumId { get; set; }
        
        // Joined UI Properties
        public string StadiumName { get; set; }
    }
}