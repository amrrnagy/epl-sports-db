using System.Collections.Generic;
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
                var cmd = new SqlCommand("SELECT * FROM Referees", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static Referee GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Referees WHERE Referee_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Referee r)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Referees (Referee_Name, Nationality) VALUES (@name, @nat)", con);
                cmd.Parameters.AddWithValue("@name", r.RefereeName);
                cmd.Parameters.AddWithValue("@nat",  r.Nationality);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Referee r)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Referees SET Referee_Name=@name, Nationality=@nat WHERE Referee_ID=@id", con);
                cmd.Parameters.AddWithValue("@name", r.RefereeName);
                cmd.Parameters.AddWithValue("@nat",  r.Nationality);
                cmd.Parameters.AddWithValue("@id",   r.RefereeId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Referees WHERE Referee_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
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
