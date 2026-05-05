namespace EPL_DBMS.Models
{
    public class Manager
    {
        public int    ManagerId          { get; set; }
        public string ManagerName        { get; set; }
        public string Nationality        { get; set; }
        public string PreferredFormation { get; set; }
        public int    TeamId             { get; set; }
        public int    ExperienceYears    { get; set; }
    }
}
