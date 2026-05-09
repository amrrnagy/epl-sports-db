using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerRepository
    {
        public static List<PlayerViewModel> GetAllPlayersForGrid()
        {
            var list = new List<PlayerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_GetAllForGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new PlayerViewModel
                            {
                                PlayerId    = (int)reader["Player_ID"],
                                PlayerName  = reader["Player_Name"].ToString(),
                                Position    = reader["Position"].ToString(),
                                Age         = (int)reader["Age"],
                                Nationality = reader["Nationality"].ToString(),
                                TeamId      = (int)reader["Team_ID"],
                                TeamName    = reader["Team_Name"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

        public static Player GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static List<string> GetAllPositions()
        {
            var list = new List<string>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_GetDistinctPositions", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(reader["Position"].ToString());
                }
            }
            return list;
        }

        public static void Add(Player p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerName",  p.PlayerName);
                    cmd.Parameters.AddWithValue("@Position",    p.Position);
                    cmd.Parameters.AddWithValue("@Age",         p.Age);
                    cmd.Parameters.AddWithValue("@Nationality", p.Nationality);
                    cmd.Parameters.AddWithValue("@TeamId",      p.TeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Player p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId",    p.PlayerId);
                    cmd.Parameters.AddWithValue("@PlayerName",  p.PlayerName);
                    cmd.Parameters.AddWithValue("@Position",    p.Position);
                    cmd.Parameters.AddWithValue("@Age",         p.Age);
                    cmd.Parameters.AddWithValue("@Nationality", p.Nationality);
                    cmd.Parameters.AddWithValue("@TeamId",      p.TeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PlayerId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int PlayerCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Player_Count", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        private static Player Map(SqlDataReader r) => new Player
        {
            PlayerId    = (int)r["Player_ID"],
            PlayerName  = r["Player_Name"].ToString(),
            Position    = r["Position"].ToString(),
            Age         = (int)r["Age"],
            Nationality = r["Nationality"].ToString(),
            TeamId      = (int)r["Team_ID"]
        };
    }
}
