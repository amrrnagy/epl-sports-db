using System;

namespace EPL_DBMS.Models
{
    public class PlayerInjury
    {
        public int      PlayerId    { get; set; }
        public DateTime InjuryDate  { get; set; }
        public string   InjuryType  { get; set; }
        public int      DaysOut     { get; set; }
    }
}
