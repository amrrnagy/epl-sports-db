using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerRepository
    {
        public static List<Manager> GetAllManagers()
        {
            var list = new List<Manager>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Managers", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static Manager GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Managers WHERE Manager_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Manager m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Managers (Manager_Name, Nationality, Preferred_Formation, Team_ID, Experience_Years) " +
                    "VALUES (@name, @nat, @form, @tid, @exp)", con);
                cmd.Parameters.AddWithValue("@name", m.ManagerName);
                cmd.Parameters.AddWithValue("@nat",  m.Nationality);
                cmd.Parameters.AddWithValue("@form", m.PreferredFormation);
                cmd.Parameters.AddWithValue("@tid",  m.TeamId);
                cmd.Parameters.AddWithValue("@exp",  m.ExperienceYears);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Manager m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Managers SET Manager_Name=@name, Nationality=@nat, " +
                    "Preferred_Formation=@form, Team_ID=@tid, Experience_Years=@exp " +
                    "WHERE Manager_ID=@id", con);
                cmd.Parameters.AddWithValue("@name", m.ManagerName);
                cmd.Parameters.AddWithValue("@nat",  m.Nationality);
                cmd.Parameters.AddWithValue("@form", m.PreferredFormation);
                cmd.Parameters.AddWithValue("@tid",  m.TeamId);
                cmd.Parameters.AddWithValue("@exp",  m.ExperienceYears);
                cmd.Parameters.AddWithValue("@id",   m.ManagerId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Managers WHERE Manager_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private static Manager Map(SqlDataReader r) => new Manager
        {
            ManagerId          = (int)r["Manager_ID"],
            ManagerName        = r["Manager_Name"].ToString(),
            Nationality        = r["Nationality"].ToString(),
            PreferredFormation = r["Preferred_Formation"].ToString(),
            TeamId             = (int)r["Team_ID"],
            ExperienceYears    = (int)r["Experience_Years"]
        };
    }
}
