using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerStatRepository
    {
        // ── Existing methods (unchanged) ────────────────────────────────────────

        public static List<PlayerStat> GetAllPlayerStats()
        {
            var list = new List<PlayerStat>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Player_Stats", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static PlayerStat GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Player_Stats WHERE Player_Stat_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(PlayerStat p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Player_Stats (Match_ID, Player_ID, Goals_Scored, Assists, " +
                    "Yellow_Cards, Red_Cards, Minutes_Played) " +
                    "VALUES (@mid, @pid, @goals, @ast, @yc, @rc, @min)", con);
                cmd.Parameters.AddWithValue("@mid",   p.MatchId);
                cmd.Parameters.AddWithValue("@pid",   p.PlayerId);
                cmd.Parameters.AddWithValue("@goals", p.GoalsScored);
                cmd.Parameters.AddWithValue("@ast",   p.Assists);
                cmd.Parameters.AddWithValue("@yc",    p.YellowCards);
                cmd.Parameters.AddWithValue("@rc",    p.RedCards);
                cmd.Parameters.AddWithValue("@min",   p.MinutesPlayed);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(PlayerStat p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Player_Stats SET Match_ID=@mid, Player_ID=@pid, Goals_Scored=@goals, " +
                    "Assists=@ast, Yellow_Cards=@yc, Red_Cards=@rc, Minutes_Played=@min " +
                    "WHERE Player_Stat_ID=@id", con);
                cmd.Parameters.AddWithValue("@mid",   p.MatchId);
                cmd.Parameters.AddWithValue("@pid",   p.PlayerId);
                cmd.Parameters.AddWithValue("@goals", p.GoalsScored);
                cmd.Parameters.AddWithValue("@ast",   p.Assists);
                cmd.Parameters.AddWithValue("@yc",    p.YellowCards);
                cmd.Parameters.AddWithValue("@rc",    p.RedCards);
                cmd.Parameters.AddWithValue("@min",   p.MinutesPlayed);
                cmd.Parameters.AddWithValue("@id",    p.PlayerStatId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Player_Stats WHERE Player_Stat_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        // ── NEW: ViewModel methods for the DataGridView ──────────────────────────
        // INNER JOIN resolves Player_ID -> Player_Name.
        // No LINQ. No in-memory filtering.

        private static readonly string ViewQuery = @"
            SELECT ps.*, p.Player_Name
            FROM   Player_Stats ps
            INNER  JOIN Players p ON ps.Player_ID = p.Player_ID";

        // Used by the default (league-wide) constructor — returns ALL stats.
        public static List<PlayerStatViewModel> GetAllPlayerStatsForGrid()
        {
            var list = new List<PlayerStatViewModel>();
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

        // Used by the contextual (per-player) constructor — SQL WHERE filters by ID.
        public static List<PlayerStatViewModel> GetStatsByPlayerId(int playerId)
        {
            var list = new List<PlayerStatViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                string query = ViewQuery + " WHERE ps.Player_ID = @pid";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@pid", playerId);  // SqlParameter — no LINQ
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(MapView(reader));
            }
            return list;
        }

        // ── Private mappers ──────────────────────────────────────────────────────

        private static PlayerStat Map(SqlDataReader r) => new PlayerStat
        {
            PlayerStatId  = (int)r["Player_Stat_ID"],
            MatchId       = (int)r["Match_ID"],
            PlayerId      = (int)r["Player_ID"],
            GoalsScored   = (int)r["Goals_Scored"],
            Assists       = (int)r["Assists"],
            YellowCards   = (int)r["Yellow_Cards"],
            RedCards      = (int)r["Red_Cards"],
            MinutesPlayed = (int)r["Minutes_Played"]
        };

        private static PlayerStatViewModel MapView(SqlDataReader r) => new PlayerStatViewModel
        {
            // Base Model properties
            PlayerStatId  = (int)r["Player_Stat_ID"],
            MatchId       = (int)r["Match_ID"],
            PlayerId      = (int)r["Player_ID"],
            GoalsScored   = (int)r["Goals_Scored"],
            Assists       = (int)r["Assists"],
            YellowCards   = (int)r["Yellow_Cards"],
            RedCards      = (int)r["Red_Cards"],
            MinutesPlayed = (int)r["Minutes_Played"],

            // ViewModel property
            PlayerName    = r["Player_Name"].ToString()
        };
    }
}
