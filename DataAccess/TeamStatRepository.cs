using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class TeamStatRepository
    {
        // ── SQL Snippets for Reusability ───────────────────────────────────────
        private const string ViewQuery = @"
            SELECT ts.*, t.Team_Name, m.Match_Date, 
                   ht.Team_Name AS HomeTeam, 
                   at.Team_Name AS AwayTeam
            FROM Team_Stats ts
            INNER JOIN Teams t ON ts.Team_ID = t.Team_ID
            INNER JOIN Matches m ON ts.Match_ID = m.Match_ID
            INNER JOIN Teams ht ON m.Home_Team_ID = ht.Team_ID
            INNER JOIN Teams at ON m.Away_Team_ID = at.Team_ID";

        // ── Read Methods (Base Models) ──────────────────────────────────────────

        public static List<TeamStat> GetAllTeamStats()
        {
            var list = new List<TeamStat>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Team_Stats", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static TeamStat GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Team_Stats WHERE Team_Stat_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        // ── NEW: Statistical Standings (Aggregated Data) ───────────────────────

        public static List<TeamStandingViewModel> GetLeagueStatisticalStandings()
        {
            var list = new List<TeamStandingViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                // We use GROUP BY to crunch the numbers for the whole season!
                string query = @"
                    SELECT 
                        t.Team_Name,
                        COUNT(ts.Match_ID) AS MatchesPlayed,
                        CAST(ROUND(AVG(ts.Possession_Percentage), 2) AS DECIMAL(5,2)) AS AvgPossession,
                        SUM(ts.Shots_On_Target) AS TotalShots,
                        SUM(ts.Corners) AS TotalCorners,
                        SUM(ts.Fouls) AS TotalFouls
                    FROM Teams t
                    INNER JOIN Team_Stats ts ON t.Team_ID = ts.Team_ID
                    GROUP BY t.Team_Name
                    ORDER BY AvgPossession DESC, TotalShots DESC"; // Rank by possession, then shots

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TeamStandingViewModel
                        {
                            TeamName = reader["Team_Name"].ToString(),
                            MatchesPlayed = (int)reader["MatchesPlayed"],
                            AvgPossession = (decimal)reader["AvgPossession"],
                            TotalShotsOnTarget = (int)reader["TotalShots"],
                            TotalCorners = (int)reader["TotalCorners"],
                            TotalFouls = (int)reader["TotalFouls"]
                        });
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
                string query = ViewQuery + " WHERE ts.Team_ID = @tid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tid", teamId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(MapView(reader));
                    }
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
                var cmd = new SqlCommand(
                    "INSERT INTO Team_Stats (Match_ID, Team_ID, Possession_Percentage, " +
                    "Shots_On_Target, Corners, Fouls) " +
                    "VALUES (@mid, @tid, @poss, @shots, @corn, @fouls)", con);
                cmd.Parameters.AddWithValue("@mid", t.MatchId);
                cmd.Parameters.AddWithValue("@tid", t.TeamId);
                cmd.Parameters.AddWithValue("@poss", t.PossessionPercentage);
                cmd.Parameters.AddWithValue("@shots", t.ShotsOnTarget);
                cmd.Parameters.AddWithValue("@corn", t.Corners);
                cmd.Parameters.AddWithValue("@fouls", t.Fouls);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(TeamStat t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Team_Stats SET Match_ID=@mid, Team_ID=@tid, " +
                    "Possession_Percentage=@poss, Shots_On_Target=@shots, " +
                    "Corners=@corn, Fouls=@fouls WHERE Team_Stat_ID=@id", con);
                cmd.Parameters.AddWithValue("@mid", t.MatchId);
                cmd.Parameters.AddWithValue("@tid", t.TeamId);
                cmd.Parameters.AddWithValue("@poss", t.PossessionPercentage);
                cmd.Parameters.AddWithValue("@shots", t.ShotsOnTarget);
                cmd.Parameters.AddWithValue("@corn", t.Corners);
                cmd.Parameters.AddWithValue("@fouls", t.Fouls);
                cmd.Parameters.AddWithValue("@id", t.TeamStatId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Team_Stats WHERE Team_Stat_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ── Private Mappers ─────────────────────────────────────────────────────

        private static TeamStat Map(SqlDataReader r) => new TeamStat
        {
            TeamStatId = (int)r["Team_Stat_ID"],
            MatchId = (int)r["Match_ID"],
            TeamId = (int)r["Team_ID"],
            PossessionPercentage = (decimal)r["Possession_Percentage"],
            ShotsOnTarget = (int)r["Shots_On_Target"],
            Corners = (int)r["Corners"],
            Fouls = (int)r["Fouls"]
        };

        private static TeamStatViewModel MapView(SqlDataReader r) => new TeamStatViewModel
        {
            TeamStatId = (int)r["Team_Stat_ID"],
            MatchId = (int)r["Match_ID"],
            TeamId = (int)r["Team_ID"],
            PossessionPercentage = (decimal)r["Possession_Percentage"],
            ShotsOnTarget = (int)r["Shots_On_Target"],
            Corners = (int)r["Corners"],
            Fouls = (int)r["Fouls"],

            TeamName = r["Team_Name"].ToString(),

            // FORMAT: "Arsenal - Chelsea -- 14/10/2023"
            MatchDisplay = r["Match_Date"] != DBNull.Value
                ? $"{r["HomeTeam"]} - {r["AwayTeam"]} -- {Convert.ToDateTime(r["Match_Date"]).ToString("dd/MM/yyyy")}"
                : $"{r["HomeTeam"]} - {r["AwayTeam"]} -- TBD"
        };
    }
}