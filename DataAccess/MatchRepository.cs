using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EPL_DBMS.Models;
using EPL_DBMS.Utils;
using EPL_DBMS.ViewModels;

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
                using (var cmd = new SqlCommand("sp_Match_GetAll", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(Map(reader));
                }
            }
            return list;
        }

        public static Match GetById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_GetById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? Map(reader) : null;
                }
            }
        }

        public static void Add(Match m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchDate",  m.MatchDate);
                    cmd.Parameters.AddWithValue("@HomeTeamId", m.HomeTeamId);
                    cmd.Parameters.AddWithValue("@AwayTeamId", m.AwayTeamId);
                    cmd.Parameters.AddWithValue("@StadiumId",  m.StadiumId);
                    cmd.Parameters.AddWithValue("@RefereeId",  m.RefereeId);
                    cmd.Parameters.AddWithValue("@HomeGoals",  m.HomeGoals);
                    cmd.Parameters.AddWithValue("@AwayGoals",  m.AwayGoals);
                    cmd.Parameters.AddWithValue("@Attendance", m.Attendance);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Update(Match m)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_Update", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId",    m.MatchId);
                    cmd.Parameters.AddWithValue("@MatchDate",  m.MatchDate);
                    cmd.Parameters.AddWithValue("@HomeTeamId", m.HomeTeamId);
                    cmd.Parameters.AddWithValue("@AwayTeamId", m.AwayTeamId);
                    cmd.Parameters.AddWithValue("@StadiumId",  m.StadiumId);
                    cmd.Parameters.AddWithValue("@RefereeId",  m.RefereeId);
                    cmd.Parameters.AddWithValue("@HomeGoals",  m.HomeGoals);
                    cmd.Parameters.AddWithValue("@AwayGoals",  m.AwayGoals);
                    cmd.Parameters.AddWithValue("@Attendance", m.Attendance);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_Delete", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static int MatchCount()
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_Count", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public static List<MatchViewModel> GetAllMatchesForGrid()
        {
            var list = new List<MatchViewModel>();
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_GetAllForGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var reader = cmd.ExecuteReader())
                        while (reader.Read())
                            list.Add(MapView(reader));
                }
            }
            return list;
        }

        public static MatchViewModel GetMatchViewById(int id)
        {
            using (var con = DatabaseHelper.GetConnection())
            {
                con.Open();
                using (var cmd = new SqlCommand("sp_Match_GetViewById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MatchId", id);
                    using (var reader = cmd.ExecuteReader())
                        return reader.Read() ? MapView(reader) : null;
                }
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

        private static MatchViewModel MapView(SqlDataReader r) => new MatchViewModel
        {
            MatchId      = (int)r["Match_ID"],
            MatchDate    = (DateTime)r["Match_Date"],
            HomeTeamId   = (int)r["Home_Team_ID"],
            AwayTeamId   = (int)r["Away_Team_ID"],
            StadiumId    = (int)r["Stadium_ID"],
            RefereeId    = (int)r["Referee_ID"],
            HomeGoals    = (int)r["Home_Goals"],
            AwayGoals    = (int)r["Away_Goals"],
            Attendance   = (int)r["Attendance"],
            HomeTeamName = r["Home_Team_Name"].ToString(),
            AwayTeamName = r["Away_Team_Name"].ToString(),
            StadiumName  = r["Stadium_Name"].ToString(),
            RefereeName  = r["Referee_Name"].ToString()
        };
    }
}
