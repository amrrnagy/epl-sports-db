using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    public class ManagerViewModel : Manager 
    {
        public int PreviousTeamId { get; set; }

        public string TeamName { get; set; }
    }
}
