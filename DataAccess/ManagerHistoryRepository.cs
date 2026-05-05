using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerHistoryRepository
    {
        public static List<ManagerHistory> GetByManagerId(int managerId)
        {
            var list = new List<ManagerHistory>();
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

        public static List<ManagerViewModel> GetHistoryWithNamesByManager(int managerId)
        {
            var list = new List<ManagerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();

                string query = @"
                    SELECT 
                        mpt.Manager_ID, 
                        m.Manager_Name, 
                        mpt.Previous_Team_ID, 
                        t.Team_Name
                    FROM Manager_Previous_Teams mpt
                    INNER JOIN Managers m ON mpt.Manager_ID = m.Manager_ID
                    INNER JOIN Teams t ON mpt.Previous_Team_ID = t.Team_ID
                    WHERE mpt.Manager_ID = @mid";

                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@mid", managerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ManagerViewModel
                        {
                            TeamName = reader["Team_Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static void Add(ManagerHistory m)
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

        private static ManagerHistory Map(SqlDataReader r) => new ManagerHistory
        {
            ManagerId = (int)r["Manager_ID"],
            PreviousTeamId = (int)r["Previous_Team_ID"]
        };
    }
}