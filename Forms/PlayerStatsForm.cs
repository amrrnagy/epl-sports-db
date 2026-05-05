using System;
using System.Windows.Forms;
using EPL_DBMS.DataAccess;

namespace EPL_DBMS.Forms
{
    public partial class PlayerStatsForm : Form
    {
        public PlayerStatsForm()
        {
            InitializeComponent();
            LoadPlayerStats();
        }

        private void LoadPlayerStats()
        {
            try
            {
                var data = PlayerStatRepository.GetAllPlayerStats();
                var dgv  = dataGridViewPlayerStats;
                dgv.DataSource = data;
                dgv.Columns["PlayerStatId"].HeaderText = "ID";
                dgv.Columns["MatchId"].HeaderText = "Match ID";
                dgv.Columns["PlayerId"].HeaderText = "Player ID";
                dgv.Columns["GoalsScored"].HeaderText = "Goals";
                dgv.Columns["Assists"].HeaderText = "Assists";
                dgv.Columns["YellowCards"].HeaderText = "Yellow Cards";
                dgv.Columns["RedCards"].HeaderText = "Red Cards";
                dgv.Columns["MinutesPlayed"].HeaderText = "Minutes Played";
                dgv.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Player Stats: " + ex.Message,
                    "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
