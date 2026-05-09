using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class TeamStatRepository
    {
        // ── NEW: Statistical Standings (Aggregated Data) ───────────────────────

        public static List<TeamStandingViewModel> GetLeagueStatisticalStandings()
        {
            var list = new List<TeamStandingViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_GetLeagueStandings", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TeamStandingViewModel
                            {
                                TeamName           = reader["Team_Name"].ToString(),
                                MatchesPlayed      = (int)reader["MatchesPlayed"],
                                AvgPossession      = (decimal)reader["AvgPossession"],
                                TotalShotsOnTarget = (int)reader["TotalShots"],
                                TotalCorners       = (int)reader["TotalCorners"],
                                TotalFouls         = (int)reader["TotalFouls"]
                            });
                        }
                    }
                }
            }
            return list;
        }

        // ── Read Methods (ViewModels with Names) ───────────────────────────────

        public static List<TeamStatViewModel> GetStatsByTeamId(int teamId)
        {
            var list = new List<TeamStatViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_GetByTeamId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamId", teamId);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapView(reader));
                }
            }
            return list;
        }

        private static TeamStatViewModel MapView(SqlDataReader r) => new TeamStatViewModel
        {
            TeamStatId           = (int)r["Team_Stat_ID"],
            MatchId              = (int)r["Match_ID"],
            TeamId               = (int)r["Team_ID"],
            PossessionPercentage = (decimal)r["Possession_Percentage"],
            ShotsOnTarget        = (int)r["Shots_On_Target"],
            Corners              = (int)r["Corners"],
            Fouls                = (int)r["Fouls"],
            TeamName             = r["Team_Name"].ToString(),
            MatchDisplay         = r["Match_Date"] != DBNull.Value
                ? $"{r["HomeTeam"]} - {r["AwayTeam"]} -- {Convert.ToDateTime(r["Match_Date"]).ToString("dd/MM/yyyy")}"
                : $"{r["HomeTeam"]} - {r["AwayTeam"]} -- TBD"
        };
    }
}
