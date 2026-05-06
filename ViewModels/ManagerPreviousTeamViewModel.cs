using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    public class ManagerPreviousTeamViewModel : ManagerPreviousTeam
    {
        public string ManagerName { get; set; }
        public string PreviousTeamName { get; set; }
    }
}
