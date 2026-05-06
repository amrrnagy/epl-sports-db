using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPL_DBMS.Models
{
    public class Team
    {
    
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int YearFounded { get; set; }
        public string HomeKitColor { get; set; }
        public int StadiumId { get; set; } 
        public string DisplayText => $"{TeamId} - {TeamName}";
    }
}