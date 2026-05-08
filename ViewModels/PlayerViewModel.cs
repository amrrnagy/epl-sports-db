namespace EPL_DBMS.ViewModels
{
    public class PlayerViewModel
    {
        // Hidden identity column — kept so CellClick can read the PK value
        // without it being visible to the user.
        public int PlayerId { get; set; }

        // Visible grid columns
        public string PlayerName { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }

        // Hidden FK — used by PlayersForm to pre-populate the Team ID textbox
        // when the user selects a row.
        public int TeamId { get; set; }

        // Resolved display column (from JOIN with Teams in the repository)
        public string TeamName { get; set; }
    }
}