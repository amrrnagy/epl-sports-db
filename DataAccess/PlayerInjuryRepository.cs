using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerInjuryRepository
    {
        // ── Existing methods (unchanged) ────────────────────────────────────────

        public static List<PlayerInjury> GetAllInjuries()
        {
            var list = new List<PlayerInjury>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Player_Injuries", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static List<PlayerInjury> GetByPlayerId(int playerId)
        {
            var list = new List<PlayerInjury>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Player_Injuries WHERE Player_ID = @pid", con);
                cmd.Parameters.AddWithValue("@pid", playerId);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static void Add(PlayerInjury i)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Player_Injuries (Player_ID, Injury_Date, Injury_Type, Days_Out) " +
                    "VALUES (@pid, @date, @type, @days)", con);
                cmd.Parameters.AddWithValue("@pid",  i.PlayerId);
                cmd.Parameters.AddWithValue("@date", i.InjuryDate);
                cmd.Parameters.AddWithValue("@type", i.InjuryType);
                cmd.Parameters.AddWithValue("@days", i.DaysOut);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(PlayerInjury i)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Player_Injuries SET Injury_Type=@type, Days_Out=@days " +
                    "WHERE Player_ID=@pid AND Injury_Date=@date", con);
                cmd.Parameters.AddWithValue("@type", i.InjuryType);
                cmd.Parameters.AddWithValue("@days", i.DaysOut);
                cmd.Parameters.AddWithValue("@pid",  i.PlayerId);
                cmd.Parameters.AddWithValue("@date", i.InjuryDate);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int playerId, DateTime injuryDate)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Player_Injuries WHERE Player_ID=@pid AND Injury_Date=@date", con);
                cmd.Parameters.AddWithValue("@pid",  playerId);
                cmd.Parameters.AddWithValue("@date", injuryDate);
                cmd.ExecuteNonQuery();
            }
        }

        // ── NEW: ViewModel methods for the DataGridView ──────────────────────────
        // INNER JOIN resolves Player_ID -> Player_Name.
        // No LINQ. No in-memory filtering.

        private static readonly string ViewQuery = @"
            SELECT pi.*, p.Player_Name
            FROM   Player_Injuries pi
            INNER  JOIN Players p ON pi.Player_ID = p.Player_ID";

        // Used by the default (league-wide) constructor — returns ALL injuries.
        public static List<PlayerInjuryViewModel> GetAllInjuriesWithNames()
        {
            var list = new List<PlayerInjuryViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(ViewQuery, con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(MapView(reader));
            }
            return list;
        }

        // ── NEW: Statistical Injury Standings (Aggregated Data) ───────────────────
        public static List<PlayerInjuryStatsViewModel> GetLeagueInjuryStatistics()
        {
            var list = new List<PlayerInjuryStatsViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();

                // Group by Player Name to calculate totals
                string query = @"
            SELECT 
                p.Player_Name,
                COUNT(pi.Player_ID) AS TotalInjuries,
                SUM(pi.Days_Out) AS TotalDaysOut,
                MAX(pi.Injury_Date) AS LastInjuryDate
            FROM Players p
            INNER JOIN Player_Injuries pi ON p.Player_ID = pi.Player_ID
            GROUP BY p.Player_Name
            ORDER BY TotalDaysOut DESC"; // Rank by who has been injured the longest

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PlayerInjuryStatsViewModel
                        {
                            PlayerName = reader["Player_Name"].ToString(),
                            TotalInjuries = (int)reader["TotalInjuries"],
                            TotalDaysOut = (int)reader["TotalDaysOut"],
                            LastInjuryDate = (DateTime)reader["LastInjuryDate"]
                        });
                    }
                }
            }
            return list;
        }

        // Used by the contextual (per-player) constructor — SQL WHERE filters by ID.
        public static List<PlayerInjuryViewModel> GetViewByPlayerId(int playerId)
        {
            var list = new List<PlayerInjuryViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                string query = ViewQuery + " WHERE pi.Player_ID = @pid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pid", playerId);  // SqlParameter — no LINQ
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(MapView(reader));
            }
            return list;
        }

        // ── Private mappers ──────────────────────────────────────────────────────

        private static PlayerInjury Map(SqlDataReader r) => new PlayerInjury
        {
            PlayerId   = (int)r["Player_ID"],
            InjuryDate = (DateTime)r["Injury_Date"],
            InjuryType = r["Injury_Type"].ToString(),
            DaysOut    = (int)r["Days_Out"]
        };

        private static PlayerInjuryViewModel MapView(SqlDataReader r) => new PlayerInjuryViewModel
        {
            // Base Model properties
            PlayerId   = (int)r["Player_ID"],
            InjuryDate = (DateTime)r["Injury_Date"],
            InjuryType = r["Injury_Type"].ToString(),
            DaysOut    = (int)r["Days_Out"],

            // ViewModel property
            PlayerName = r["Player_Name"].ToString()
        };
    }
}
