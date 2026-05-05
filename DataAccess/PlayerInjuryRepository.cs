using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerInjuryRepository
    {
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

        private static PlayerInjury Map(SqlDataReader r) => new PlayerInjury
        {
            PlayerId   = (int)r["Player_ID"],
            InjuryDate = (DateTime)r["Injury_Date"],
            InjuryType = r["Injury_Type"].ToString(),
            DaysOut    = (int)r["Days_Out"]
        };
    }
}
