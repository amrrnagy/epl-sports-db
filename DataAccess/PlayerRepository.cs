using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class PlayerRepository
    {
        public static List<Player> GetAllPlayers()
        {
            var list = new List<Player>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Players", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        // Make sure to add this at the top of your file if you haven't already:

        public static List<PlayerViewModel> GetAllPlayersForGrid()
        {
            var list = new List<PlayerViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();

                // We use an INNER JOIN to connect Players to Teams
                string query = @"
                                SELECT p.*, t.Team_Name 
                                FROM Players p
                                INNER JOIN Teams t ON p.Team_ID = t.Team_ID";

                var cmd = new SqlCommand(query, con);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PlayerViewModel
                        {
                            // 1. The base properties (inherited from Player)
                            PlayerId = (int)reader["Player_ID"],
                            PlayerName = reader["Player_Name"].ToString(),
                            Position = reader["Position"].ToString(),
                            Age = (int)reader["Age"],
                            Nationality = reader["Nationality"].ToString(),
                            TeamId = (int)reader["Team_ID"],

                            // 2. The extra UI property
                            TeamName = reader["Team_Name"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        public static Player GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Players WHERE Player_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Player p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Players (Player_Name, Position, Age, Nationality, Team_ID) " +
                    "VALUES (@name, @pos, @age, @nat, @tid)", con);
                cmd.Parameters.AddWithValue("@name", p.PlayerName);
                cmd.Parameters.AddWithValue("@pos",  p.Position);
                cmd.Parameters.AddWithValue("@age",  p.Age);
                cmd.Parameters.AddWithValue("@nat",  p.Nationality);
                cmd.Parameters.AddWithValue("@tid",  p.TeamId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Player p)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Players SET Player_Name=@name, Position=@pos, Age=@age, " +
                    "Nationality=@nat, Team_ID=@tid WHERE Player_ID=@id", con);
                cmd.Parameters.AddWithValue("@name", p.PlayerName);
                cmd.Parameters.AddWithValue("@pos",  p.Position);
                cmd.Parameters.AddWithValue("@age",  p.Age);
                cmd.Parameters.AddWithValue("@nat",  p.Nationality);
                cmd.Parameters.AddWithValue("@tid",  p.TeamId);
                cmd.Parameters.AddWithValue("@id",   p.PlayerId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Players WHERE Player_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public static int PlayerCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("Select Count(*) from Players", con);
                return (int)cmd.ExecuteScalar();
            }
        }

        private static Player Map(SqlDataReader r) => new Player
        {
            PlayerId    = (int)r["Player_ID"],
            PlayerName  = r["Player_Name"].ToString(),
            Position    = r["Position"].ToString(),
            Age         = (int)r["Age"],
            Nationality = r["Nationality"].ToString(),
            TeamId      = (int)r["Team_ID"]
        };
    }
}
