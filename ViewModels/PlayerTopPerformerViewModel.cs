using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPL_DBMS.ViewModels
{
    public class PlayerTopPerformerViewModel
    {
        public string PlayerName { get; set; }
        public int TotalGoals { get; set; }
        public int TotalAssists { get; set; }
        public int TotalYellowCards { get; set; }
        public int TotalRedCards { get; set; }
        public int TotalMinutes { get; set; }
    }
}
