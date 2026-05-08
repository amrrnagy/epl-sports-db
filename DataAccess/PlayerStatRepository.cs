using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerStatRepository
    {
        public static List<PlayerStat> GetAllPlayerStats()
        {
            var list = new List<PlayerStat>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static PlayerStat GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerStatId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(PlayerStat p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId",       p.MatchId);
                    cmd.Parameters.AddWithValue("@PlayerId",      p.PlayerId);
                    cmd.Parameters.AddWithValue("@GoalsScored",   p.GoalsScored);
                    cmd.Parameters.AddWithValue("@Assists",       p.Assists);
                    cmd.Parameters.AddWithValue("@YellowCards",   p.YellowCards);
                    cmd.Parameters.AddWithValue("@RedCards",      p.RedCards);
                    cmd.Parameters.AddWithValue("@MinutesPlayed", p.MinutesPlayed);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(PlayerStat p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerStatId",  p.PlayerStatId);
                    cmd.Parameters.AddWithValue("@MatchId",       p.MatchId);
                    cmd.Parameters.AddWithValue("@PlayerId",      p.PlayerId);
                    cmd.Parameters.AddWithValue("@GoalsScored",   p.GoalsScored);
                    cmd.Parameters.AddWithValue("@Assists",       p.Assists);
                    cmd.Parameters.AddWithValue("@YellowCards",   p.YellowCards);
                    cmd.Parameters.AddWithValue("@RedCards",      p.RedCards);
                    cmd.Parameters.AddWithValue("@MinutesPlayed", p.MinutesPlayed);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerStatId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<PlayerStatViewModel> GetAllPlayerStatsForGrid()
        {
            var list = new List<PlayerStatViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_GetAllForGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapView(reader));
                }
            }
            return list;
        }

        public static List<PlayerStatViewModel> GetStatsByPlayerId(int playerId)
        {
            var list = new List<PlayerStatViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_GetByPlayerId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapView(reader));
                }
            }
            return list;
        }

        public static List<PlayerTopPerformerViewModel> GetLeagueTopPerformers()
        {
            var list = new List<PlayerTopPerformerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerStat_GetLeagueTopPerformers", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PlayerTopPerformerViewModel
                            {
                                PlayerName       = reader["Player_Name"].ToString(),
                                TotalGoals       = reader["TotalGoals"]       == System.DBNull.Value ? 0 : System.Convert.ToInt32(reader["TotalGoals"]),
                                TotalAssists     = reader["TotalAssists"]     == System.DBNull.Value ? 0 : System.Convert.ToInt32(reader["TotalAssists"]),
                                TotalYellowCards = reader["TotalYellowCards"] == System.DBNull.Value ? 0 : System.Convert.ToInt32(reader["TotalYellowCards"]),
                                TotalRedCards    = reader["TotalRedCards"]    == System.DBNull.Value ? 0 : System.Convert.ToInt32(reader["TotalRedCards"]),
                                TotalMinutes     = reader["TotalMinutes"]     == System.DBNull.Value ? 0 : System.Convert.ToInt32(reader["TotalMinutes"])
                            });
                        }
                    }
                }
            }
            return list;
        }

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
            PlayerStatId  = (int)r["Player_Stat_ID"],
            MatchId       = (int)r["Match_ID"],
            PlayerId      = (int)r["Player_ID"],
            GoalsScored   = (int)r["Goals_Scored"],
            Assists       = (int)r["Assists"],
            YellowCards   = (int)r["Yellow_Cards"],
            RedCards      = (int)r["Red_Cards"],
            MinutesPlayed = (int)r["Minutes_Played"],
            PlayerName    = r["Player_Name"].ToString(),
            MatchDisplay  = r["Match_Date"] != System.DBNull.Value
                ? $"{r["HomeTeam"]} - {r["AwayTeam"]} -- {System.Convert.ToDateTime(r["Match_Date"]).ToString("dd/MM/yyyy")}"
                : $"{r["HomeTeam"]} - {r["AwayTeam"]} -- TBD"
        };
    }
}
