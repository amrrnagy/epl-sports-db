namespace EPL_DBMS.ViewModels
{
    public class PlayerViewModel
    {
        // Base Properties
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public int TeamId { get; set; }

        // Joined UI Properties
        public string TeamName { get; set; }
    }
}