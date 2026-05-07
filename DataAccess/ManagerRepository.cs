using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerRepository
    {
        // ── Existing methods (unchanged) ────────────────────────────────────────

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
            try
            {
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    var cmd = new SqlCommand(
                        "INSERT INTO Managers (Manager_Name, Nationality, Preferred_Formation, Team_ID, Experience_Years) " +
                        "VALUES (@name, @nat, @form, @tid, @exp)", con);

                    cmd.Parameters.AddWithValue("@name", m.ManagerName);
                    cmd.Parameters.AddWithValue("@nat", m.Nationality);
                    cmd.Parameters.AddWithValue("@form", m.PreferredFormation);
                    cmd.Parameters.AddWithValue("@tid", m.TeamId);
                    cmd.Parameters.AddWithValue("@exp", m.ExperienceYears);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Check if the error number 2627 (Unique Constraint) or 2601 (Unique Index)
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("This team already has a manager assigned. Please update the existing manager or choose a different team.");
                }
                throw; // Re-throw other SQL errors (like connection issues)
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

        // ── NEW: ViewModel method for the DataGridView ───────────────────────────
        // Uses an INNER JOIN to resolve Team_ID -> Team_Name.
        // No LINQ. No in-memory filtering.

        public static List<ManagerViewModel> GetAllManagersForGrid()
        {
            var list = new List<ManagerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string query = @"
                    SELECT m.*, t.Team_Name
                    FROM   Managers m
                    INNER  JOIN Teams t ON m.Team_ID = t.Team_ID";

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ManagerViewModel
                        {
                            // Base Model properties
                            ManagerId          = (int)reader["Manager_ID"],
                            ManagerName        = reader["Manager_Name"].ToString(),
                            Nationality        = reader["Nationality"].ToString(),
                            PreferredFormation = reader["Preferred_Formation"].ToString(),
                            TeamId             = (int)reader["Team_ID"],
                            ExperienceYears    = (int)reader["Experience_Years"],

                            // ViewModel property
                            TeamName           = reader["Team_Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // ── Private mapper ───────────────────────────────────────────────────────

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
