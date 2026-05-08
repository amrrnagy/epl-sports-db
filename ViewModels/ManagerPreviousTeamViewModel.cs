namespace EPL_DBMS.ViewModels
{
    public class ManagerPreviousTeamViewModel
    {
        // Base Properties
        public int ManagerId { get; set; }
        public int PreviousTeamId { get; set; }

        // Joined UI Properties
        public string ManagerName { get; set; }
        public string PreviousTeamName { get; set; }
    }
}