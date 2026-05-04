using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class TeamRepository
    {
        public static List<Team> GetAllTeams()
        {
            var teams = new List<Team>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Teams", con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        teams.Add(new Team
                        {
                            // Ensure these string names exactly match your SQL column names!
                            TeamId = (int)reader["Team_ID"],
                            TeamName = reader["Team_Name"].ToString(),
                            YearFounded = (int)reader["Year_Founded"],
                            HomeKitColor = reader["Home_Kit_Color"].ToString(),
                            StadiumId = (int)reader["Stadium_ID"]
                        });
                    }
                }
            }
            return teams;
        }
    }
}