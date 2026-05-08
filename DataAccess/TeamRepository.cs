using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class TeamRepository
    {
        public static List<Team> GetAllTeams()
        {
            var list = new List<Team>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static Team GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(Team t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamName",     t.TeamName);
                    cmd.Parameters.AddWithValue("@YearFounded",  t.YearFounded);
                    cmd.Parameters.AddWithValue("@HomeKitColor", t.HomeKitColor);
                    cmd.Parameters.AddWithValue("@StadiumId",    t.StadiumId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Team t)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamId",       t.TeamId);
                    cmd.Parameters.AddWithValue("@TeamName",     t.TeamName);
                    cmd.Parameters.AddWithValue("@YearFounded",  t.YearFounded);
                    cmd.Parameters.AddWithValue("@HomeKitColor", t.HomeKitColor);
                    cmd.Parameters.AddWithValue("@StadiumId",    t.StadiumId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TeamId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int TeamCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_Count", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<TeamViewModel> GetAllTeamsForGrid()
        {
            var list = new List<TeamViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Team_GetAllForGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new TeamViewModel
                            {
                                TeamId       = (int)reader["Team_ID"],
                                TeamName     = reader["Team_Name"].ToString(),
                                YearFounded  = (int)reader["Year_Founded"],
                                HomeKitColor = reader["Home_Kit_Color"].ToString(),
                                StadiumId    = (int)reader["Stadium_ID"],
                                StadiumName  = reader["Stadium_Name"].ToString()
                            });
                        }
                    }
                }
            }
            return list;
        }

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
