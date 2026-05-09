using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerPreviousTeamRepository
    {
        public static List<ManagerPreviousTeamViewModel> GetViewByManagerId(int managerId)
        {
            var list = new List<ManagerPreviousTeamViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_ManagerPreviousTeam_GetViewByManagerId", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId", managerId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ManagerPreviousTeamViewModel
                            {
                                ManagerId        = (int)reader["Manager_ID"],
                                PreviousTeamId   = (int)reader["Previous_Team_ID"],
                                ManagerName      = reader["Manager_Name"].ToString(),
                                PreviousTeamName = reader["Team_Name"].ToString()
                            });
                        }
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
                using (var cmd = new SqlCommand("sp_ManagerPreviousTeam_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId",      m.ManagerId);
                    cmd.Parameters.AddWithValue("@PreviousTeamId", m.PreviousTeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int managerId, int previousTeamId)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_ManagerPreviousTeam_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId",      managerId);
                    cmd.Parameters.AddWithValue("@PreviousTeamId", previousTeamId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static ManagerPreviousTeam Map(SqlDataReader r) => new ManagerPreviousTeam
        {
            ManagerId      = (int)r["Manager_ID"],
            PreviousTeamId = (int)r["Previous_Team_ID"]
        };
    }
}
