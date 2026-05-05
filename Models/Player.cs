using System;

namespace EPL_DBMS.Models
{
    public class Player
    {
        public int    PlayerId     { get; set; }
        public string PlayerName   { get; set; }
        public string Position     { get; set; }
        public int    Age          { get; set; }
        public string Nationality  { get; set; }
        public int    TeamId       { get; set; }
    }
}
