using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class StadiumRepository
    {
        public static List<Stadium> GetAllStadiums()
        {
            var list = new List<Stadium>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Stadium_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static Stadium GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Stadium_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StadiumId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(Stadium s)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Stadium_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StadiumName", s.StadiumName);
                    cmd.Parameters.AddWithValue("@City",        s.City);
                    cmd.Parameters.AddWithValue("@Capacity",    s.Capacity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Stadium s)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Stadium_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StadiumId",   s.StadiumId);
                    cmd.Parameters.AddWithValue("@StadiumName", s.StadiumName);
                    cmd.Parameters.AddWithValue("@City",        s.City);
                    cmd.Parameters.AddWithValue("@Capacity",    s.Capacity);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Stadium_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StadiumId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Stadium Map(SqlDataReader r) => new Stadium
        {
            StadiumId   = (int)r["Stadium_ID"],
            StadiumName = r["Stadium_Name"].ToString(),
            City        = r["City"].ToString(),
            Capacity    = (int)r["Capacity"]
        };
    }
}
