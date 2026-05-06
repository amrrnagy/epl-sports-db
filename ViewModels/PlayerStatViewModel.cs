using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPL_DBMS.Models;

namespace EPL_DBMS.ViewModels
{
    public class PlayerStatViewModel : PlayerStat
    {
        public string PlayerName { get; set; }
        public string MatchDisplay { get; set; }
    }
}
