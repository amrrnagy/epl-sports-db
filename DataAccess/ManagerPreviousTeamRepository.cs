using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerPreviousTeamRepository
    {
        public static List<ManagerPreviousTeam> GetByManagerId(int managerId)
        {
            var list = new List<ManagerPreviousTeam>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Manager_Previous_Teams WHERE Manager_ID = @mid", con);
                cmd.Parameters.AddWithValue("@mid", managerId);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static List<ManagerPreviousTeamViewModel> GetViewByManagerId(int managerId)
        {
            var list = new List<ManagerPreviousTeamViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                // Join BOTH the Managers table and the Teams table
                string query = @"
                                SELECT h.*, m.Manager_Name, t.Team_Name 
                                FROM Manager_Previous_Teams h
                                INNER JOIN Managers m ON h.Manager_ID = m.Manager_ID
                                INNER JOIN Teams t ON h.Previous_Team_ID = t.Team_ID
                                WHERE h.Manager_ID = @ManagerId";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ManagerId", managerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ManagerPreviousTeamViewModel
                        {
                            // Base Model Properties
                            ManagerId = (int)reader["Manager_ID"],
                            PreviousTeamId = (int)reader["Previous_Team_ID"],

                            // ViewModel Properties (The readable names)
                            ManagerName = reader["Manager_Name"].ToString(),
                            PreviousTeamName = reader["Team_Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Add(ManagerPreviousTeam m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Manager_Previous_Teams (Manager_ID, Previous_Team_ID) " +
                    "VALUES (@mid, @ptid)", con);
                cmd.Parameters.AddWithValue("@mid", m.ManagerId);
                cmd.Parameters.AddWithValue("@ptid", m.PreviousTeamId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int managerId, int previousTeamId)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "DELETE FROM Manager_Previous_Teams " +
                    "WHERE Manager_ID=@mid AND Previous_Team_ID=@ptid", con);
                cmd.Parameters.AddWithValue("@mid", managerId);
                cmd.Parameters.AddWithValue("@ptid", previousTeamId);
                cmd.ExecuteNonQuery();
            }
        }

        private static ManagerPreviousTeam Map(SqlDataReader r) => new ManagerPreviousTeam
        {
            ManagerId = (int)r["Manager_ID"],
            PreviousTeamId = (int)r["Previous_Team_ID"]
        };
    }
}