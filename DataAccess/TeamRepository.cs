using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class TeamRepository
    {
        // ── Existing methods (unchanged) ────────────────────────────────────────

        public static List<Team> GetAllTeams()
        {
            var list = new List<Team>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Teams", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static Team GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Teams WHERE Team_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Team t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Teams (Team_Name, Year_Founded, Home_Kit_Color, Stadium_ID) " +
                    "VALUES (@name, @year, @kit, @sid)", con);
                cmd.Parameters.AddWithValue("@name", t.TeamName);
                cmd.Parameters.AddWithValue("@year", t.YearFounded);
                cmd.Parameters.AddWithValue("@kit",  t.HomeKitColor);
                cmd.Parameters.AddWithValue("@sid",  t.StadiumId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Team t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Teams SET Team_Name=@name, Year_Founded=@year, " +
                    "Home_Kit_Color=@kit, Stadium_ID=@sid WHERE Team_ID=@id", con);
                cmd.Parameters.AddWithValue("@name", t.TeamName);
                cmd.Parameters.AddWithValue("@year", t.YearFounded);
                cmd.Parameters.AddWithValue("@kit",  t.HomeKitColor);
                cmd.Parameters.AddWithValue("@sid",  t.StadiumId);
                cmd.Parameters.AddWithValue("@id",   t.TeamId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Teams WHERE Team_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static int TeamCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Teams", con);
                return (int)cmd.ExecuteScalar();
            }
        }

        // ── NEW: ViewModel method for the DataGridView ───────────────────────────
        // Uses an INNER JOIN to resolve Stadium_ID -> Stadium_Name.
        // No LINQ. No in-memory filtering.

        public static List<TeamViewModel> GetAllTeamsForGrid()
        {
            var list = new List<TeamViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string query = @"
                    SELECT t.*, s.Stadium_Name
                    FROM   Teams t
                    INNER  JOIN Stadiums s ON t.Stadium_ID = s.Stadium_ID";

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new TeamViewModel
                        {
                            // Base Model properties
                            TeamId       = (int)reader["Team_ID"],
                            TeamName     = reader["Team_Name"].ToString(),
                            YearFounded  = (int)reader["Year_Founded"],
                            HomeKitColor = reader["Home_Kit_Color"].ToString(),
                            StadiumId    = (int)reader["Stadium_ID"],

                            // ViewModel property
                            StadiumName  = reader["Stadium_Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // ── Private mapper ───────────────────────────────────────────────────────

        private static Team Map(SqlDataReader r) => new Team
        {
            TeamId       = (int)r["Team_ID"],
            TeamName     = r["Team_Name"].ToString(),
            YearFounded  = (int)r["Year_Founded"],
            HomeKitColor = r["Home_Kit_Color"].ToString(),
            StadiumId    = (int)r["Stadium_ID"]
        };
    }
}
