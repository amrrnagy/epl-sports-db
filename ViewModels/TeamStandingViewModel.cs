using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPL_DBMS.ViewModels
{
	public class TeamStandingViewModel
	{
		public string TeamName { get; set; }
		public int MatchesPlayed { get; set; }
		public decimal AvgPossession { get; set; }
		public int TotalShotsOnTarget { get; set; }
		public int TotalCorners { get; set; }
		public int TotalFouls { get; set; }
	}
}