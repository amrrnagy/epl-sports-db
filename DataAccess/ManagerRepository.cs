using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class ManagerRepository
    {
        public static Manager GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Manager_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(Manager m)
        {
            try
            {
                using (var con = DatabaseHelper.GetConnection())
                {
                    con.Open();
                    using (var cmd = new SqlCommand("sp_Manager_Insert", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ManagerName",        m.ManagerName);
                        cmd.Parameters.AddWithValue("@Nationality",        m.Nationality);
                        cmd.Parameters.AddWithValue("@PreferredFormation", m.PreferredFormation);
                        cmd.Parameters.AddWithValue("@TeamId",             m.TeamId);
                        cmd.Parameters.AddWithValue("@ExperienceYears",    m.ExperienceYears);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    throw new Exception("This team already has a manager assigned. Please update the existing manager or choose a different team.");
                }
                throw;
            }
        }

        public static void Update(Manager m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Manager_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId",          m.ManagerId);
                    cmd.Parameters.AddWithValue("@ManagerName",        m.ManagerName);
                    cmd.Parameters.AddWithValue("@Nationality",        m.Nationality);
                    cmd.Parameters.AddWithValue("@PreferredFormation", m.PreferredFormation);
                    cmd.Parameters.AddWithValue("@TeamId",             m.TeamId);
                    cmd.Parameters.AddWithValue("@ExperienceYears",    m.ExperienceYears);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Manager_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ManagerId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<ManagerViewModel> GetAllManagersForGrid()
        {
            var list = new List<ManagerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Manager_GetAllForGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ManagerViewModel
                            {
                                ManagerId          = (int)reader["Manager_ID"],
                                ManagerName        = reader["Manager_Name"].ToString(),
                                Nationality        = reader["Nationality"].ToString(),
                                PreferredFormation = reader["Preferred_Formation"].ToString(),
                                TeamId             = (int)reader["Team_ID"],
                                ExperienceYears    = (int)reader["Experience_Years"],
                                TeamName           = reader["Team_Name"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
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
