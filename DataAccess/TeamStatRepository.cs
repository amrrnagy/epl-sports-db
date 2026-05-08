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
        // ── Read Methods (Base Models) ──────────────────────────────────────────

        public static List<TeamStat> GetAllTeamStats()
        {
            var list = new List<TeamStat>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static TeamStat GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamStatId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

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

        // ── Write Methods ───────────────────────────────────────────────────────

        public static void Add(TeamStat t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId",              t.MatchId);
                    cmd.Parameters.AddWithValue("@TeamId",               t.TeamId);
                    cmd.Parameters.AddWithValue("@PossessionPercentage", t.PossessionPercentage);
                    cmd.Parameters.AddWithValue("@ShotsOnTarget",        t.ShotsOnTarget);
                    cmd.Parameters.AddWithValue("@Corners",              t.Corners);
                    cmd.Parameters.AddWithValue("@Fouls",                t.Fouls);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(TeamStat t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamStatId",           t.TeamStatId);
                    cmd.Parameters.AddWithValue("@MatchId",              t.MatchId);
                    cmd.Parameters.AddWithValue("@TeamId",               t.TeamId);
                    cmd.Parameters.AddWithValue("@PossessionPercentage", t.PossessionPercentage);
                    cmd.Parameters.AddWithValue("@ShotsOnTarget",        t.ShotsOnTarget);
                    cmd.Parameters.AddWithValue("@Corners",              t.Corners);
                    cmd.Parameters.AddWithValue("@Fouls",                t.Fouls);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_TeamStat_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamStatId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ── Private Mappers ─────────────────────────────────────────────────────

        private static TeamStat Map(SqlDataReader r) => new TeamStat
        {
            TeamStatId           = (int)r["Team_Stat_ID"],
            MatchId              = (int)r["Match_ID"],
            TeamId               = (int)r["Team_ID"],
            PossessionPercentage = (decimal)r["Possession_Percentage"],
            ShotsOnTarget        = (int)r["Shots_On_Target"],
            Corners              = (int)r["Corners"],
            Fouls                = (int)r["Fouls"]
        };

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
