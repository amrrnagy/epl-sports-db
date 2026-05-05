using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class TeamStatsForm : Form
    {
        public TeamStatsForm()
        {
            InitializeComponent();
            LoadTeamStats();
        }

        private void LoadTeamStats()
        {
            try
            {
                var data = TeamStatRepository.GetAllTeamStats();
                var dgv  = dataGridViewTeamStats;
                dgv.DataSource = data;
                dgv.Columns["TeamStatId"].HeaderText = "ID";
                dgv.Columns["MatchId"].HeaderText = "Match ID";
                dgv.Columns["TeamId"].HeaderText = "Team ID";
                dgv.Columns["PossessionPercentage"].HeaderText = "Possession %";
                dgv.Columns["ShotsOnTarget"].HeaderText = "Shots on Target";
                dgv.Columns["Corners"].HeaderText = "Corners";
                dgv.Columns["Fouls"].HeaderText = "Fouls";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Team Stats: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
