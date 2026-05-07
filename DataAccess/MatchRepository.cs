using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

namespace EPL_DBMS.DataAccess
{
    public static class MatchRepository
    {
        // ── Existing methods (unchanged) ────────────────────────────────────────

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

        public static int MatchCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand("SELECT COUNT(*) FROM Matches", con);
                return (int)cmd.ExecuteScalar();
            }
        }

        // ── NEW: ViewModel methods for the DataGridView ──────────────────────────
        // Four INNER JOINs resolve every FK to a human-readable name.
        // No LINQ. No in-memory filtering.

        private static readonly string ViewQuery = @"
            SELECT m.*,
                   ht.Team_Name   AS Home_Team_Name,
                   at.Team_Name   AS Away_Team_Name,
                   s.Stadium_Name,
                   r.Referee_Name
            FROM   Matches m
            INNER  JOIN Teams    ht ON m.Home_Team_ID = ht.Team_ID
            INNER  JOIN Teams    at ON m.Away_Team_ID = at.Team_ID
            INNER  JOIN Stadiums s  ON m.Stadium_ID   = s.Stadium_ID
            INNER  JOIN Referees r  ON m.Referee_ID   = r.Referee_ID";

        // Returns ALL matches with readable names (used by the default constructor).
        public static List<MatchViewModel> GetAllMatchesForGrid()
        {
            var list = new List<MatchViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                var cmd = new SqlCommand(ViewQuery, con);
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        list.Add(MapView(reader));
            }
            return list;
        }

        // Returns a single match with readable names (used by the Search button).
        // Uses a SQL WHERE clause + SqlParameter — no LINQ filtering.
        public static MatchViewModel GetMatchViewById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                string query = ViewQuery + " WHERE m.Match_ID = @id";
                var cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);
                using (var reader = cmd.ExecuteReader())
                    return reader.Read() ? MapView(reader) : null;
            }
        }

        // ── Private mappers ──────────────────────────────────────────────────────

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

        private static MatchViewModel MapView(SqlDataReader r) => new MatchViewModel
        {
            // Base Model properties
            MatchId    = (int)r["Match_ID"],
            MatchDate  = (DateTime)r["Match_Date"],
            HomeTeamId = (int)r["Home_Team_ID"],
            AwayTeamId = (int)r["Away_Team_ID"],
            StadiumId  = (int)r["Stadium_ID"],
            RefereeId  = (int)r["Referee_ID"],
            HomeGoals  = (int)r["Home_Goals"],
            AwayGoals  = (int)r["Away_Goals"],
            Attendance = (int)r["Attendance"],

            // ViewModel properties
            HomeTeamName = r["Home_Team_Name"].ToString(),
            AwayTeamName = r["Away_Team_Name"].ToString(),
            StadiumName  = r["Stadium_Name"].ToString(),
            RefereeName  = r["Referee_Name"].ToString()
        };
    }
}
