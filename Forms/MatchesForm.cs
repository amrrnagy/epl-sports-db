using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class MatchesForm : Form
    {
        public MatchesForm()
        {
            InitializeComponent();
            LoadMatches();
        }

        private void LoadMatches()
        {
            try
            {
                var data = MatchRepository.GetAllMatches();
                var dgv  = dataGridViewMatches;
                dgv.DataSource = data;
                dgv.Columns["MatchId"].HeaderText = "ID";
                dgv.Columns["MatchDate"].HeaderText = "Date";
                dgv.Columns["HomeTeamId"].HeaderText = "Home Team";
                dgv.Columns["AwayTeamId"].HeaderText = "Away Team";
                dgv.Columns["StadiumId"].HeaderText = "Stadium";
                dgv.Columns["RefereeId"].HeaderText = "Referee";
                dgv.Columns["HomeGoals"].HeaderText = "Home Goals";
                dgv.Columns["AwayGoals"].HeaderText = "Away Goals";
                dgv.Columns["Attendance"].HeaderText = "Attendance";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Matches: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
