using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;

namespace EPL_DBMS.DataAccess
{
    public static class MatchRepository
    {
        public static List<Match> GetAllMatches()
        {
            var list = new List<Match>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Matches", con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(Map(reader));
            }
            return list;
        }

        public static Match GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT * FROM Matches WHERE Match_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public static void Add(Match m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "INSERT INTO Matches (Match_Date, Home_Team_ID, Away_Team_ID, Stadium_ID, " +
                    "Referee_ID, Home_Goals, Away_Goals, Attendance) " +
                    "VALUES (@date, @htid, @atid, @sid, @rid, @hg, @ag, @att)", con);
                cmd.Parameters.AddWithValue("@date", m.MatchDate);
                cmd.Parameters.AddWithValue("@htid", m.HomeTeamId);
                cmd.Parameters.AddWithValue("@atid", m.AwayTeamId);
                cmd.Parameters.AddWithValue("@sid",  m.StadiumId);
                cmd.Parameters.AddWithValue("@rid",  m.RefereeId);
                cmd.Parameters.AddWithValue("@hg",   m.HomeGoals);
                cmd.Parameters.AddWithValue("@ag",   m.AwayGoals);
                cmd.Parameters.AddWithValue("@att",  m.Attendance);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Update(Match m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(
                    "UPDATE Matches SET Match_Date=@date, Home_Team_ID=@htid, Away_Team_ID=@atid, " +
                    "Stadium_ID=@sid, Referee_ID=@rid, Home_Goals=@hg, Away_Goals=@ag, " +
                    "Attendance=@att WHERE Match_ID=@id", con);
                cmd.Parameters.AddWithValue("@date", m.MatchDate);
                cmd.Parameters.AddWithValue("@htid", m.HomeTeamId);
                cmd.Parameters.AddWithValue("@atid", m.AwayTeamId);
                cmd.Parameters.AddWithValue("@sid",  m.StadiumId);
                cmd.Parameters.AddWithValue("@rid",  m.RefereeId);
                cmd.Parameters.AddWithValue("@hg",   m.HomeGoals);
                cmd.Parameters.AddWithValue("@ag",   m.AwayGoals);
                cmd.Parameters.AddWithValue("@att",  m.Attendance);
                cmd.Parameters.AddWithValue("@id",   m.MatchId);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("DELETE FROM Matches WHERE Match_ID = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private static Match Map(SqlDataReader r) => new Match
        {
            MatchId    = (int)r["Match_ID"],
            MatchDate  = (DateTime)r["Match_Date"],
            HomeTeamId = (int)r["Home_Team_ID"],
            AwayTeamId = (int)r["Away_Team_ID"],
            StadiumId  = (int)r["Stadium_ID"],
            RefereeId  = (int)r["Referee_ID"],
            HomeGoals  = (int)r["Home_Goals"],
            AwayGoals  = (int)r["Away_Goals"],
            Attendance = (int)r["Attendance"]
        };
    }
}
