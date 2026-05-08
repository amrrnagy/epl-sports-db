namespace EPL_DBMS.ViewModels
{
    public class TeamViewModel
    {
        // Hidden identity column — kept so CellClick can read the PK value
        // without it being visible to the user.
        public int TeamId { get; set; }

        // Visible grid columns
        public string TeamName { get; set; }
        public int YearFounded { get; set; }
        public string HomeKitColor { get; set; }

        // Hidden FK — used by TeamsForm to pre-populate the Stadium ID textbox
        // when the user selects a row.
        public int StadiumId { get; set; }

        // Resolved display column (from JOIN with Stadiums in the repository)
        public string StadiumName { get; set; }
    }
}