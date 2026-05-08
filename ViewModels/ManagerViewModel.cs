namespace EPL_DBMS.ViewModels
{
    public class ManagerViewModel
    {
        // Base Properties
        public int ManagerId { get; set; }
        public string ManagerName { get; set; }
        public string Nationality { get; set; }
        public string PreferredFormation { get; set; }
        public int TeamId { get; set; }
        public int ExperienceYears { get; set; }

        // Joined UI Properties
        public string TeamName { get; set; }
    }
}