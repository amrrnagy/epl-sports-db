using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerInjuryRepository
    {
        public static List<PlayerInjury> GetByPlayerId(int playerId)
        {
            var list = new List<PlayerInjury>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_GetByPlayerId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", playerId);
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static void Add(PlayerInjury i)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId",   i.PlayerId);
                    cmd.Parameters.AddWithValue("@InjuryDate", i.InjuryDate);
                    cmd.Parameters.AddWithValue("@InjuryType", i.InjuryType);
                    cmd.Parameters.AddWithValue("@DaysOut",    i.DaysOut);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(PlayerInjury i)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId",   i.PlayerId);
                    cmd.Parameters.AddWithValue("@InjuryDate", i.InjuryDate);
                    cmd.Parameters.AddWithValue("@InjuryType", i.InjuryType);
                    cmd.Parameters.AddWithValue("@DaysOut",    i.DaysOut);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int playerId, DateTime injuryDate)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId",   playerId);
                    cmd.Parameters.AddWithValue("@InjuryDate", injuryDate);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<PlayerInjuryViewModel> GetAllInjuriesWithNames()
        {
            var list = new List<PlayerInjuryViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_GetAllWithNames", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapView(reader));
                }
            }
            return list;
        }

        public static List<PlayerInjuryStatsViewModel> GetLeagueInjuryStatistics()
        {
            var list = new List<PlayerInjuryStatsViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_GetLeagueStatistics", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PlayerInjuryStatsViewModel
                            {
                                PlayerName     = reader["Player_Name"].ToString(),
                                TotalInjuries  = (int)reader["TotalInjuries"],
                                TotalDaysOut   = (int)reader["TotalDaysOut"],
                                LastInjuryDate = (DateTime)reader["LastInjuryDate"]
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static List<PlayerInjuryViewModel> GetViewByPlayerId(int playerId)
        {
            var list = new List<PlayerInjuryViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_PlayerInjury_GetViewByPlayerId", con))
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

        private static PlayerInjury Map(SqlDataReader r) => new PlayerInjury
        {
            PlayerId   = (int)r["Player_ID"],
            InjuryDate = (DateTime)r["Injury_Date"],
            InjuryType = r["Injury_Type"].ToString(),
            DaysOut    = (int)r["Days_Out"]
        };

        private static PlayerInjuryViewModel MapView(SqlDataReader r) => new PlayerInjuryViewModel
        {
            PlayerId   = (int)r["Player_ID"],
            InjuryDate = (DateTime)r["Injury_Date"],
            InjuryType = r["Injury_Type"].ToString(),
            DaysOut    = (int)r["Days_Out"],
            PlayerName = r["Player_Name"].ToString()
        };
    }
}
