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
