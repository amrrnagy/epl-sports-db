using System;

namespace EPL_DBMS.ViewModels
{
    public class PlayerInjuryViewModel
    {
        // Base Properties
        public int PlayerId { get; set; }
        public DateTime InjuryDate { get; set; }
        public string InjuryType { get; set; }
        public int DaysOut { get; set; }

        // Joined UI Properties
        public string PlayerName { get; set; }
    }
}