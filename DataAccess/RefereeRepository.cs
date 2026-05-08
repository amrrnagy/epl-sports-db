using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class RefereeRepository
    {
        public static List<Referee> GetAllReferees()
        {
            var list = new List<Referee>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Referee_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static Referee GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Referee_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RefereeId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(Referee r)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Referee_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RefereeName", r.RefereeName);
                    cmd.Parameters.AddWithValue("@Nationality", r.Nationality);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Referee r)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Referee_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RefereeId",   r.RefereeId);
                    cmd.Parameters.AddWithValue("@RefereeName", r.RefereeName);
                    cmd.Parameters.AddWithValue("@Nationality", r.Nationality);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Referee_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RefereeId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static Referee Map(SqlDataReader r) => new Referee
        {
            RefereeId   = (int)r["Referee_ID"],
            RefereeName = r["Referee_Name"].ToString(),
            Nationality = r["Nationality"].ToString()
        };
    }
}
