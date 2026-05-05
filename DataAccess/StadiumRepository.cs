using System.Collections.Generic;
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
                var cmd = new SqlCommand("SELECT * FROM Stadiums", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static Stadium GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Stadiums WHERE Stadium_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Stadium s)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Stadiums (Stadium_Name, City, Capacity) " +
                    "VALUES (@name, @city, @cap)", con);
                cmd.Parameters.AddWithValue("@name", s.StadiumName);
                cmd.Parameters.AddWithValue("@city", s.City);
                cmd.Parameters.AddWithValue("@cap",  s.Capacity);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Stadium s)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Stadiums SET Stadium_Name=@name, City=@city, Capacity=@cap " +
                    "WHERE Stadium_ID=@id", con);
                cmd.Parameters.AddWithValue("@name", s.StadiumName);
                cmd.Parameters.AddWithValue("@city", s.City);
                cmd.Parameters.AddWithValue("@cap",  s.Capacity);
                cmd.Parameters.AddWithValue("@id",   s.StadiumId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Stadiums WHERE Stadium_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
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
