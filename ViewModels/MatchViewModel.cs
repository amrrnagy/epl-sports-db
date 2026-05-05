using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    public class MatchViewModel : Match
    {
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
    }
}
