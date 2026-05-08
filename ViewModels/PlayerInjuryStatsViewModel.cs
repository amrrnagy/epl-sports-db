using System;

namespace EPL_DBMS.ViewModels
{
    public class PlayerInjuryStatsViewModel
    {
        public string PlayerName { get; set; }
        public int TotalInjuries { get; set; }
        public int TotalDaysOut { get; set; }
        public DateTime LastInjuryDate { get; set; }
    }
}