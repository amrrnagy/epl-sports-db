using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

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
    }
}
